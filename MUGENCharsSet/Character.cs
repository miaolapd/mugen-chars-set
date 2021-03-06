﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SharpCompress.Common;
using SharpCompress.Reader;

namespace MUGENCharsSet
{
    /// <summary>
    /// MUGEN人物类
    /// </summary>
    public class Character : IComparable<Character>
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
        /// <summary>无效人物名数组(用于过滤select.def中的人物列表)</summary>
        public static string[] InvalidCharacterName = new string[] { String.Empty, "blank", "empty", "randomselect", "/-", "/" };
        /// <summary>人物压缩包扩展名数组</summary>
        public static string[] ArchiveExt = new string[] { ".zip", ".rar", ".7z", ".tar", ".gz", ".bz2" };
        private static string[] _characterDefPathList = null;

        /// <summary>
        /// 人物配置信息类
        /// </summary>
        public struct SettingInfo
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
            /// <summary>人物localcoord配置项</summary>
            public const string LocalcoordItem = "localcoord";
            /// <summary>stcommon相对路径配置项</summary>
            public const string StcommonItem = "stcommon";
            /// <summary>sprite相对路径配置项</summary>
            public const string SpriteItem = "sprite";
        }

        #endregion

        #region 类私有成员

        private string _defPath;
        private string _cns;
        private string _name;
        private string _displayName;
        private int _life;
        private int _attack;
        private int _defence;
        private int _power;
        private Dictionary<string, string> _palList;
        private bool _isWideScreen;
        private string _stcommon;
        private string _spritePath;
        private SpriteFile.SffVerion _spriteVersion;
        private SpriteFile _sprite;
        private bool _isInSelectDef;

        #endregion

        #region 类属性

        /// <summary>
        /// 获取或设置def文件绝对路径
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public string DefPath
        {
            get { return _defPath; }
            private set
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
            private set { _cns = value; }
        }

        /// <summary>
        /// 获取cns绝对路径
        /// </summary>
        public string CnsFullPath
        {
            get { return DefPath.GetDirPathOfFile() + Cns; }
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
        /// 获取在人物列表控件上显示的名称
        /// </summary>
        public string ItemName
        {
            get
            {
                StringBuilder name = new StringBuilder(6);
                if (AppConfig.ShowCharacterScreenMark && MugenSetting.Version != MugenSetting.MugenVersion.WIN)
                {
                    if (MugenSetting.IsWideScreen)
                    {
                        if (!IsWideScreen) name.Append("(普)");
                    }
                    else
                    {
                        if (IsWideScreen) name.Append("(宽)");
                    }
                }
                if (!IsInSelectDef)
                {
                    name.Append("(未)");
                }
                return Name + " " + name.ToString();
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
        public Dictionary<string, string> PalList
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
                string path = DefPath.GetDirPathOfFile();
                if (!Directory.Exists(path)) return null;
                List<string> actArr = new List<string>();
                ScanActList(actArr, path);
                string[] tempActList = new string[actArr.Count];
                actArr.CopyTo(tempActList, 0);
                return tempActList;
            }
        }

        /// <summary>
        /// 获取或设置人物包是否为宽屏
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public bool IsWideScreen
        {
            get { return _isWideScreen; }
            set
            {
                if (value)
                {
                    try
                    {
                        IniFiles ini = new IniFiles(DefPath);
                        int width = 427;
                        int height = 240;
                        ini.WriteString(SettingInfo.InfoSection, SettingInfo.LocalcoordItem, String.Format("{0},{1}", width, height));
                    }
                    catch (ApplicationException)
                    {
                        throw new ApplicationException("宽屏人物包转换失败！");
                    }
                }
                else
                {
                    try
                    {
                        IniFiles ini = new IniFiles(DefPath);
                        ini.DeleteKey(SettingInfo.InfoSection, SettingInfo.LocalcoordItem);
                    }
                    catch (ApplicationException)
                    {
                        throw new ApplicationException("普屏人物包转换失败！");
                    }
                }
                _isWideScreen = value;
            }
        }

        /// <summary>
        /// 获取或设置stcommon相对路径
        /// </summary>
        public string Stcommon
        {
            get { return _stcommon; }
            set { _stcommon = value; }
        }

        /// <summary>
        /// 获取或设置人物模型文件相对路径
        /// </summary>
        public string SpritePath
        {
            get { return _spritePath; }
            set { _spritePath = value; }
        }

        /// <summary>
        /// 获取或设置人物模型文件版本
        /// </summary>
        public SpriteFile.SffVerion SpriteVersion
        {
            get { return _spriteVersion; }
            set { _spriteVersion = value; }
        }

        /// <summary>
        /// 获取或设置人物模型
        /// </summary>
        public SpriteFile Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        /// <summary>
        /// 获取人物模型图像
        /// </summary>
        public Bitmap SpriteImage
        {
            get
            {
                if (Sprite == null) return null;
                if (Sprite.FirstSubNode == null) return null;
                if (Sprite.FirstSubNode.ImageData == null) return null;
                ImagePcx pcx = new ImagePcx(Sprite.FirstSubNode.ImageData);
                Bitmap image = pcx.PcxImage;
                try
                {
                    image.MakeTransparent(image.GetPixel(0, 0));
                }
                catch (Exception)
                {
                    return null;
                }
                return image;
            }
        }

        /// <summary>
        /// 获取或设置此人物是否在select.def文件的人物列表中
        /// </summary>
        public bool IsInSelectDef
        {
            get { return _isInSelectDef; }
            set { _isInSelectDef = value; }
        }

        /// <summary>
        /// 获取select.def文件中的人物def文件的绝对路径的列表
        /// </summary>
        public static string[] CharacterDefPathList
        {
            get { return _characterDefPathList; }
        }

        #endregion

        /// <summary>
        /// 根据指定def文件路径创建<see cref="Character"/>类新实例
        /// </summary>
        /// <param name="defPath">人物def文件绝对路径</param>
        /// <exception cref="System.ApplicationException"></exception>
        public Character(string defPath)
        {
            DefPath = defPath.GetBackSlashPath();
            ReadCharacterSetting();
            PalList = null;
        }

        #region 类方法

        /// <summary>
        /// 用于比较两个Character类的大小
        /// </summary>
        /// <param name="other">要比较的人物</param>
        /// <returns>比较的结果</returns>
        public int CompareTo(Character other)
        {
            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// 检查此人物实例的人物def文件是否与指定路径相同
        /// </summary>
        /// <param name="defPath">人物def文件绝对路径</param>
        /// <returns></returns>
        public bool Equals(string defPath)
        {
            if (DefPath.ToLower().GetBackSlashPath() == defPath.ToLower().GetBackSlashPath())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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
            Cns = ini.ReadString(SettingInfo.FilesSection, SettingInfo.CnsItem, "").GetBackSlashPath();
            _isWideScreen = ini.ReadString(SettingInfo.InfoSection, SettingInfo.LocalcoordItem, "") != String.Empty;
            Stcommon = ini.ReadString(SettingInfo.FilesSection, SettingInfo.StcommonItem, "");
            SpritePath = ini.ReadString(SettingInfo.FilesSection, SettingInfo.SpriteItem, "");
            if (!File.Exists(CnsFullPath)) throw new ApplicationException("人物cns文件不存在！");
            ini = new IniFiles(CnsFullPath);
            Life = ini.ReadInteger(SettingInfo.DataSection, SettingInfo.LifeItem, 0);
            Attack = ini.ReadInteger(SettingInfo.DataSection, SettingInfo.AttackItem, 0);
            Defence = ini.ReadInteger(SettingInfo.DataSection, SettingInfo.DefenceItem, 0);
            Power = ini.ReadInteger(SettingInfo.DataSection, SettingInfo.PowerItem, 0);
            if (CharacterDefPathList != null && CharacterDefPathList.Contains(DefPath.ToLower()))
                IsInSelectDef = true;
        }

        /// <summary>
        /// 读取Pal设置
        /// </summary>
        public void ReadPalSetting()
        {
            IniFiles ini = new IniFiles(DefPath);
            NameValueCollection tempDict = new NameValueCollection();
            ini.ReadSectionValues(SettingInfo.FilesSection, tempDict);
            PalList = new Dictionary<string, string>();
            foreach (string key in tempDict)
            {
                if (key.StartsWith(SettingInfo.PalItemPrefix, StringComparison.CurrentCultureIgnoreCase))
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
        private void ScanActList(List<string> actList, string dir)
        {
            if (!Directory.Exists(dir)) return;
            string[] tempPalFiles = Directory.GetFiles(dir, "*" + ActExt);
            for (int i = 0; i < tempPalFiles.Length; i++)
            {
                tempPalFiles[i] = tempPalFiles[i].Substring(DefPath.GetDirPathOfFile().Length).GetSlashPath();
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
            catch (ApplicationException)
            {
                throw new ApplicationException("人物def文件写入失败！");
            }
            try
            {
                foreach (string key in PalList.Keys)
                {
                    ini.WriteString(SettingInfo.FilesSection, key, PalList[key]);
                }
            }
            catch (ApplicationException)
            {
                try
                {
                    ReadPalSetting();
                }
                catch (ApplicationException) { }
                throw new ApplicationException("Pal配置项写入失败！");
            }
            if (!File.Exists(CnsFullPath)) throw new ApplicationException("人物cns文件不存在！");
            int total = MultiSave(new Character[] { this });
            if (total == 0) throw new ApplicationException("人物cns文件写入失败！");
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
                if (!Tools.SetFileNotReadOnly(DefPath + BakExt)) throw new Exception();
                File.Copy(DefPath, DefPath + BakExt, true);
                if (!Tools.SetFileNotReadOnly(CnsFullPath + BakExt)) throw new Exception();
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
                if (!Tools.SetFileNotReadOnly(DefPath)) throw new Exception();
                File.Copy(DefPath + BakExt, DefPath, true);
                if (!Tools.SetFileNotReadOnly(CnsFullPath)) throw new Exception();
                File.Copy(CnsFullPath + BakExt, CnsFullPath, true);
                ReadCharacterSetting();
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
                if (!Tools.SetFileNotReadOnly(DefPath + DelExt)) throw new Exception();
                File.Copy(DefPath, DefPath + DelExt, true);
                if (!Tools.SetFileNotReadOnly(DefPath)) throw new Exception();
                File.Delete(DefPath);
            }
            catch (Exception)
            {
                throw new ApplicationException("人物删除失败！");
            }
            DeleteCharacterListInSelectDef(new Character[] { this });
        }

        /// <summary>
        /// 转换为宽屏人物包
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public void ConvertToWideScreen()
        {
            if (!File.Exists(DefPath)) throw new ApplicationException("人物def文件不存在！");
            try
            {
                IsWideScreen = true;
                string stcommonPath = (DefPath.GetDirPathOfFile() + Stcommon).GetBackSlashPath();
                if (File.Exists(stcommonPath))
                {
                    StcommonConvertToWideScreen(stcommonPath);
                }
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("宽屏人物包转换失败！");
            }
        }

        /// <summary>
        /// 转换为普屏人物包
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public void ConvertToNormalScreen()
        {
            if (!File.Exists(DefPath)) throw new ApplicationException("人物def文件不存在！");
            try
            {
                IsWideScreen = false;
                string stcommonPath = (DefPath.GetDirPathOfFile() + Stcommon).GetBackSlashPath();
                if (File.Exists(stcommonPath))
                {
                    StcommonConvertToNormalScreen(stcommonPath);
                }
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("普屏人物包转换失败！");
            }
        }

        /// <summary>
        /// 读取人物模型
        /// </summary>
        /// <returns>是否读取成功</returns>
        public bool ReadSpriteFile()
        {
            string sffPath = DefPath.GetDirPathOfFile() + SpritePath.GetBackSlashPath();
            if (!File.Exists(sffPath)) return false;
            try
            {
                Sprite = new SpriteFile(sffPath);
            }
            catch (ApplicationException)
            {
                return false;
            }
            SpriteVersion = Sprite.Version;
            return true;
        }

        /// <summary>
        /// 获取被指定色表替换后的人物模型图像
        /// </summary>
        /// <param name="actPath">色表文件相对路径</param>
        /// <returns>人物模型图像</returns>
        public Bitmap GetSpriteImageWithPal(string path)
        {
            string actPath = DefPath.GetDirPathOfFile() + path.GetBackSlashPath();
            if (!File.Exists(actPath)) return null;
            if (Sprite == null) return null;
            if (Sprite.FirstSubNode == null) return null;
            if (Sprite.FirstSubNode.ImageData == null) return null;
            FileStream fs = null;
            BinaryReader br = null;
            byte[] newImageData = null;
            try
            {
                fs = new FileStream(actPath, FileMode.Open);
                br = new BinaryReader(fs);
                byte[] actData = br.ReadBytes((int)fs.Length);
                newImageData = Sprite.FirstSubNode.ImageData.Take(Sprite.FirstSubNode.ImageData.Length - (int)fs.Length).Concat(actData.Reverse()).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (br != null) br.Close();
                if (fs != null) fs.Close();
            }
            if (newImageData == null) return null;
            ImagePcx pcx = new ImagePcx(newImageData);
            Bitmap image = pcx.PcxImage;
            try
            {
                image.MakeTransparent(image.GetPixel(0, 0));
            }
            catch (Exception)
            {
                return null;
            }
            return image;
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
                    character.Backup();
                    total++;
                }
                catch (ApplicationException)
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
                    character.Restore();
                    total++;
                }
                catch (ApplicationException)
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
                    character.Delete();
                    total++;
                }
                catch (ApplicationException)
                {
                    continue;
                }
            }
            DeleteCharacterListInSelectDef(characterList);
            return total;
        }

        /// <summary>
        /// 批量转换为宽屏人物包
        /// </summary>
        /// <param name="characterList">人物列表</param>
        /// <returns>转换成功总数</returns>
        public static int MultiConvertToWideScreen(Character[] characterList)
        {
            int total = 0;
            foreach (Character character in characterList)
            {
                try
                {
                    character.ConvertToWideScreen();
                    total++;
                }
                catch (ApplicationException)
                {
                    continue;
                }
            }
            return total;
        }

        /// <summary>
        /// 批量转换为普屏人物包
        /// </summary>
        /// <param name="characterList">人物列表</param>
        /// <returns>转换成功总数</returns>
        public static int MultiConvertToNormalScreen(Character[] characterList)
        {
            int total = 0;
            foreach (Character character in characterList)
            {
                try
                {
                    character.ConvertToNormalScreen();
                    total++;
                }
                catch (ApplicationException)
                {
                    continue;
                }
            }
            return total;
        }

        /// <summary>
        /// 将stcommon文件里的重力修改成适合宽屏的状态
        /// </summary>
        /// <param name="stcommonPath">stcommon文件绝对路径</param>
        /// <exception cref="System.ApplicationException"></exception>
        public static void StcommonConvertToWideScreen(string stcommonPath)
        {
            if (!File.Exists(stcommonPath)) throw new ApplicationException("stcommon文件不存在！");
            try
            {
                string content = File.ReadAllText(stcommonPath, Encoding.Default);
                Regex regex = new Regex(@"yaccel\s*\)(\s*/\s*\d+)?(\.\d+)?", RegexOptions.IgnoreCase);
                content = regex.Replace(content, "yaccel)/1.2");
                File.WriteAllText(stcommonPath, content, Encoding.Default);
            }
            catch (Exception)
            {
                throw new ApplicationException("stcommon文件转换宽屏失败！");
            }
        }

        /// <summary>
        /// 将stcommon文件里的重力修改成适合普屏的状态
        /// </summary>
        /// <param name="stcommonPath">stcommon文件绝对路径</param>
        /// <exception cref="System.ApplicationException"></exception>
        public static void StcommonConvertToNormalScreen(string stcommonPath)
        {
            if (!File.Exists(stcommonPath)) throw new ApplicationException("stcommon文件不存在！");
            try
            {
                string content = File.ReadAllText(stcommonPath, Encoding.Default);
                Regex regex = new Regex(@"yaccel\s*\)\s*/\s*\d+(\.\d+)?", RegexOptions.IgnoreCase);
                content = regex.Replace(content, "yaccel)");
                File.WriteAllText(stcommonPath, content, Encoding.Default);
            }
            catch (Exception)
            {
                throw new ApplicationException("stcommon文件转换普屏失败！");
            }
        }

        /// <summary>
        /// 获取stcommon文件里的重力是否为适合宽屏的状态
        /// </summary>
        /// <param name="stcommonContent">stcommon文件内容</param>
        /// <returns>状态值(-1：未找到相关项, 0：普屏, 1：宽屏)</returns>
        public static int IsStcommonWideScreen(string stcommonContent)
        {
            try
            {
                if (!(new Regex("yaccel", RegexOptions.IgnoreCase)).IsMatch(stcommonContent)) return -1;
                if ((new Regex(@"yaccel\s*\)\s*/\s*\d+(\.\d+)?", RegexOptions.IgnoreCase)).IsMatch(stcommonContent)) return 1;
                else return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 通过扫描人物文件夹来获取人物列表
        /// </summary>
        /// <param name="characterList">人物列表</param>
        /// <param name="charsDir">人物文件夹</param>
        public static void ScanCharacterDir(List<Character> characterList, string charsDir)
        {
            string[] tempDefList = Directory.GetFiles(charsDir, "*" + Character.DefExt);
            foreach (string tempDefPath in tempDefList)
            {
                System.Windows.Forms.Application.DoEvents();
                try
                {
                    characterList.Add(new Character(tempDefPath));
                }
                catch (ApplicationException)
                {
                    continue;
                }
            }
            string[] tempDirArr = Directory.GetDirectories(charsDir);
            foreach (string tempDir in tempDirArr)
            {
                ScanCharacterDir(characterList, tempDir);
            }
        }

        /// <summary>
        /// 通过读取select.def文件来获取人物列表
        /// </summary>
        /// <param name="characterList">人物列表</param>
        /// <exception cref="System.ApplicationException"></exception>
        public static void ReadCharacterListInSelectDef(List<Character> characterList)
        {
            if (!File.Exists(MugenSetting.SelectDefPath)) throw new ApplicationException("select.def文件不存在！");
            foreach (string defPath in CharacterDefPathList)
            {
                System.Windows.Forms.Application.DoEvents();
                try
                {
                    characterList.Add(new Character(defPath));
                }
                catch (ApplicationException)
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 读取select.def文件中的人物def文件的绝对路径的列表
        /// </summary>
        /// <returns>人物def文件的绝对路径的列表</returns>
        public static void ReadCharacterDefPathListInSelectDef()
        {
            _characterDefPathList = null;
            if (!File.Exists(MugenSetting.SelectDefPath)) return;
            Tools.IniFileStandardization(MugenSetting.SelectDefPath);
            string[] characterLines = null;
            try
            {
                string defContent = File.ReadAllText(MugenSetting.SelectDefPath, Encoding.Default);
                Regex regex = new Regex(@"\[Characters\](.*)\r\n\[ExtraStages\]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                characterLines = regex.Match(defContent).Groups[1].Value.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception)
            {
                return;
            }
            if (characterLines.Length == 0) return;
            List<string> characterList = new List<string>();
            foreach (string tempLine in characterLines)
            {
                string line = tempLine.Trim();
                line = line.Split(new string[] { IniFiles.CommentMark }, 2, StringSplitOptions.None)[0];
                line = line.Split(new string[] { "," }, 2, StringSplitOptions.None)[0].Trim();
                if (InvalidCharacterName.Contains(line.ToLower())) continue;
                if (Path.GetExtension(line.ToLower()) != Character.DefExt) line = line.GetFormatDirPath() + line + Character.DefExt;
                string defPath = (MugenSetting.MugenCharsDirPath + line.GetBackSlashPath()).ToLower();
                if (!File.Exists(defPath)) continue;
                if (!characterList.Contains(defPath))
                {
                    characterList.Add(defPath);
                }
            }
            _characterDefPathList = characterList.ToArray();
        }

        /// <summary>
        /// 删除select.def文件中的人物列表
        /// </summary>
        /// <param name="characterList">人物列表</param>
        public static void DeleteCharacterListInSelectDef(Character[] characterList)
        {
            if (!File.Exists(MugenSetting.SelectDefPath)) return;
            string fileContent = "";
            string oriCharacterContent = "";
            string[] characterLines = null;
            try
            {
                fileContent = File.ReadAllText(MugenSetting.SelectDefPath, Encoding.Default);
                Regex regex = new Regex(@"(\[Characters\].*)\r\n\[ExtraStages\]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                oriCharacterContent = regex.Match(fileContent).Groups[1].Value;
                characterLines = oriCharacterContent.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            }
            catch (Exception)
            {
                return;
            }
            if (characterLines.Length <= 1) return;
            for (int i = 1; i < characterLines.Length; i++)
            {
                string line = characterLines[i].Trim();
                line = line.Split(new string[] { IniFiles.CommentMark }, 2, StringSplitOptions.None)[0];
                line = line.Split(new string[] { "," }, 2, StringSplitOptions.None)[0].Trim();
                if (InvalidCharacterName.Contains(line.ToLower())) continue;
                if (Path.GetExtension(line.ToLower()) != Character.DefExt) line = line.GetFormatDirPath() + line + Character.DefExt;
                string defPath = MugenSetting.MugenCharsDirPath + line.GetBackSlashPath();
                foreach (Character character in characterList)
                {
                    if (character.Equals(defPath))
                    {
                        characterLines[i] = IniFiles.CommentMark + characterLines[i];
                        break;
                    }
                }
            }
            fileContent = fileContent.Replace(oriCharacterContent, String.Join("\r\n", characterLines));
            try
            {
                File.WriteAllText(MugenSetting.SelectDefPath, fileContent, Encoding.Default);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 将人物添加到select.def文件中
        /// </summary>
        /// <param name="characterList">人物列表</param>
        /// <returns>添加成功总数</returns>
        public static bool AddCharacterToSelectDef(Character[] characterList)
        {
            if (!File.Exists(MugenSetting.SelectDefPath)) return false;
            Tools.IniFileStandardization(MugenSetting.SelectDefPath);
            string fileContent = "";
            string oriCharacterContent = "";
            try
            {
                fileContent = File.ReadAllText(MugenSetting.SelectDefPath, Encoding.Default);
                Regex regex = new Regex(@"(\[Characters\].*?)(\r\n)+(;-*)?(\r\n)+\[ExtraStages\]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                oriCharacterContent = regex.Match(fileContent).Groups[1].Value;
            }
            catch (Exception)
            {
                return false;
            }
            StringBuilder newCharacterContent = new StringBuilder();
            foreach (Character character in characterList)
            {
                if (CharacterDefPathList != null && CharacterDefPathList.Contains(character.DefPath.ToLower())) continue;
                newCharacterContent.Append("\r\n" + character.DefPath.Substring(MugenSetting.MugenCharsDirPath.Length).GetSlashPath());
                character.IsInSelectDef = true;
            }
            fileContent = fileContent.Replace(oriCharacterContent, oriCharacterContent + newCharacterContent);
            try
            {
                File.WriteAllText(MugenSetting.SelectDefPath, fileContent, Encoding.Default);
            }
            catch (Exception)
            {
                foreach (Character character in characterList)
                {
                    if (CharacterDefPathList != null && CharacterDefPathList.Contains(character.DefPath.ToLower())) continue;
                    character.IsInSelectDef = false;
                }
                return false;
            }
            ReadCharacterDefPathListInSelectDef();
            return true;
        }

        /// <summary>
        /// 解压缩人物压缩包
        /// </summary>
        /// <param name="archivePath">人物压缩包绝对路径</param>
        /// <returns>所创建的新人物文件夹绝对路径</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public static string DecompressionCharacterArchive(string archivePath)
        {
            if (!File.Exists(archivePath)) throw new ApplicationException("压缩包不存在！");
            string tempDirPath = MugenSetting.MugenCharsDirPath + "MugenCharsSetTemp\\";
            DirectoryInfo tempDir;
            try
            {
                tempDir = Directory.CreateDirectory(tempDirPath);
            }
            catch (Exception)
            {
                throw new ApplicationException("创建临时文件夹失败！");
            }
            FileStream fs = null;
            try
            {
                fs = File.OpenRead(archivePath);
                IReader reader = ReaderFactory.Open(fs);
                while (reader.MoveToNextEntry())
                {
                    System.Windows.Forms.Application.DoEvents();
                    if (!reader.Entry.IsDirectory)
                    {
                        try
                        {
                            reader.WriteEntryToDirectory(tempDirPath, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                        }
                        catch(Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    tempDir.Delete(true);
                }
                catch (Exception) { }
                throw new ApplicationException("解压缩失败！");
            }
            finally
            {
                if (fs != null) fs.Close();
            }
            string destDirPath = "";
            try
            {
                if (tempDir.GetDirectories().Length == 1 && tempDir.GetFiles().Length == 0)
                {
                    destDirPath = Tools.GetNonExistsDirPath(MugenSetting.MugenCharsDirPath, tempDir.GetDirectories()[0].Name);
                    Directory.Move(tempDir.GetDirectories()[0].FullName, destDirPath);
                    tempDir.Delete(true);
                }
                else
                {
                    destDirPath = Tools.GetNonExistsDirPath(MugenSetting.MugenCharsDirPath, Path.GetFileNameWithoutExtension(archivePath));
                    tempDir.MoveTo(destDirPath);
                }
            }
            catch (Exception)
            {
                try
                {
                    tempDir.Delete(true);
                }
                catch (Exception) { }
                throw new ApplicationException("移动文件夹失败！");
            }
            return destDirPath;
        }

        #endregion
    }
}
