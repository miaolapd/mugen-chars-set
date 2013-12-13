using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;

namespace MUGENCharsSet
{
    /// <summary>
    /// MUGEN人物基类
    /// </summary>
    public class CharacterBase
    {
        #region 类常量

        public const char NAME_DELIMETER = '"'; //人物名界定符
        public const string INFO_SECTION = "Info";  //Info配置分段
        public const string FILES_SECTION = "Files";    //Files配置分段
        public const string DATA_SECTION = "Data";  //Data配置分段
        public const string NAME_ITEM = "name"; //人物名配置项
        public const string DISPLAYNAME_ITEM = "displayname";   //人物显示名配置项
        public const string CNS_ITEM = "cns";   //cns相对路径配置项
        public const string LIFE_ITEM = "life"; //生命值配置项
        public const string ATTACK_ITEM = "attack"; //攻击力配置项
        public const string DEFENCE_ITEM = "defence";   //防御力配置项
        public const string POWER_ITEM = "power";   //气上限配置项
        public const string DEF_EXT = ".def";   //def文件扩展名
        public const string BAK_EXT = ".bak";   //备份文件扩展名
        public const string DEL_EXT = ".del";   //已删除人物文件扩展名

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

        #endregion

        #region 类属性

        /// <summary>
        /// 获取或设置def文件绝对路径
        /// </summary>
        public string DefPath
        {
            get { return _defPath; }
            set { _defPath = value; }
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
        /// 获取或设置人物名
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 获取或设置显示名
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        /// <summary>
        /// 获取或设置生命值
        /// </summary>
        public int Life
        {
            get { return _life; }
            set { _life = value; }
        }

        /// <summary>
        /// 获取或设置攻击力
        /// </summary>
        public int Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }

        /// <summary>
        /// 获取或设置防御力
        /// </summary>
        public int Defence
        {
            get { return _defence; }
            set { _defence = value; }
        }

        /// <summary>
        /// 获取或设置气上限
        /// </summary>
        public int Power
        {
            get { return _power; }
            set { _power = value; }
        }

        #endregion

        /// <summary>
        /// 类构造函数
        /// </summary>
        /// <param name="defPath">def文件绝对路径</param>
        public CharacterBase(string defPath)
        {
            try
            {
                DefPath = defPath;
                if (!File.Exists(DefPath)) throw (new ApplicationException("def文件不存在！"));
                IniFiles ini = new IniFiles(DefPath);
                Name = GetTrimName(ini.ReadString(INFO_SECTION, NAME_ITEM, ""));
                DisplayName = GetTrimName(ini.ReadString(INFO_SECTION, DISPLAYNAME_ITEM, ""));
                Cns = ini.ReadString(FILES_SECTION, CNS_ITEM, "");
                string cnsPath = Tools.GetFileDirName(DefPath) + Cns;
                if (!File.Exists(cnsPath)) throw (new ApplicationException("cns文件不存在！"));
                ReadCnsSet(cnsPath);
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取cns设置
        /// </summary>
        /// <param name="cnsPath">cns文件绝对路径</param>
        protected void ReadCnsSet(string cnsPath)
        {
            try
            {
                IniFiles ini = new IniFiles(cnsPath);
                Life = ini.ReadInteger(DATA_SECTION, LIFE_ITEM, 0);
                Attack = ini.ReadInteger(DATA_SECTION, ATTACK_ITEM, 0);
                Defence = ini.ReadInteger(DATA_SECTION, DEFENCE_ITEM, 0);
                Power = ini.ReadInteger(DATA_SECTION, POWER_ITEM, 0);
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        #region 类静态方法

        /// <summary>
        /// 获取去除界定符的人物名
        /// </summary>
        /// <param name="name">人物名</param>
        /// <returns>人物名</returns>
        public static string GetTrimName(string name)
        {
            return name.Trim(NAME_DELIMETER);
        }

        /// <summary>
        /// 获取头尾带界定符的人物名
        /// </summary>
        /// <param name="name">人物名</param>
        /// <returns>人物名</returns>
        public static string GetSettingName(string name)
        {
            return NAME_DELIMETER + GetTrimName(name) + NAME_DELIMETER;
        }

        /// <summary>
        /// 获取cns文件绝对路径
        /// </summary>
        /// <param name="defPath">def文件绝对路径</param>
        /// <returns>cns文件绝对路径</returns>
        public static string GetCnsPath(string defPath)
        {
            try
            {
                IniFiles ini = new IniFiles(defPath);
                return Tools.GetFileDirName(defPath) + ini.ReadString(FILES_SECTION, CNS_ITEM, "");
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 批量写入人物设置
        /// </summary>
        /// <param name="defList">def文件绝对路径列表</param>
        /// <param name="curChar">MUGEN人物类</param>
        /// <returns>修改成功总数</returns>
        public static int WriteMultiCharSet(StringCollection defList, Character curChar)
        {
            int total = 0;
            IniFiles ini;
            foreach (string path in defList)
            {
                if (!File.Exists(path)) continue;
                string cnsPath;
                try
                {
                    ini = new IniFiles(path);
                    cnsPath = Tools.GetFileDirName(path) + ini.ReadString(FILES_SECTION, CNS_ITEM, "");
                }
                catch (ApplicationException)
                {
                    continue;
                }
                if (!File.Exists(cnsPath)) continue;
                if (WriteMultiCnsSet(cnsPath, curChar)) total++;
            }
            return total;
        }

        /// <summary>
        /// 批量写入人物属性设置
        /// </summary>
        /// <param name="cnsPath">cns文件绝对路径</param>
        /// <param name="curChar">MUGEN人物类</param>
        /// <returns>修改成功总数</returns>
        protected static bool WriteMultiCnsSet(string cnsPath, Character curChar)
        {
            try
            {
                IniFiles ini = new IniFiles(cnsPath);
                if (curChar.Life != 0) ini.WriteInteger(DATA_SECTION, LIFE_ITEM, curChar.Life);
                if (curChar.Attack != 0) ini.WriteInteger(DATA_SECTION, ATTACK_ITEM, curChar.Attack);
                if (curChar.Defence != 0) ini.WriteInteger(DATA_SECTION, DEFENCE_ITEM, curChar.Defence);
                if (curChar.Power != 0) ini.WriteInteger(DATA_SECTION, POWER_ITEM, curChar.Power);
                return true;
            }
            catch (ApplicationException)
            {
                return false;
            }
        }

        /// <summary>
        /// 批量备份人物设置
        /// </summary>
        /// <param name="defList">def文件绝对路径列表</param>
        /// <returns>备份成功总数</returns>
        public static int BackupMultiCharSet(StringCollection defList)
        {
            int total = 0;
            IniFiles ini;
            foreach (string path in defList)
            {
                try
                {
                    if (!File.Exists(path)) continue;
                    ini = new IniFiles(path);
                    string cnsPath = Tools.GetFileDirName(path) + ini.ReadString(FILES_SECTION, CNS_ITEM, "");
                    if (!File.Exists(cnsPath)) continue;
                    File.Copy(path, path + BAK_EXT, true);
                    File.Copy(cnsPath, cnsPath + BAK_EXT, true);
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
        /// 批量还原人物设置
        /// </summary>
        /// <param name="defList">def文件绝对路径列表</param>
        /// <returns>还原成功总数</returns>
        public static int RestoreMultiCharSet(StringCollection defList)
        {
            int total = 0;
            IniFiles ini;
            foreach (string path in defList)
            {
                try
                {
                    if (!File.Exists(path + BAK_EXT)) continue;
                    ini = new IniFiles(path);
                    string cnsPath = Tools.GetFileDirName(path) + ini.ReadString(FILES_SECTION, CNS_ITEM, "");
                    if (!File.Exists(cnsPath + BAK_EXT)) continue;
                    File.Copy(path + BAK_EXT, path, true);
                    File.Copy(cnsPath + BAK_EXT, cnsPath, true);
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
        /// <param name="defList">def文件绝对路径列表</param>
        /// <returns>删除成功总数</returns>
        public static int DeleteMultiChar(StringCollection defList)
        {
            int total = 0;
            foreach (string path in defList)
            {
                try
                {
                    if (!File.Exists(path)) continue;
                    File.Copy(path, path + DEL_EXT, true);
                    File.Delete(path);
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
}
