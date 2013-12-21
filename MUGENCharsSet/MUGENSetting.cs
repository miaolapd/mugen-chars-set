using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace MUGENCharsSet
{
    /// <summary>
    /// MUGEN程序设置类
    /// </summary>
    public static class MugenSetting
    {
        #region 类常量

        /// <summary>人物文件夹相对路径</summary>
        public const string CharsDir = @"chars\";
        /// <summary>Data文件夹相对路径</summary>
        public const string DataDir = @"data\";
        /// <summary>mugen.cfg文件名</summary>
        public const string MugenCfgFileName = "mugen.cfg";
        /// <summary>公共stcommon文件名</summary>
        public const string StcommonFileName = "common1.cns";

        /// <summary>
        /// MUGEN程序配置信息结构
        /// </summary>
        public struct SettingInfo
        {
            /// <summary>Options配置分段</summary>
            public const string OptionsSection = "Options";
            /// <summary>Info配置分段</summary>
            public const string InfoSection = "Info";
            /// <summary>Files配置分段</summary>
            public const string FilesSection = "Files";
            /// <summary>system.def文件相对路径配置项</summary>
            public const string MotifItem = "motif";
            /// <summary>select.def文件相对路径配置项</summary>
            public const string SelectDefItem = "select";
            /// <summary>系统localcoord配置项</summary>
            public const string LocalcoordItem = "localcoord";
        }

        #endregion

        #region 类私有成员

        private static string _mugenExePath;
        private static string _mugenCfgPath;
        private static string _systemDefPath = "";
        private static string _selectDefPath = "";
        private static Size _localcoord = new Size();
        private static bool _isWideScreen = false;

        #endregion

        #region 类属性

        /// <summary>
        /// 获取MUGEN程序绝对路径
        /// </summary>
        private static string MugenExePath
        {
            get { return _mugenExePath; }
        }

        /// <summary>
        /// 获取MUGEN程序根目录绝对路径
        /// </summary>
        public static string MugenDirPath
        {
            get { return Tools.GetFileDirName(MugenExePath); }
        }
        
        /// <summary>
        /// 获取MUGEN Data文件夹绝对路径
        /// </summary>
        public static string MugenDataDirPath
        {
            get { return MugenDirPath + DataDir; }
        }

        /// <summary>
        /// 获取MUGEN人物文件夹绝对路径
        /// </summary>
        public static string MugenCharsDirPath
        {
            get { return MugenDirPath + CharsDir; }
        }

        /// <summary>
        /// 获取mugen.cfg文件绝对路径
        /// </summary>
        public static string MugenCfgPath
        {
            get { return _mugenCfgPath; }
        }

        /// <summary>
        /// 获取或设置system.def文件绝对路径
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static string SystemDefPath
        {
            get { return _systemDefPath; }
            set
            {
                if (value == String.Empty) throw new ApplicationException("路径不得为空！");
                if (!File.Exists(MugenCfgPath)) throw new ApplicationException("mugen.cfg文件不存在！");
                try
                {
                    IniFiles ini = new IniFiles(MugenCfgPath);
                    ini.WriteString(SettingInfo.OptionsSection, SettingInfo.MotifItem,
                        Tools.GetSlashPath(value.Substring(MugenDirPath.Length)));
                }
                catch (ApplicationException)
                {
                    throw new ApplicationException("mugen.cfg文件写入失败！");
                }
                _systemDefPath = value;
            }
        }

        /// <summary>
        /// 获取或设置select.def文件绝对路径
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static string SelectDefPath
        {
            get { return _selectDefPath; }
            set
            {
                if (value == String.Empty) throw new ApplicationException("路径不得为空！");
                if (!File.Exists(SystemDefPath)) throw new ApplicationException("system.def文件不存在！");
                try
                {
                    IniFiles ini = new IniFiles(SystemDefPath);
                    ini.WriteString(SettingInfo.FilesSection, SettingInfo.SelectDefItem,
                        Tools.GetSlashPath(value.Substring(MugenDirPath.Length)));
                }
                catch (ApplicationException)
                {
                    throw new ApplicationException("system.def文件写入失败！");
                }
                _selectDefPath = value;
            }
        }

        /// <summary>
        /// 获取或设置系统localcoord
        /// </summary>
        public static Size Localcoord
        {
            get { return _localcoord; }
            private set { _localcoord = value; }
        }

        /// <summary>
        /// 获取或设置系统画面包是否为宽屏
        /// </summary>
        public static bool IsWideScreen
        {
            get { return _isWideScreen; }
            set { _isWideScreen = value; }
        }

        #endregion

        #region 类方法

        /// <summary>
        /// 初始化方法
        /// </summary>
        /// <param name="mugenExePath">MUGEN程序绝对路径</param>
        /// <exception cref="System.ApplicationException"></exception>
        public static void Init(string mugenExePath)
        {
            if (!File.Exists(mugenExePath)) throw new ApplicationException("MUGEN程序不存在！");
            _mugenExePath = Tools.GetBackSlashPath(mugenExePath);
            _mugenCfgPath = MugenDataDirPath + MugenCfgFileName;
            if (!File.Exists(MugenCfgPath))
            {
                _mugenExePath = "";
                _mugenCfgPath = "";
                throw new ApplicationException("mugen.cfg文件不存在！");
            }
        }

        /// <summary>
        /// 读取MUGEN程序设置
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static void ReadMugenSetting()
        {
            if (!File.Exists(MugenCfgPath)) throw new ApplicationException("mugen.cfg文件不存在！");
            IniFiles ini = new IniFiles(MugenCfgPath);
            _systemDefPath = MugenDirPath + Tools.GetBackSlashPath(ini.ReadString(SettingInfo.OptionsSection, SettingInfo.MotifItem, ""));
            if (SystemDefPath == String.Empty) throw new ApplicationException("system.def路径读取失败！");
            if (!File.Exists(SystemDefPath)) throw new ApplicationException("system.def文件不存在！");
            ini = new IniFiles(SystemDefPath);
            string selectDefFileName = ini.ReadString(SettingInfo.FilesSection, SettingInfo.SelectDefItem, "");
            if (selectDefFileName == String.Empty) throw new ApplicationException("select.def路径读取失败！");
            _selectDefPath = Tools.GetIniFileExistPath(SystemDefPath, selectDefFileName);
            if (SelectDefPath == String.Empty) throw new ApplicationException("select.def文件不存在！");
            string localcoord = ini.ReadString(SettingInfo.InfoSection, SettingInfo.LocalcoordItem, "");
            try
            {
                if (localcoord == String.Empty) throw new Exception();
                string[] size = localcoord.Split(',');
                Localcoord = new Size(Convert.ToInt32(size[0]), Convert.ToInt32(size[1]));
            }
            catch (Exception)
            {
                throw new ApplicationException("系统localcoord配置项读取失败！");
            }
            if (Math.Round((decimal)Localcoord.Width / Localcoord.Height, 2) == Math.Round(16m / 9m, 2))
            {
                IsWideScreen = true;
            }
            else
            {
                IsWideScreen = false;
            }
        }

        #endregion

    }
}
