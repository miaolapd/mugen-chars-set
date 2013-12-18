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
        /// <summary>data文件夹相对路径</summary>
        public const string DataDir = @"data\";

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
        private string _systemDefPath;
        private string _selectDefPath;

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

        /// <summary>
        /// 获取或设置system.def文件绝对路径
        /// </summary>
        public string SystemDefPath
        {
            get { return _systemDefPath; }
            set { _systemDefPath = value; }
        }

        /// <summary>
        /// 获取或设置select.def文件绝对路径
        /// </summary>
        public string SelectDefPath
        {
            get { return _selectDefPath; }
            set { _selectDefPath = value; }
        }

        #endregion

        /// <summary>
        /// 类构造方法
        /// </summary>
        /// <param name="mugenExePath">MUGEN程序绝对路径</param>
        /// <exception cref="System.ApplicationException"></exception>
        public MUGENSetting(string mugenExePath)
        {
            if (!File.Exists(mugenExePath)) throw new ApplicationException("无法找到MUGEN程序！");
            _mugenExePath = mugenExePath;
            _mugenCfgPath = MugenDirPath + DataDir + "mugen.cfg";
            if (!File.Exists(MugenCfgPath)) throw new ApplicationException("无法找到mugen.cfg文件！");
            IniFiles ini = new IniFiles(MugenCfgPath);
            SystemDefPath = MugenDirPath + ini.ReadString(SettingInfo.OptionsSection, SettingInfo.MotifItem, "");
            if (!File.Exists(SystemDefPath)) throw new ApplicationException("无法找到system.def文件！");
            ini = new IniFiles(SystemDefPath);
            SelectDefPath = MugenDirPath + DataDir + ini.ReadString(SettingInfo.FilesSection, SettingInfo.SelectItem, "");
            if (!File.Exists(SelectDefPath)) throw new ApplicationException("无法找到select.def文件！");
        }
    }
}
