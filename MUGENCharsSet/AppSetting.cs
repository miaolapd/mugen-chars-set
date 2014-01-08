using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MUGENCharsSet
{
    /// <summary>
    /// 程序配置类
    /// </summary>
    public static class AppSetting
    {
        #region 类常量

        /// <summary>程序配置文件扩展名</summary>
        public const string IniExt = ".ini";
        /// <summary>默认文本编辑器路径</summary>
        public const string DefaultEditProgramPath = "notepad.exe";

        /// <summary>
        /// 程序配置信息结构
        /// </summary>
        public struct SettingInfo
        {
            /// <summary>Data配置分段</summary>
            public const string DataSection = "Data";
            /// <summary>MUGEN程序绝对路径配置项</summary>
            public const string MugenPathItem = "MugenPath";
            /// <summary>自动排序配置项</summary>
            public const string AutoSortItem = "AutoSort";
            /// <summary>文本编辑器配置项</summary>
            public const string EditProgramPathItem = "EditProgramPath";
            /// <summary>读取人物列表类型配置项</summary>
            public const string ReadCharacterTypeItem = "ReadCharacterType";
        }

        /// <summary>
        /// 人物列表读取方式类型枚举
        /// </summary>
        public enum ReadCharTypeEnum { SelectDef = 0, CharsDir = 1 };

        #endregion

        #region 类私有成员

        private static string _iniPath;
        private static string _mugenExePath = "";
        private static bool _autoSort = false;
        private static ReadCharTypeEnum _readCharacterType = ReadCharTypeEnum.SelectDef;
        private static string _editProgramPath = DefaultEditProgramPath;

        #endregion

        #region 类属性

        /// <summary>
        /// 获取程序配置文件绝对路径
        /// </summary>
        public static string IniPath
        {
            get
            {
                return _iniPath;
            }
        }

        /// <summary>
        /// 获取或设置MUGEN程序绝对路径
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static string MugenExePath
        {
            get { return _mugenExePath; }
            set
            {
                if (value == String.Empty) throw new ApplicationException("路径不得为空！");
                if (Path.GetExtension(value) != ".exe") throw new ApplicationException("必须为可执行程序！");
                _mugenExePath = value;
                WriteSetting(SettingInfo.DataSection, SettingInfo.MugenPathItem, value);
            }
        }

        /// <summary>
        /// 获取或设置人物列表是否自动排列
        /// </summary>
        public static bool AutoSort
        {
            get { return _autoSort; }
            set
            {
                _autoSort = value;
                WriteSetting(SettingInfo.DataSection, SettingInfo.AutoSortItem, value ? "1" : "0");
            }
        }

        /// <summary>
        /// 获取或设置人物列表读取方式
        /// </summary>
        public static ReadCharTypeEnum ReadCharacterType
        {
            get { return _readCharacterType; }
            set
            {
                _readCharacterType = value;
                WriteSetting(SettingInfo.DataSection, SettingInfo.ReadCharacterTypeItem, ((int)value).ToString());
            }
        }

        /// <summary>
        /// 获取或设置文本编辑器路径
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static string EditProgramPath
        {
            get { return _editProgramPath; }
            set
            {
                if (value == String.Empty) throw new ApplicationException("路径不得为空！");
                if (Path.GetExtension(value) != ".exe") throw new ApplicationException("必须为可执行程序！");
                _editProgramPath = value;
                WriteSetting(SettingInfo.DataSection, SettingInfo.EditProgramPathItem, value);
            }
        }

        #endregion

        #region 类方法

        /// <summary>
        /// 初始化方法
        /// </summary>
        public static void Init()
        {
            Init(Tools.GetFormatDirPath(Directory.GetParent(System.Windows.Forms.Application.UserAppDataPath).FullName) +
                System.Windows.Forms.Application.ProductName + IniExt);
        }

        /// <summary>
        /// 初始化方法
        /// </summary>
        /// <param name="iniPath">程序配置文件绝对路径</param>
        public static void Init(string iniPath)
        {
            _iniPath = iniPath;
            try
            {
                IniFiles ini = new IniFiles(IniPath);
                MugenExePath = Tools.GetBackSlashPath(ini.ReadString(SettingInfo.DataSection, SettingInfo.MugenPathItem, ""));
                if (ini.ReadInteger(SettingInfo.DataSection, SettingInfo.AutoSortItem, 0) == 1)
                {
                    AutoSort = true;
                }
                else
                {
                    AutoSort = false;
                }
                EditProgramPath = ini.ReadString(SettingInfo.DataSection, SettingInfo.EditProgramPathItem, DefaultEditProgramPath);
                if (ini.ReadInteger(SettingInfo.DataSection, SettingInfo.ReadCharacterTypeItem, 0) == 1)
                {
                    ReadCharacterType = ReadCharTypeEnum.CharsDir;
                }
                else
                {
                    ReadCharacterType = ReadCharTypeEnum.SelectDef;
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 写入程序配置
        /// </summary>
        /// <param name="section">配置分段</param>
        /// <param name="item">配置项</param>
        /// <param name="value">配置值</param>
        /// <returns>是否写入成功</returns>
        private static bool WriteSetting(string section, string item, string value)
        {
            try
            {
                IniFiles ini = new IniFiles(IniPath);
                ini.WriteString(section, item, value);
            }
            catch (ApplicationException)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
