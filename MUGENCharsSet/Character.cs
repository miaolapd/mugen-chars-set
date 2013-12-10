using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Specialized;

namespace MUGENCharsSet
{
    public class Character
    {
        public const char NAME_DELIMETER = '"';
        public const string INFO_SECTION = "Info";
        public const string FILES_SECTION = "Files";
        public const string DATA_SECTION = "Data";
        public const string NAME_ITEM = "name";
        public const string DISPLAYNAME_ITEM = "displayname";
        public const string CNS_ITEM = "cns";
        public const string LIFE_ITEM = "life";
        public const string ATTACK_ITEM = "attack";
        public const string DEFENCE_ITEM = "defence";
        public const string POWER_ITEM = "power";
        public const string PAL_ITEM_PREFIX = "pal";
        public const string ACT_EXT = ".act";
        public const string DEF_EXT = ".def";
        public const string BAK_EXT = ".bak";

        private string defPath;
        private string name;
        private string displayName;
        private int life;
        private int attack;
        private int defence;
        private int power;
        private string cns;
        private NameValueCollection palList;

        public string DefPath
        {
            get { return defPath; }
            set { defPath = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public int Defence
        {
            get { return defence; }
            set { defence = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public string Cns
        {
            get { return cns; }
            set { cns = value; }
        }

        public NameValueCollection PalList
        {
            get { return palList; }
            set { palList = value; }
        }

        public string[] AllActFileList
        {
            get
            {
                string path = Tools.getFileDir(DefPath);
                if (!Directory.Exists(path)) return null;
                StringCollection actArr = new StringCollection();
                getActList(actArr, path);
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

        public Character(string strDefPath, string strName, string strDisplayName, int intLife, int intAttack, int intDefence, int intPower,
            string strCns, NameValueCollection arrPalList)
        {
            DefPath = strDefPath;
            Name = strName;
            DisplayName = strDisplayName;
            Life = intLife;
            Attack = intAttack;
            Defence = intDefence;
            Power = intPower;
            Cns = strCns;
            PalList = arrPalList;
        }

        public Character(string strDefPath)
        {
            try
            {
                DefPath = strDefPath;
                if (!File.Exists(DefPath)) throw (new ApplicationException("def文件不存在！"));
                IniFiles ini = new IniFiles(DefPath);
                Name = getTrimName(ini.ReadString(INFO_SECTION, NAME_ITEM, ""));
                DisplayName = getTrimName(ini.ReadString(INFO_SECTION, DISPLAYNAME_ITEM, ""));
                Cns = ini.ReadString(FILES_SECTION, CNS_ITEM, "");
                readPalSet();
                string cnsPath = Tools.getFileDir(DefPath) + Cns;
                if (!File.Exists(cnsPath)) throw (new ApplicationException("cns文件不存在！"));
                readCnsSet(cnsPath);
            }
            catch(ApplicationException ex)
            {
                throw ex;
            }
        }

        public void readPalSet()
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

        public void readCnsSet(string cnsPath)
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

        public void getActList(StringCollection actArr, string dir)
        {
            if (!Directory.Exists(dir)) return;
            string[] tempPalFiles = Directory.GetFiles(dir, "*" + ACT_EXT);
            for (int i = 0; i < tempPalFiles.Length; i++)
            {
                tempPalFiles[i] = Tools.getSlashDir(tempPalFiles[i].Substring(Tools.getFileDir(DefPath).Length));
            }
            actArr.AddRange(tempPalFiles);
            string[] tempDirs = Directory.GetDirectories(dir);
            foreach (string tempDir in tempDirs)
            {
                getActList(actArr, tempDir);
            }
            return;
        }

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
                string cnsPath = Tools.getFileDir(DefPath) + Cns;
                if (!File.Exists(cnsPath)) throw (new ApplicationException("cns文件不存在！"));
                writeCnsSet(cnsPath);
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        public void writeCnsSet(string cnsPath)
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

        public void backupCharSet()
        {
            try
            {
                if (!File.Exists(DefPath)) throw (new ApplicationException("def文件不存在！"));
                string cnsPath = Tools.getFileDir(DefPath) + Cns;
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

        public void restoreCharSet()
        {
            try
            {
                if (!File.Exists(DefPath + BAK_EXT)) throw (new ApplicationException("def备份文件不存在！"));
                string cnsPath = Tools.getFileDir(DefPath) + Cns;
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

        public static string getTrimName(string strName)
        {
            return strName.Trim(NAME_DELIMETER);
        }

        public static string getSettingName(string strName)
        {
            return NAME_DELIMETER + getTrimName(strName) + NAME_DELIMETER;
        }

        public static string getCnsPath(string strDefPath)
        {
            try
            {
                IniFiles ini = new IniFiles(strDefPath);
                return Tools.getFileDir(strDefPath) + ini.ReadString(FILES_SECTION, CNS_ITEM, "");
            }
            catch(ApplicationException ex)
            {
                throw ex;
            }
        }

        public static int writeMultiCharSet(StringCollection defList ,Character curChar)
        {
            int total = 0;
            IniFiles ini;
            foreach(string path in defList)
            {
                if (!File.Exists(path)) continue;
                string cnsPath;
                try
                {
                    ini = new IniFiles(path);
                    cnsPath = Tools.getFileDir(path) + ini.ReadString(FILES_SECTION, CNS_ITEM, "");
                }
                catch(ApplicationException)
                {
                    continue;
                }
                if (!File.Exists(cnsPath)) continue;
                if (writeMultiCnsSet(cnsPath, curChar)) total++;
            }
            return total;
        }

        public static bool writeMultiCnsSet(string cnsPath, Character curChar)
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
            catch(ApplicationException)
            {
                return false;
            }
        }

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
                    string cnsPath = Tools.getFileDir(path) + ini.ReadString(FILES_SECTION, CNS_ITEM, "");
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
                    string cnsPath = Tools.getFileDir(path) + ini.ReadString(FILES_SECTION, CNS_ITEM, "");
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
