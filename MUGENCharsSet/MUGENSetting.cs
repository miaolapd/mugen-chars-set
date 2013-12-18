using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MUGENCharsSet
{
    /// <summary>
    /// MUGEN程序设置类
    /// </summary>
    public class MUGENSetting
    {
        #region 类常量

        /// <summary>人物文件夹相对路径</summary>
        public const string CharsDir = @"chars\";
        /// <summary>Data文件夹相对路径</summary>
        public const string DataDir = @"data\";
        /// <summary>mugen.cfg文件名</summary>
        public const string MugenCfgFileName = "mugen.cfg";

        public static class SettingInfo
        {
            /// <summary>Options配置分段</summary>
            public const string OptionsSection = "Options";
            /// <summary>Files配置分段</summary>
            public const string FilesSection = "Files";
            /// <summary>system.def文件相对路径配置项</summary>
            public const string MotifItem = "motif";
            /// <summary>select.def文件相对路径配置项</summary>
            public const string SelectItem = "select";
        }

        #endregion

        #region 类私有成员

        private readonly string _mugenExePath;
        private readonly string _mugenCfgPath;

        #endregion

        #region 类属性

        /// <summary>
        /// 获取MUGEN程序绝对路径
        /// </summary>
        private string MugenExePath
        {
            get { return _mugenExePath; }
        }

        /// <summary>
        /// 获取MUGEN程序根目录绝对路径
        /// </summary>
        public string MugenDirPath
        {
            get { return Tools.GetFileDirName(MugenExePath); }
        }
        
        /// <summary>
        /// 获取MUGEN Data文件夹绝对路径
        /// </summary>
        public string MugenDataDirPath
        {
            get { return MugenDirPath + DataDir; }
        }

        /// <summary>
        /// 获取MUGEN人物文件夹绝对路径
        /// </summary>
        public string MugenCharsDirPath
        {
            get { return MugenDirPath + CharsDir; }
        }

        /// <summary>
        /// 获取mugen.cfg文件绝对路径
        /// </summary>
        public string MugenCfgPath
        {
            get { return _mugenCfgPath; }
        }

        #endregion

        /// <summary>
        /// 类构造方法
        /// </summary>
        /// <param name="mugenExePath">MUGEN程序绝对路径</param>
        /// <exception cref="System.ApplicationException"></exception>
        public MUGENSetting(string mugenExePath)
        {
            if (!File.Exists(mugenExePath)) throw new ApplicationException("MUGEN程序不存在！");
            _mugenExePath = mugenExePath;
            _mugenCfgPath = MugenDataDirPath + MugenCfgFileName;
            if (!File.Exists(MugenCfgPath)) throw new ApplicationException("mugen.cfg文件不存在！");
        }

        #region 类方法

        /// <summary>
        /// 获取system.def文件绝对路径
        /// </summary>
        /// <returns>system.def文件绝对路径</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string GetSystemDefPath()
        {
            if (!File.Exists(MugenCfgPath)) throw new ApplicationException("mugen.cfg文件不存在！");
            try
            {
                IniFiles ini = new IniFiles(MugenCfgPath);
                return MugenDirPath + ini.ReadString(SettingInfo.OptionsSection, SettingInfo.MotifItem, "");
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("mugen.cfg文件读取失败！");
            }
        }

        /// <summary>
        /// 设置system.def文件绝对路径
        /// </summary>
        /// <param name="systemDefPath">system.def文件绝对路径</param>
        /// <exception cref="System.ApplicationException"></exception>
        public void SetSystemDefPath(string systemDefPath)
        {
            if (!File.Exists(MugenCfgPath)) throw new ApplicationException("mugen.cfg文件不存在！");
            try
            {
                IniFiles ini = new IniFiles(MugenCfgPath);
                ini.WriteString(SettingInfo.OptionsSection, SettingInfo.MotifItem, Tools.GetSlashPath(systemDefPath.Substring(MugenDirPath.Length)));
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("mugen.cfg文件读取失败！");
            }
        }

        /// <summary>
        /// 获取select.def文件绝对路径
        /// </summary>
        /// <returns>select.def文件绝对路径</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string GetSelectDefPath()
        {
            string systemDefPath;
            try
            {
                systemDefPath = GetSystemDefPath();
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            if (!File.Exists(systemDefPath)) throw new ApplicationException("system.def文件不存在！");
            try
            {
                IniFiles ini = new IniFiles(systemDefPath);
                return Tools.GetFileDirName(systemDefPath) + ini.ReadString(SettingInfo.FilesSection, SettingInfo.SelectItem, "");
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("system.def文件读取失败！");
            }
        }

        /// <summary>
        /// 设置select.def文件绝对路径
        /// </summary>
        /// <param name="selectDefPath">select.def文件绝对路径</param>
        /// <exception cref="System.ApplicationException"></exception>
        public void SetSelectDefPath(string selectDefPath)
        {
            string systemDefPath;
            try
            {
                systemDefPath = GetSystemDefPath();
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            if (!File.Exists(systemDefPath)) throw new ApplicationException("system.def文件不存在！");
            try
            {
                IniFiles ini = new IniFiles(systemDefPath);
                int length = Tools.GetFileDirName(systemDefPath).Length;
                ini.WriteString(SettingInfo.FilesSection, SettingInfo.SelectItem, Tools.GetSlashPath(selectDefPath.Substring(length)));
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("mugen.cfg文件读取失败！");
            }
        }

        #endregion

        #region 类静态方法

        /// <summary>
        /// 获取mugen.cfg文件绝对路径
        /// </summary>
        /// <param name="mugenExePath">MUGEN程序绝对路径</param>
        /// <returns>mugen.cfg文件绝对路径</returns>
        public static string GetMugenCfgPath(string mugenExePath)
        {
            return Tools.GetFileDirName(mugenExePath) + DataDir + MugenCfgFileName;
        }

        #endregion

    }
}
