using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Specialized;

namespace MUGENCharsSet
{
    /// <summary>
    /// MUGEN人物类
    /// </summary>
    public class Character
    {
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
        public const string PAL_ITEM_PREFIX = "pal";    //pal配置项前缀名
        public const string ACT_EXT = ".act";   //act文件扩展名
        public const string DEF_EXT = ".def";   //def文件扩展名
        public const string BAK_EXT = ".bak";   //备份文件扩展名

        private string _defPath;
        private string _name;
        private string _displayName;
        private int _life;
        private int _attack;
        private int _defence;
        private int _power;
        private string _cns;
        private NameValueCollection _palList;

        /// <summary>
        /// 获取或设置def文件绝对路径
        /// </summary>
        public string DefPath
        {
            get { return _defPath; }
            set { _defPath = value; }
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

        /// <summary>
        /// 获取或设置cns相对路径
        /// </summary>
        public string Cns
        {
            get { return _cns; }
            set { _cns = value; }
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
        /// 获取或设置当前所有可用的act文件相对路径列表
        /// </summary>
        public string[] AllActFileList
        {
            get
            {
                string path = Tools.getFileDirPath(DefPath);
                if (!Directory.Exists(path)) return null;
                StringCollection actArr = new StringCollection();
                scanActList(actArr, path);
                string[] tempActList = new string[actArr.Count];
                actArr.CopyTo(tempActList, 0);
                return tempActList;
            }
        }

        public Character()
            : this(0, 0, 0, 0)
        {

        }

        public Character(int intLife, int intAttack, int intDefence, int intPower)
            : this("", "", "", intLife, intAttack, intDefence, intPower, "", null)
        {

        }

        public Character(string defPath, string name, string displayName, int life, int attack, int defence, int power,
            string cns, NameValueCollection palList)
        {
            DefPath = defPath;
            Name = name;
            DisplayName = displayName;
            Life = life;
            Attack = attack;
            Defence = defence;
            Power = power;
            Cns = cns;
            PalList = palList;
        }

        /// <summary>
        /// 类构造函数
        /// </summary>
        /// <param name="defPath">def文件绝对路径</param>
        public Character(string defPath)
        {
            try
            {
                DefPath = defPath;
                if (!File.Exists(DefPath)) throw (new ApplicationException("def文件不存在！"));
                IniFiles ini = new IniFiles(DefPath);
                Name = getTrimName(ini.ReadString(INFO_SECTION, NAME_ITEM, ""));
                DisplayName = getTrimName(ini.ReadString(INFO_SECTION, DISPLAYNAME_ITEM, ""));
                Cns = ini.ReadString(FILES_SECTION, CNS_ITEM, "");
                readPalSet();
                string cnsPath = Tools.getFileDirPath(DefPath) + Cns;
                if (!File.Exists(cnsPath)) throw (new ApplicationException("cns文件不存在！"));
                readCnsSet(cnsPath);
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取Pal设置
        /// </summary>
        private void readPalSet()
        {
            try
            {
                IniFiles ini = new IniFiles(DefPath);
                NameValueCollection tempDict = new NameValueCollection();
                ini.ReadSectionValues(FILES_SECTION, tempDict);
                if (tempDict.Count == 0) throw (new ApplicationException("pal属性不存在！"));
                PalList = new NameValueCollection();
                foreach (string key in tempDict)
                {
                    if (key.IndexOf(PAL_ITEM_PREFIX, StringComparison.CurrentCultureIgnoreCase) == 0) PalList.Add(key, tempDict[key]);
                }
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
        private void readCnsSet(string cnsPath)
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

        /// <summary>
        /// 扫描当前人物文件夹下所有act文件
        /// </summary>
        /// <param name="actArr">act文件相对路径列表</param>
        /// <param name="dir">act文件夹绝对路径</param>
        private void scanActList(StringCollection actArr, string dir)
        {
            if (!Directory.Exists(dir)) return;
            string[] tempPalFiles = Directory.GetFiles(dir, "*" + ACT_EXT);
            for (int i = 0; i < tempPalFiles.Length; i++)
            {
                tempPalFiles[i] = Tools.getSlashPath(tempPalFiles[i].Substring(Tools.getFileDirPath(DefPath).Length));
            }
            actArr.AddRange(tempPalFiles);
            string[] tempDirs = Directory.GetDirectories(dir);
            foreach (string tempDir in tempDirs)
            {
                scanActList(actArr, tempDir);
            }
            return;
        }

        /// <summary>
        /// 写入人物设置
        /// </summary>
        public void writeCharSet()
        {
            try
            {
                IniFiles ini = new IniFiles(DefPath);
                ini.WriteString(INFO_SECTION, NAME_ITEM, getSettingName(Name));
                ini.WriteString(INFO_SECTION, DISPLAYNAME_ITEM, getSettingName(DisplayName));
                foreach (string key in PalList)
                {
                    ini.WriteString(FILES_SECTION, key, PalList[key]);
                }
                string cnsPath = Tools.getFileDirPath(DefPath) + Cns;
                if (!File.Exists(cnsPath)) throw (new ApplicationException("cns文件不存在！"));
                writeCnsSet(cnsPath);
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 写入人物属性设置
        /// </summary>
        /// <param name="cnsPath">cns文件绝对路径</param>
        private void writeCnsSet(string cnsPath)
        {
            try
            {
                IniFiles ini = new IniFiles(cnsPath);
                if (Life != 0) ini.WriteInteger(DATA_SECTION, LIFE_ITEM, Life);
                if (Attack != 0) ini.WriteInteger(DATA_SECTION, ATTACK_ITEM, Attack);
                if (Defence != 0) ini.WriteInteger(DATA_SECTION, DEFENCE_ITEM, Defence);
                if (Power != 0) ini.WriteInteger(DATA_SECTION, POWER_ITEM, Power);
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 备份当前人物列表
        /// </summary>
        public void backupCharSet()
        {
            try
            {
                if (!File.Exists(DefPath)) throw (new ApplicationException("def文件不存在！"));
                string cnsPath = Tools.getFileDirPath(DefPath) + Cns;
                if (!File.Exists(cnsPath)) throw (new ApplicationException("cns文件不存在！"));
                File.Copy(DefPath, DefPath + BAK_EXT, true);
                File.Copy(cnsPath, cnsPath + BAK_EXT, true);
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw (new ApplicationException("文件备份失败！"));
            }
        }

        /// <summary>
        /// 还原当前人物列表
        /// </summary>
        public void restoreCharSet()
        {
            try
            {
                if (!File.Exists(DefPath + BAK_EXT)) throw (new ApplicationException("def备份文件不存在！"));
                string cnsPath = Tools.getFileDirPath(DefPath) + Cns;
                if (!File.Exists(cnsPath + BAK_EXT)) throw (new ApplicationException("cns备份文件不存在！"));
                File.Copy(DefPath + BAK_EXT, DefPath, true);
                File.Copy(cnsPath + BAK_EXT, cnsPath, true);
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw (new ApplicationException("文件恢复失败！"));
            }
        }

        /// <summary>
        /// 获取去除界定符的人物名
        /// </summary>
        /// <param name="name">人物名</param>
        /// <returns>人物名</returns>
        public static string getTrimName(string name)
        {
            return name.Trim(NAME_DELIMETER);
        }

        /// <summary>
        /// 获取头尾带界定符的人物名
        /// </summary>
        /// <param name="name">人物名</param>
        /// <returns>人物名</returns>
        public static string getSettingName(string name)
        {
            return NAME_DELIMETER + getTrimName(name) + NAME_DELIMETER;
        }

        /// <summary>
        /// 获取cns文件绝对路径
        /// </summary>
        /// <param name="defPath">def文件绝对路径</param>
        /// <returns>cns文件绝对路径</returns>
        public static string getCnsPath(string defPath)
        {
            try
            {
                IniFiles ini = new IniFiles(defPath);
                return Tools.getFileDirPath(defPath) + ini.ReadString(FILES_SECTION, CNS_ITEM, "");
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
        public static int writeMultiCharSet(StringCollection defList, Character curChar)
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
                    cnsPath = Tools.getFileDirPath(path) + ini.ReadString(FILES_SECTION, CNS_ITEM, "");
                }
                catch (ApplicationException)
                {
                    continue;
                }
                if (!File.Exists(cnsPath)) continue;
                if (writeMultiCnsSet(cnsPath, curChar)) total++;
            }
            return total;
        }

        /// <summary>
        /// 批量写入人物属性设置
        /// </summary>
        /// <param name="cnsPath">cns文件绝对路径</param>
        /// <param name="curChar">MUGEN人物类</param>
        /// <returns>修改成功总数</returns>
        private static bool writeMultiCnsSet(string cnsPath, Character curChar)
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
        public static int backupMultiCharSet(StringCollection defList)
        {
            int total = 0;
            IniFiles ini;
            foreach (string path in defList)
            {
                try
                {
                    if (!File.Exists(path)) continue;
                    ini = new IniFiles(path);
                    string cnsPath = Tools.getFileDirPath(path) + ini.ReadString(FILES_SECTION, CNS_ITEM, "");
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
        public static int restoreMultiCharSet(StringCollection defList)
        {
            int total = 0;
            IniFiles ini;
            foreach (string path in defList)
            {
                try
                {
                    if (!File.Exists(path + BAK_EXT)) continue;
                    ini = new IniFiles(path);
                    string cnsPath = Tools.getFileDirPath(path) + ini.ReadString(FILES_SECTION, CNS_ITEM, "");
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
    }
}
