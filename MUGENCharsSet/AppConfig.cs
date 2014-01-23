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
    public static class AppConfig
    {
        /// <summary>配置文件名</summary>
        private const string ConfigFileName = "AppConfig.xml";
        /// <summary>默认文本编辑器路径</summary>
        public const string DefaultEditProgramPath = "notepad.exe";

        /// <summary>
        /// 程序配置信息结构
        /// </summary>
        public struct ConfigInfo
        {
            /// <summary>MUGEN程序绝对路径元素名</summary>
            public const string MugenExePath = "mugenExePath";
            /// <summary>自动排序元素名</summary>
            public const string AutoSort = "autoSort";
            /// <summary>文本编辑器元素名</summary>
            public const string EditProgramPath = "editProgramPath";
            /// <summary>读取人物列表类型元素名</summary>
            public const string ReadCharacterType = "readCharacterType";
            /// <summary>显示人物宽/普屏标记元素名</summary>
            public const string ShowCharacterScreenMark = "showCharacterScreenMark";
        }

        /// <summary>
        /// 人物列表读取方式类型枚举
        /// </summary>
        public enum ReadCharTypeEnum { SelectDef = 0, CharsDir = 1 };

        /// <summary>当前<see cref="XmlConfig"/>对象</summary>
        private static XmlConfig Config = null;
        private static string _mugenExePath = "";
        private static bool _autoSort = false;
        private static ReadCharTypeEnum _readCharacterType = ReadCharTypeEnum.SelectDef;
        private static string _editProgramPath = DefaultEditProgramPath;
        private static bool _showCharacterScreenMark = false;

        /// <summary>
        /// 获取配置文件绝对路径
        /// </summary>
        public static string ConfigPath
        {
            get
            {
                return Tools.AppDirPath + ConfigFileName;
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
                if (Config != null) Config.SetValue(ConfigInfo.MugenExePath, value);
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
                if (Config != null) Config.SetValue(ConfigInfo.AutoSort, value);
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
                if (Config != null) Config.SetValue(ConfigInfo.ReadCharacterType, (int)value);
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
                if (Config != null) Config.SetValue(ConfigInfo.EditProgramPath, value);
            }
        }

        /// <summary>
        /// 获取或设置是否显示人物宽/普屏标记
        /// </summary>
        public static bool ShowCharacterScreenMark
        {
            get { return _showCharacterScreenMark; }
            set
            {
                _showCharacterScreenMark = value;
                if (Config != null) Config.SetValue(ConfigInfo.ShowCharacterScreenMark, value);
            }
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns>是否读取成功</returns>
        public static bool Read()
        {
            try
            {
                Config = new XmlConfig(ConfigPath, true);
            }
            catch (ApplicationException)
            {
                return false;
            }
            _mugenExePath = Config.GetValue(ConfigInfo.MugenExePath, "").GetBackSlashPath();
            _autoSort = Config.GetValue(ConfigInfo.AutoSort, false);
            _editProgramPath = Config.GetValue(ConfigInfo.EditProgramPath, DefaultEditProgramPath);
            _readCharacterType = Config.GetValue(ConfigInfo.EditProgramPath, 0) == 1 ?
                ReadCharTypeEnum.CharsDir : ReadCharTypeEnum.SelectDef;
            _showCharacterScreenMark = Config.GetValue(ConfigInfo.ShowCharacterScreenMark, false);
            return true;
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <returns>是否保存成功</returns>
        public static bool Save()
        {
            if (Config != null) return Config.Save();
            else return false;
        }
    }
}
