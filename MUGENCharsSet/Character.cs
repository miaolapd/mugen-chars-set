using System;
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
    public class Character :CharacterBase
    {
        #region 类常量

        public const string PAL_ITEM_PREFIX = "pal";    //pal配置项前缀名
        public const string ACT_EXT = ".act";   //act文件扩展名

        #endregion

        #region 类私有成员

        protected NameValueCollection _palList;

        #endregion

        #region 类属性

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
        /// 类构造函数
        /// </summary>
        /// <param name="defPath">def文件绝对路径</param>
        public Character(string defPath) : base(defPath)
        {
            try
            {
                ReadPalSet();
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        #region 类方法

        /// <summary>
        /// 读取Pal设置
        /// </summary>
        protected void ReadPalSet()
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
        /// 扫描当前人物文件夹下所有act文件
        /// </summary>
        /// <param name="actArr">act文件相对路径列表</param>
        /// <param name="dir">act文件夹绝对路径</param>
        protected void ScanActList(StringCollection actArr, string dir)
        {
            if (!Directory.Exists(dir)) return;
            string[] tempPalFiles = Directory.GetFiles(dir, "*" + ACT_EXT);
            for (int i = 0; i < tempPalFiles.Length; i++)
            {
                tempPalFiles[i] = Tools.GetSlashPath(tempPalFiles[i].Substring(Tools.GetFileDirName(DefPath).Length));
            }
            actArr.AddRange(tempPalFiles);
            string[] tempDirs = Directory.GetDirectories(dir);
            foreach (string tempDir in tempDirs)
            {
                ScanActList(actArr, tempDir);
            }
            return;
        }

        /// <summary>
        /// 写入人物设置
        /// </summary>
        public void WriteCharSet()
        {
            try
            {
                IniFiles ini = new IniFiles(DefPath);
                ini.WriteString(INFO_SECTION, NAME_ITEM, GetSettingName(Name));
                ini.WriteString(INFO_SECTION, DISPLAYNAME_ITEM, GetSettingName(DisplayName));
                foreach (string key in PalList)
                {
                    ini.WriteString(FILES_SECTION, key, PalList[key]);
                }
                string cnsPath = Tools.GetFileDirName(DefPath) + Cns;
                if (!File.Exists(cnsPath)) throw (new ApplicationException("cns文件不存在！"));
                WriteCnsSet(cnsPath);
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
        protected void WriteCnsSet(string cnsPath)
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
        public void BackupCharSet()
        {
            try
            {
                if (!File.Exists(DefPath)) throw (new ApplicationException("def文件不存在！"));
                string cnsPath = Tools.GetFileDirName(DefPath) + Cns;
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
        public void RestoreCharSet()
        {
            try
            {
                if (!File.Exists(DefPath + BAK_EXT)) throw (new ApplicationException("def备份文件不存在！"));
                string cnsPath = Tools.GetFileDirName(DefPath) + Cns;
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
        /// 删除当前人物(将def文件重命名为带特定后缀名的文件)
        /// </summary>
        public void DeleteChar()
        {
            if (!File.Exists(DefPath)) throw (new ApplicationException("def文件不存在！"));
            try
            {
                File.Copy(DefPath, DefPath + DEL_EXT, true);
                File.Delete(DefPath);
            }
            catch(Exception)
            {
                throw (new ApplicationException("人物删除失败！"));
            }
        }

        #endregion
    }
}
