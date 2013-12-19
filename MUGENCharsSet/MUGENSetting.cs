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

        /// <summary>
        /// MUGEN程序配置信息结构
        /// </summary>
        public struct SettingInfo
        {
            /// <summary>Options配置分段</summary>
            public const string OptionsSection = "Options";
            /// <summary>Files配置分段</summary>
            public const string FilesSection = "Files";
            /// <summary>system.def文件相对路径配置项</summary>
            public const string MotifItem = "motif";
            /// <summary>select.def文件相对路径配置项</summary>
            public const string SelectDefItem = "select";
        }

        #endregion

        #region 类私有成员

        private readonly string _mugenExePath;
        private readonly string _mugenCfgPath;
        private string _systemDefPath = "";
        private string _selectDefPath = "";

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

        /// <summary>
        /// 获取或设置system.def文件绝对路径
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public string SystemDefPath
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
        public string SelectDefPath
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

        #endregion

        /// <summary>
        /// 类构造方法
        /// </summary>
        /// <param name="mugenExePath">MUGEN程序绝对路径</param>
        /// <exception cref="System.ApplicationException"></exception>
        public MUGENSetting(string mugenExePath)
        {
            if (!File.Exists(mugenExePath)) throw new ApplicationException("MUGEN程序不存在！");
            _mugenExePath = Tools.GetBackSlashPath(mugenExePath);
            _mugenCfgPath = MugenDataDirPath + MugenCfgFileName;
            if (!File.Exists(MugenCfgPath)) throw new ApplicationException("mugen.cfg文件不存在！");
        }

        #region 类方法

        /// <summary>
        /// 读取MUGEN程序设置
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public void ReadMugenSetting()
        {
            if (!File.Exists(MugenCfgPath)) throw new ApplicationException("mugen.cfg文件不存在！");
            IniFiles ini = new IniFiles(MugenCfgPath);
            _systemDefPath = MugenDirPath + Tools.GetBackSlashPath(ini.ReadString(SettingInfo.OptionsSection, SettingInfo.MotifItem, ""));
            if (SystemDefPath == String.Empty) throw new ApplicationException("mugen.cfg文件读取失败！");
            if (!File.Exists(SystemDefPath)) throw new ApplicationException("system.def文件不存在！");
            ini = new IniFiles(SystemDefPath);
            string selectDefFileName = ini.ReadString(SettingInfo.FilesSection, SettingInfo.SelectDefItem, "");
            if (selectDefFileName == String.Empty) throw new ApplicationException("system.def文件读取失败！");
            _selectDefPath = GetSelectDefExistPath(selectDefFileName);
            if (SelectDefPath == String.Empty) throw new ApplicationException("select.def文件不存在！");
        }

        /// <summary>
        /// 获取可用的select.def文件绝对路径
        /// </summary>
        /// <param name="selectDefFileName">select.def文件相对路径</param>
        /// <returns>select.def文件绝对路径</returns>
        public string GetSelectDefExistPath(string selectDefFileName)
        {
            if (SystemDefPath == String.Empty) return "";
            string path = Tools.GetBackSlashPath(Tools.GetFileDirName(SystemDefPath) + selectDefFileName);
            if (File.Exists(path)) return path;
            path = Tools.GetBackSlashPath(MugenDataDirPath + selectDefFileName);
            if (File.Exists(path)) return path;
            path = Tools.GetBackSlashPath(MugenDirPath + selectDefFileName);
            if (File.Exists(path)) return path;
            else return "";
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
