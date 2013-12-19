using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;

namespace MUGENCharsSet
{
    /// <summary>
    /// MUGEN人物类
    /// </summary>
    public class Character
    {
        #region 类常量

        /// <summary>def文件扩展名</summary>
        public const string DefExt = ".def";
        /// <summary>备份文件扩展名</summary>
        public const string BakExt = ".bak";
        /// <summary>已删除人物文件扩展名</summary>
        public const string DelExt = ".del";
        /// <summary>act文件扩展名</summary>
        public const string ActExt = ".act";
        /// <summary>人物名界定符</summary>
        public const char NameDelimeter = '"';

        /// <summary>
        /// 人物配置信息类
        /// </summary>
        public static class SettingInfo
        {
            /// <summary>Info配置分段</summary>
            public const string InfoSection = "Info";
            /// <summary>Files配置分段</summary>
            public const string FilesSection = "Files";
            /// <summary>Data配置分段</summary>
            public const string DataSection = "Data";
            /// <summary>人物名配置项</summary>
            public const string NameItem = "name";
            /// <summary>人物显示名配置项</summary>
            public const string DisplayNameItem = "displayname";
            /// <summary>cns相对路径配置项</summary>
            public const string CnsItem = "cns";
            /// <summary>生命值配置项</summary>
            public const string LifeItem = "life";
            /// <summary>攻击力配置项</summary>
            public const string AttackItem = "attack";
            /// <summary>防御力配置项</summary>
            public const string DefenceItem = "defence";
            /// <summary>气上限配置项</summary>
            public const string PowerItem = "power";
            /// <summary>pal配置项前缀名</summary>
            public const string PalItemPrefix = "pal";
        }

        #endregion

        #region 类私有成员

        protected string _defPath;
        protected string _cns;
        protected string _name;
        protected string _displayName;
        protected int _life;
        protected int _attack;
        protected int _defence;
        protected int _power;
        protected NameValueCollection _palList;

        #endregion

        #region 类属性

        /// <summary>
        /// 获取或设置def文件绝对路径
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public string DefPath
        {
            get { return _defPath; }
            set
            {
                if (value == String.Empty) throw new ApplicationException("def路径不得为空！");
                _defPath = value;
            }
        }

        /// <summary>
        /// 获取或设置cns相对路径
        /// </summary>
        public string Cns
        {
            get { return _cns; }
            set { _cns = value; }
        }

        /// <summary>
        /// 获取cns绝对路径
        /// </summary>
        public string CnsFullPath
        {
            get { return Tools.GetFileDirName(DefPath) + Cns; }
        }

        /// <summary>
        /// 获取或设置人物名
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == String.Empty) throw new ApplicationException("人物名称不得为空！");
                if (value == MainForm.MultiValue) return;
                _name = value;
            }
        }

        /// <summary>
        /// 获取或设置显示名
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (value == String.Empty) throw new ApplicationException("显示名不得为空！");
                if (value == MainForm.MultiValue) return;
                _displayName = value;
            }
        }

        /// <summary>
        /// 获取或设置生命值
        /// </summary>
        public int Life
        {
            get { return _life; }
            set
            {
                if (value == 0) return;
                _life = value;
            }
        }

        /// <summary>
        /// 获取或设置攻击力
        /// </summary>
        public int Attack
        {
            get { return _attack; }
            set
            {
                if (value == 0) return;
                _attack = value;
            }
        }

        /// <summary>
        /// 获取或设置防御力
        /// </summary>
        public int Defence
        {
            get { return _defence; }
            set
            {
                if (value == 0) return;
                _defence = value;
            }
        }

        /// <summary>
        /// 获取或设置气上限
        /// </summary>
        public int Power
        {
            get { return _power; }
            set
            {
                if (value == 0) return;
                _power = value;
            }
        }

        /// <summary>
        /// 获取或设置Pal相对路径键值对列表
        /// </summary>
        public NameValueCollection PalList
        {
            get { return _palList; }
            set { _palList = value; }
        }

        /// <summary>
        /// 获取当前所有可选的act文件相对路径列表
        /// </summary>
        public string[] SelectableActFileList
        {
            get
            {
                string path = Tools.GetFileDirName(DefPath);
                if (!Directory.Exists(path)) return null;
                StringCollection actArr = new StringCollection();
                ScanActList(actArr, path);
                string[] tempActList = new string[actArr.Count];
                actArr.CopyTo(tempActList, 0);
                return tempActList;
            }
        }

        #endregion

        /// <summary>
        /// 类构造方法
        /// </summary>
        /// <param name="defPath">人物def文件绝对路径</param>
        /// <exception cref="System.ApplicationException"></exception>
        public Character(string defPath)
        {
            DefPath = Tools.GetBackSlashPath(defPath);
            ReadCharacterSetting();
            PalList = null;
        }

        #region 类方法

        /// <summary>
        /// 读取人物属性设置
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public void ReadCharacterSetting()
        {
            if (!File.Exists(DefPath)) throw new ApplicationException("人物def文件不存在！");
            IniFiles ini = new IniFiles(DefPath);
            Name = GetTrimName(ini.ReadString(SettingInfo.InfoSection, SettingInfo.NameItem, ""));
            DisplayName = GetTrimName(ini.ReadString(SettingInfo.InfoSection, SettingInfo.DisplayNameItem, ""));
            Cns = Tools.GetBackSlashPath(ini.ReadString(SettingInfo.FilesSection, SettingInfo.CnsItem, ""));

            if (!File.Exists(CnsFullPath)) throw new ApplicationException("人物cns文件不存在！");
            ini = new IniFiles(CnsFullPath);
            Life = ini.ReadInteger(SettingInfo.DataSection, SettingInfo.LifeItem, 0);
            Attack = ini.ReadInteger(SettingInfo.DataSection, SettingInfo.AttackItem, 0);
            Defence = ini.ReadInteger(SettingInfo.DataSection, SettingInfo.DefenceItem, 0);
            Power = ini.ReadInteger(SettingInfo.DataSection, SettingInfo.PowerItem, 0);
        }

        /// <summary>
        /// 读取Pal设置
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public void ReadPalSetting()
        {
            IniFiles ini = new IniFiles(DefPath);
            NameValueCollection tempDict = new NameValueCollection();
            ini.ReadSectionValues(SettingInfo.FilesSection, tempDict);
            if (tempDict.Count == 0) throw new ApplicationException("pal属性不存在！");
            PalList = new NameValueCollection();
            foreach (string key in tempDict)
            {
                if (key.IndexOf(SettingInfo.PalItemPrefix, StringComparison.CurrentCultureIgnoreCase) == 0)
                {
                    PalList.Add(key, tempDict[key]);
                }
            }
        }

        /// <summary>
        /// 扫描当前人物文件夹下所有act文件
        /// </summary>
        /// <param name="actList">act文件相对路径列表</param>
        /// <param name="dir">act文件夹绝对路径</param>
        protected void ScanActList(StringCollection actList, string dir)
        {
            if (!Directory.Exists(dir)) return;
            string[] tempPalFiles = Directory.GetFiles(dir, "*" + ActExt);
            for (int i = 0; i < tempPalFiles.Length; i++)
            {
                tempPalFiles[i] = Tools.GetSlashPath(tempPalFiles[i].Substring(Tools.GetFileDirName(DefPath).Length));
            }
            actList.AddRange(tempPalFiles);
            string[] tempDirs = Directory.GetDirectories(dir);
            foreach (string tempDir in tempDirs)
            {
                ScanActList(actList, tempDir);
            }
        }

        /// <summary>
        /// 保存人物设置
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public void Save()
        {
            if (!File.Exists(DefPath)) throw new ApplicationException("人物def文件不存在！");
            IniFiles ini;
            try
            {
                if (!Tools.SetFileNotReadOnly(DefPath)) throw new ApplicationException();
                ini = new IniFiles(DefPath);
                ini.WriteString(SettingInfo.InfoSection, SettingInfo.NameItem, GetDelimeterName(Name));
                ini.WriteString(SettingInfo.InfoSection, SettingInfo.DisplayNameItem, GetDelimeterName(DisplayName));
            }
            catch(ApplicationException)
            {
                throw new ApplicationException("人物def文件写入失败！");
            }
            foreach (string key in PalList)
            {
                ini.WriteString(SettingInfo.FilesSection, key, PalList[key]);
            }
            if (!File.Exists(CnsFullPath)) throw new ApplicationException("人物cns文件不存在！");
            try
            {
                if (!Tools.SetFileNotReadOnly(CnsFullPath)) throw new ApplicationException();
                ini = new IniFiles(CnsFullPath);
                if (Life != 0) ini.WriteInteger(SettingInfo.DataSection, SettingInfo.LifeItem, Life);
                if (Attack != 0) ini.WriteInteger(SettingInfo.DataSection, SettingInfo.AttackItem, Attack);
                if (Defence != 0) ini.WriteInteger(SettingInfo.DataSection, SettingInfo.DefenceItem, Defence);
                if (Power != 0) ini.WriteInteger(SettingInfo.DataSection, SettingInfo.PowerItem, Power);
            }
            catch(ApplicationException)
            {
                throw new ApplicationException("人物cns文件写入失败！");
            }
        }


        /// <summary>
        /// 备份人物设置
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public void Backup()
        {
            if (!File.Exists(DefPath)) throw new ApplicationException("人物def文件不存在！");
            if (!File.Exists(CnsFullPath)) throw new ApplicationException("人物cns文件不存在！");
            try
            {
                if (!Tools.SetFileNotReadOnly(DefPath + BakExt)) throw new ApplicationException();
                File.Copy(DefPath, DefPath + BakExt, true);
                if (!Tools.SetFileNotReadOnly(CnsFullPath + BakExt)) throw new ApplicationException();
                File.Copy(CnsFullPath, CnsFullPath + BakExt, true);
            }
            catch (Exception)
            {
                throw new ApplicationException("人物备份失败！");
            }
        }

        /// <summary>
        /// 还原人物设置
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public void Restore()
        {
            if (!File.Exists(DefPath + BakExt)) throw new ApplicationException("人物def备份文件不存在！");
            if (!File.Exists(CnsFullPath + BakExt)) throw new ApplicationException("人物cns备份文件不存在！");
            try
            {
                if (!Tools.SetFileNotReadOnly(DefPath)) throw new ApplicationException();
                File.Copy(DefPath + BakExt, DefPath, true);
                File.Copy(CnsFullPath + BakExt, CnsFullPath, true);
            }
            catch (Exception)
            {
                throw new ApplicationException("人物恢复失败！");
            }
        }

        /// <summary>
        /// 删除人物(将def文件重命名为带特定后缀名的文件)
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public void Delete()
        {
            if (!File.Exists(DefPath)) throw new ApplicationException("人物def文件不存在！");
            try
            {
                if (!Tools.SetFileNotReadOnly(DefPath + DelExt)) throw new ApplicationException();
                File.Copy(DefPath, DefPath + DelExt, true);
                if (!Tools.SetFileNotReadOnly(DefPath)) throw new ApplicationException();
                File.Delete(DefPath);
            }
            catch(Exception)
            {
                throw new ApplicationException("人物删除失败！");
            }
        }

        #endregion

        #region 类静态方法

        /// <summary>
        /// 获取去除界定符的人物名
        /// </summary>
        /// <param name="name">人物名</param>
        /// <returns>人物名</returns>
        public static string GetTrimName(string name)
        {
            return name.Trim(NameDelimeter).Trim();
        }

        /// <summary>
        /// 获取头尾带界定符的人物名
        /// </summary>
        /// <param name="name">人物名</param>
        /// <returns>人物名</returns>
        public static string GetDelimeterName(string name)
        {
            return NameDelimeter + GetTrimName(name) + NameDelimeter;
        }

        /// <summary>
        /// 批量保存人物
        /// </summary>
        /// <param name="characterList">人物列表</param>
        /// <returns>修改成功总数</returns>
        public static int MultiSave(Character[] characterList)
        {
            int total = 0;
            IniFiles ini;
            foreach (Character character in characterList)
            {
                if (!File.Exists(character.DefPath)) continue;
                try
                {
                    if (!Tools.SetFileNotReadOnly(character.DefPath)) continue;
                    ini = new IniFiles(character.CnsFullPath);
                    if (character.Life != 0)
                    {
                        ini.WriteInteger(SettingInfo.DataSection, SettingInfo.LifeItem, character.Life);
                    }
                    if (character.Attack != 0)
                    {
                        ini.WriteInteger(SettingInfo.DataSection, SettingInfo.AttackItem, character.Attack);
                    }
                    if (character.Defence != 0)
                    {
                        ini.WriteInteger(SettingInfo.DataSection, SettingInfo.DefenceItem, character.Defence);
                    }
                    if (character.Power != 0)
                    {
                        ini.WriteInteger(SettingInfo.DataSection, SettingInfo.PowerItem, character.Power);
                    }
                }
                catch (ApplicationException)
                {
                    try
                    {
                        character.ReadCharacterSetting();
                    }
                    catch (ApplicationException) { }
                    continue;
                }
                total++;
            }
            return total;
        }

        /// <summary>
        /// 批量备份人物
        /// </summary>
        /// <param name="characterList">人物列表</param>
        /// <returns>备份成功总数</returns>
        public static int MultiBackup(Character[] characterList)
        {
            int total = 0;
            foreach (Character character in characterList)
            {
                try
                {
                    if (!File.Exists(character.DefPath)) continue;
                    if (!File.Exists(character.CnsFullPath)) continue;
                    if (!Tools.SetFileNotReadOnly(character.DefPath + BakExt)) continue;
                    File.Copy(character.DefPath, character.DefPath + BakExt, true);
                    if (!Tools.SetFileNotReadOnly(character.CnsFullPath + BakExt)) continue;
                    File.Copy(character.CnsFullPath, character.CnsFullPath + BakExt, true);
                    total++;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return total;
        }

        /// <summary>
        /// 批量还原人物
        /// </summary>
        /// <param name="characterList">人物列表</param>
        /// <returns>还原成功总数</returns>
        public static int MultiRestore(Character[] characterList)
        {
            int total = 0;
            foreach (Character character in characterList)
            {
                try
                {
                    if (!File.Exists(character.DefPath + BakExt)) continue;
                    if (!File.Exists(character.CnsFullPath + BakExt)) continue;
                    if (!Tools.SetFileNotReadOnly(character.DefPath)) continue;
                    File.Copy(character.DefPath + BakExt, character.DefPath, true);
                    if (!Tools.SetFileNotReadOnly(character.CnsFullPath)) continue;
                    File.Copy(character.CnsFullPath + BakExt, character.CnsFullPath, true);
                    character.ReadCharacterSetting();
                    total++;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return total;
        }

        /// <summary>
        /// 批量删除人物
        /// </summary>
        /// <param name="characterList">人物列表</param>
        /// <returns>删除成功总数</returns>
        public static int MultiDelete(Character[] characterList)
        {
            int total = 0;
            foreach (Character character in characterList)
            {
                try
                {
                    if (!File.Exists(character.DefPath)) continue;
                    if (!Tools.SetFileNotReadOnly(character.DefPath + DelExt)) continue;
                    File.Copy(character.DefPath, character.DefPath + DelExt, true);
                    if (!Tools.SetFileNotReadOnly(character.DefPath)) continue;
                    File.Delete(character.DefPath);
                    total++;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return total;
        }

        #endregion
    }

    /// <summary>
    /// 用于比较两个Character类的大小
    /// </summary>
    public class CharacterCompare : IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            Character cx = (Character)x;
            Character cy = (Character)y;
            return String.Compare(cx.Name, cy.Name);
        }
    }
}
