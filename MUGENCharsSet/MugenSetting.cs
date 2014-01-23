using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MUGENCharsSet
{
    #region MUGEN程序配置类

    /// <summary>
    /// MUGEN程序配置类
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
        /// <summary>备份文件扩展名</summary>
        public const string BakExt = ".bak";

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
            /// <summary>Config配置分段</summary>
            public const string ConfigSection = "Config";
            /// <summary>Video配置分段</summary>
            public const string VideoSection = "Video";
            /// <summary>system.def文件相对路径配置项</summary>
            public const string MotifItem = "motif";
            /// <summary>select.def文件相对路径配置项</summary>
            public const string SelectDefItem = "select";
            /// <summary>fight.def文件相对路径配置项</summary>
            public const string FightDefItem = "fight";
            /// <summary>系统localcoord配置项</summary>
            public const string LocalcoordItem = "localcoord";
            /// <summary>Difficulty配置项</summary>
            public const string DifficultyItem = "Difficulty";
            /// <summary>Life配置项</summary>
            public const string LifeItem = "Life";
            /// <summary>Time配置项</summary>
            public const string TimeItem = "Time";
            /// <summary>GameSpeed配置项</summary>
            public const string GameSpeedItem = "GameSpeed";
            /// <summary>GameSpeed(帧率)配置项</summary>
            public const string GameFrameItem = "GameSpeed";
            /// <summary>Team.1VS2Life配置项</summary>
            public const string Team1VS2LifeItem = "Team.1VS2Life";
            /// <summary>Team.LoseOnKO配置项</summary>
            public const string TeamLoseOnKOItem = "Team.LoseOnKO";
            /// <summary>GameWidth配置项</summary>
            public const string GameWidthItem = "GameWidth";
            /// <summary>GameHeight配置项</summary>
            public const string GameHeightItem = "GameHeight";
            /// <summary>RenderMode配置项</summary>
            public const string RenderModeItem = "RenderMode";
            /// <summary>FullScreen配置项</summary>
            public const string FullScreenItem = "FullScreen";
        }

        /// <summary>
        /// MUGEN程序版本枚举
        /// </summary>
        public enum MugenVersion { WIN, V1_X };

        #endregion

        #region 类私有成员

        private static string _mugenExePath;
        private static string _mugenCfgPath;
        private static string _systemDefPath = "";
        private static string _selectDefPath = "";
        private static string _fightDefPath = "";
        private static Size _localcoord;
        private static bool _isWideScreen = false;
        private static int _difficulty = 0;
        private static int _life = 0;
        private static int _time = 0;
        private static int _gameSpeed = 0;
        private static int _gameFrame = 0;
        private static int _team1VS2Life = 0;
        private static bool _teamLoseOnKO = false;
        private static int _gameWidth = 0;
        private static int _gameHeight = 0;
        private static string _renderMode = "";
        private static bool _fullScreen = false;
        private static KeyPressSetting _keyPressP1;
        private static KeyPressSetting _keyPressP2;
        private static MugenVersion _version = MugenVersion.V1_X;

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
            get { return MugenExePath.GetDirPathOfFile(); }
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
                        value.Substring(MugenDirPath.Length).GetSlashPath());
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
                    string path = GetIniFileBestPath(SystemDefPath, value);
                    if (path == String.Empty) new ApplicationException();
                    ini.WriteString(SettingInfo.FilesSection, SettingInfo.SelectDefItem, path.GetSlashPath());
                }
                catch (ApplicationException)
                {
                    throw new ApplicationException("system.def文件写入失败！");
                }
                _selectDefPath = value;
            }
        }

        /// <summary>
        /// 获取或设置fight.def文件绝对路径
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static string FightDefPath
        {
            get { return _fightDefPath; }
            set
            {
                if (value == String.Empty) throw new ApplicationException("路径不得为空！");
                if (!File.Exists(SystemDefPath)) throw new ApplicationException("system.def文件不存在！");
                try
                {
                    IniFiles ini = new IniFiles(SystemDefPath);
                    string path = GetIniFileBestPath(SystemDefPath, value);
                    if (path == String.Empty) new ApplicationException();
                    ini.WriteString(SettingInfo.FilesSection, SettingInfo.FightDefItem, path.GetSlashPath());
                }
                catch (ApplicationException)
                {
                    throw new ApplicationException("system.def文件写入失败！");
                }
                _fightDefPath = value;
            }
        }

        /// <summary>
        /// 获取或设置系统localcoord
        /// </summary>
        public static Size Localcoord
        {
            get { return _localcoord; }
            set { _localcoord = value; }
        }

        /// <summary>
        /// 获取或设置系统画面包是否为宽屏
        /// </summary>
        public static bool IsWideScreen
        {
            get { return _isWideScreen; }
            set { _isWideScreen = value; }
        }

        /// <summary>
        /// 获取或设置Difficulty
        /// </summary>
        public static int Difficulty
        {
            get { return _difficulty; }
            set { _difficulty = value; }
        }

        /// <summary>
        /// 获取或设置Life
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static int Life
        {
            get { return _life; }
            set
            {
                if (value < 0) throw new ApplicationException("Life不得小于0！");
                _life = value;
            }
        }

        /// <summary>
        /// 获取或设置Time
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static int Time
        {
            get { return _time; }
            set
            {
                if (value < -1) throw new ApplicationException("Time不得小于-1！");
                _time = value;
            }
        }

        /// <summary>
        /// 获取或设置GameSpeed
        /// </summary>
        public static int GameSpeed
        {
            get { return _gameSpeed; }
            set { _gameSpeed = value; }
        }

        /// <summary>
        /// 获取或设置GameSpeed(帧率)
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static int GameFrame
        {
            get { return _gameFrame; }
            set
            {
                if (value < 10) throw new ApplicationException("GameSpeed(帧率)不得小于10！");
                _gameFrame = value;
            }
        }

        /// <summary>
        /// 获取或设置Team1VS2Life
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static int Team1VS2Life
        {
            get { return _team1VS2Life; }
            set
            {
                if (value < 0) throw new ApplicationException("Team1VS2Life不得小于0！");
                _team1VS2Life = value;
            }
        }

        /// <summary>
        /// 获取或设置是否TeamLoseOnKO
        /// </summary>
        public static bool TeamLoseOnKO
        {
            get { return _teamLoseOnKO; }
            set { _teamLoseOnKO = value; }
        }

        /// <summary>
        /// 获取或设置GameWidth
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static int GameWidth
        {
            get { return _gameWidth; }
            set
            {
                if (value <= 0) throw new ApplicationException("GameWidth不得小于1！");
                _gameWidth = value;
            }
        }

        /// <summary>
        /// 获取或设置GameHeight
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static int GameHeight
        {
            get { return _gameHeight; }
            set
            {
                if (value <= 0) throw new ApplicationException("GameHeight不得小于1！");
                _gameHeight = value;
            }
        }

        /// <summary>
        /// 获取或设置RenderMode
        /// </summary>
        public static string RenderMode
        {
            get { return _renderMode; }
            set { _renderMode = value; }
        }

        /// <summary>
        /// 获取或设置是否全屏
        /// </summary>
        public static bool FullScreen
        {
            get { return _fullScreen; }
            set { _fullScreen = value; }
        }

        /// <summary>
        /// 获取或设置P1按键
        /// </summary>
        public static KeyPressSetting KeyPressP1
        {
            get { return _keyPressP1; }
            set { _keyPressP1 = value; }
        }

        /// <summary>
        /// 获取或设置P2按键
        /// </summary>
        public static KeyPressSetting KeyPressP2
        {
            get { return _keyPressP2; }
            set { _keyPressP2 = value; }
        }

        /// <summary>
        /// 获取当前MUGEN程序版本
        /// </summary>
        public static MugenVersion Version
        {
            get { return _version; }
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
            _mugenExePath = mugenExePath.GetBackSlashPath();
            _mugenCfgPath = MugenDataDirPath + MugenCfgFileName;
            if (!File.Exists(MugenCfgPath))
            {
                _mugenExePath = "";
                _mugenCfgPath = "";
                throw new ApplicationException("mugen.cfg文件不存在！");
            }
        }

        /// <summary>
        /// 读取MUGEN程序配置
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static void ReadMugenSetting()
        {
            if (!File.Exists(MugenCfgPath)) throw new ApplicationException("mugen.cfg文件不存在！");
            IniFiles ini = new IniFiles(MugenCfgPath);
            _systemDefPath = MugenDirPath + ini.ReadString(SettingInfo.OptionsSection, SettingInfo.MotifItem, "").GetBackSlashPath();
            if (SystemDefPath == String.Empty) throw new ApplicationException("system.def路径读取失败！");
            if (!File.Exists(SystemDefPath)) throw new ApplicationException("system.def文件不存在！");
            ini = new IniFiles(SystemDefPath);
            string selectDefFileName = ini.ReadString(SettingInfo.FilesSection, SettingInfo.SelectDefItem, "");
            if (selectDefFileName == String.Empty) throw new ApplicationException("select.def路径读取失败！");
            _selectDefPath = GetIniFileExistPath(SystemDefPath, selectDefFileName);
            if (SelectDefPath == String.Empty) throw new ApplicationException("select.def文件不存在！");
            _version = MugenVersion.V1_X;
            string localcoord = ini.ReadString(SettingInfo.InfoSection, SettingInfo.LocalcoordItem, "");
            if (localcoord != String.Empty)
            {
                string[] size = localcoord.Split(',');
                try
                {
                    Localcoord = new Size(Convert.ToInt32(size[0]), Convert.ToInt32(size[1]));
                    if (Math.Round((decimal)Localcoord.Width / Localcoord.Height, 2) == Math.Round(16m / 9m, 2))
                    {
                        IsWideScreen = true;
                    }
                    else
                    {
                        IsWideScreen = false;
                    }
                }
                catch (Exception) { }
            }
            else
            {
                _version = MugenVersion.WIN;
                IsWideScreen = false;
            }
        }

        /// <summary>
        /// 读取mugen.cfg文件配置
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static void ReadMugenCfgSetting()
        {
            if (!File.Exists(MugenCfgPath)) throw new ApplicationException("mugen.cfg文件不存在！");
            try
            {
                IniFiles ini = new IniFiles(MugenCfgPath);
                _difficulty = ini.ReadInteger(SettingInfo.OptionsSection, SettingInfo.DifficultyItem, 1);
                _life = ini.ReadInteger(SettingInfo.OptionsSection, SettingInfo.LifeItem, 100);
                _time = ini.ReadInteger(SettingInfo.OptionsSection, SettingInfo.TimeItem, 100);
                _gameSpeed = ini.ReadInteger(SettingInfo.OptionsSection, SettingInfo.GameSpeedItem, 0);
                _gameFrame = ini.ReadInteger(SettingInfo.ConfigSection, SettingInfo.GameFrameItem, 60);
                _team1VS2Life = ini.ReadInteger(SettingInfo.OptionsSection, SettingInfo.Team1VS2LifeItem, 100);
                _teamLoseOnKO = Convert.ToBoolean(ini.ReadInteger(SettingInfo.OptionsSection, SettingInfo.TeamLoseOnKOItem, 0));
                _gameWidth = ini.ReadInteger(SettingInfo.ConfigSection, SettingInfo.GameWidthItem, 0);
                _gameHeight = ini.ReadInteger(SettingInfo.ConfigSection, SettingInfo.GameHeightItem, 0);
                _renderMode = ini.ReadString(SettingInfo.VideoSection, SettingInfo.RenderModeItem, "");
                _fullScreen = Convert.ToBoolean(ini.ReadInteger(SettingInfo.VideoSection, SettingInfo.FullScreenItem, 0));
            }
            catch (Exception)
            {
                throw new ApplicationException("读取mugen.cfg文件失败！");
            }
            KeyPressP1 = new KeyPressSetting(KeyPressSetting.SettingInfo.P1KeysSection);
            KeyPressP2 = new KeyPressSetting(KeyPressSetting.SettingInfo.P2KeysSection);
        }

        /// <summary>
        /// 保存mugen.cfg文件配置
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static void SaveMugenCfgSetting()
        {
            if (!File.Exists(MugenCfgPath)) throw new ApplicationException("mugen.cfg文件不存在！");
            try
            {
                if (!Tools.SetFileNotReadOnly(MugenCfgPath)) throw new ApplicationException();
                IniFiles ini = new IniFiles(MugenCfgPath);
                ini.WriteInteger(SettingInfo.OptionsSection, SettingInfo.DifficultyItem, Difficulty);
                ini.WriteInteger(SettingInfo.OptionsSection, SettingInfo.LifeItem, Life);
                ini.WriteInteger(SettingInfo.OptionsSection, SettingInfo.TimeItem, Time);
                ini.WriteInteger(SettingInfo.OptionsSection, SettingInfo.GameSpeedItem, GameSpeed);
                ini.WriteInteger(SettingInfo.ConfigSection, SettingInfo.GameFrameItem, GameFrame);
                ini.WriteInteger(SettingInfo.OptionsSection, SettingInfo.Team1VS2LifeItem, Team1VS2Life);
                ini.WriteInteger(SettingInfo.OptionsSection, SettingInfo.TeamLoseOnKOItem, TeamLoseOnKO ? 1 : 0);
                ini.WriteInteger(SettingInfo.VideoSection, SettingInfo.FullScreenItem, FullScreen ? 1 : 0);
                if (Version != MugenVersion.WIN)
                {
                    ini.WriteInteger(SettingInfo.ConfigSection, SettingInfo.GameWidthItem, GameWidth);
                    ini.WriteInteger(SettingInfo.ConfigSection, SettingInfo.GameHeightItem, GameHeight);
                    ini.WriteString(SettingInfo.VideoSection, SettingInfo.RenderModeItem, RenderMode);
                }
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("设置保存失败！");
            }
            KeyPressP1.Save();
            KeyPressP2.Save();
        }

        /// <summary>
        /// 备份mugen.cfg文件
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static void BackupMugenCfgSetting()
        {
            if (!File.Exists(MugenCfgPath)) throw new ApplicationException("mugen.cfg文件不存在！");
            try
            {
                if (!Tools.SetFileNotReadOnly(MugenCfgPath + BakExt)) throw new Exception();
                File.Copy(MugenCfgPath, MugenCfgPath + BakExt, true);
            }
            catch (Exception)
            {
                throw new ApplicationException("文件备份失败！");
            }
        }

        /// <summary>
        /// 还原mugen.cfg文件
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public static void RestoreMugenCfgSetting()
        {
            if (!File.Exists(MugenCfgPath + BakExt)) throw new ApplicationException("备份文件不存在！");
            try
            {
                if (!Tools.SetFileNotReadOnly(MugenCfgPath + BakExt)) throw new Exception();
                if (!Tools.SetFileNotReadOnly(MugenCfgPath)) throw new Exception();
                File.Copy(MugenCfgPath + BakExt, MugenCfgPath, true);
            }
            catch (Exception)
            {
                throw new ApplicationException("文件恢复失败！");
            }
        }

        /// <summary>
        /// 获取MUGEN中可用的配置文件绝对路径
        /// </summary>
        /// <param name="parentFilePath">父配置文件绝对路径</param>
        /// <param name="iniFileName">配置文件相对路径</param>
        /// <returns>配置文件绝对路径</returns>
        public static string GetIniFileExistPath(string parentFilePath, string iniFileName)
        {
            if (parentFilePath == String.Empty) return "";
            string path = (parentFilePath.GetDirPathOfFile() + iniFileName).GetBackSlashPath();
            if (File.Exists(path)) return path;
            path = (MugenSetting.MugenDataDirPath + iniFileName).GetBackSlashPath();
            if (File.Exists(path)) return path;
            path = (MugenSetting.MugenDirPath + iniFileName).GetBackSlashPath();
            if (File.Exists(path)) return path;
            else return "";
        }

        /// <summary>
        /// 获取MUGEN中配置文件最佳的相对路径
        /// </summary>
        /// <param name="parentFilePath">父配置文件绝对路径</param>
        /// <param name="iniFilePath">配置文件绝对路径</param>
        /// <returns>配置文件相对路径</returns>
        public static string GetIniFileBestPath(string parentFilePath, string iniFilePath)
        {
            if (parentFilePath == String.Empty) return "";
            if (iniFilePath == String.Empty) return "";
            parentFilePath = parentFilePath.GetBackSlashPath();
            iniFilePath = iniFilePath.GetBackSlashPath();
            if (iniFilePath.StartsWith(parentFilePath.GetDirPathOfFile())) return iniFilePath.Substring(parentFilePath.GetDirPathOfFile().Length);
            else if (iniFilePath.StartsWith(MugenSetting.MugenDataDirPath)) return iniFilePath.Substring(MugenSetting.MugenDataDirPath.Length);
            else if (iniFilePath.StartsWith(MugenSetting.MugenDirPath)) return iniFilePath.Substring(MugenSetting.MugenDirPath.Length);
            else return "";
        }

        #endregion

    }

    #endregion

    #region MUGEN按键配置类

    /// <summary>
    /// MUGEN按键配置类
    /// </summary>
    public class KeyPressSetting
    {
        /// <summary>
        /// MUGEN按键配置信息结构
        /// </summary>
        public struct SettingInfo
        {
            /// <summary>P1 Keys配置分段</summary>
            public const string P1KeysSection = "P1 Keys";
            /// <summary>P2 Keys配置分段</summary>
            public const string P2KeysSection = "P2 Keys";
            /// <summary>Jump配置项</summary>
            public const string JumpItem = "Jump";
            /// <summary>Crouch配置项</summary>
            public const string CrouchItem = "Crouch";
            /// <summary>Left配置项</summary>
            public const string LeftItem = "Left";
            /// <summary>Right配置项</summary>
            public const string RightItem = "Right";
            /// <summary>A配置项</summary>
            public const string AItem = "A";
            /// <summary>B配置项</summary>
            public const string BItem = "B";
            /// <summary>C配置项</summary>
            public const string CItem = "C";
            /// <summary>X配置项</summary>
            public const string XItem = "X";
            /// <summary>Y配置项</summary>
            public const string YItem = "Y";
            /// <summary>Z配置项</summary>
            public const string ZItem = "Z";
            /// <summary>Start配置项</summary>
            public const string StartItem = "Start";
        }

        /// <summary>按键编码左界定符</summary>
        public const string LeftDelimeter = "(";
        /// <summary>按键编码右界定符</summary>
        public const string RightDelimeter = ")";
        /// <summary>MUGEN 1.x版按键编码表</summary>
        private static readonly Dictionary<ushort, string> KeyCodeV1_X = new Dictionary<ushort, string>()
        {
            {0, "Not Used"}, {8, "Backspace"}, {9, "Tab"}, {13, "Return"}, {19, "Pause"}, {27, "Escape"}, {32, "Space"}, {39, "'"}, {44, ","}, {45, "-"}, {46, "."}, {47, "/"}, {48, "0"}, {49, "1"}, {50, "2"}, {51, "3"}, {52, "4"}, {53, "5"}, {54, "6"}, {55, "7"}, {56, "8"}, {57, "9"}, {59, ";"}, {61, "="}, {91, "["}, {92, "\\"}, {93, "]"}, {96, "`"}, {97, "a"}, {98, "b"}, {99, "c"}, {100, "d"}, {101, "e"}, {102, "f"}, {103, "g"}, {104, "h"}, {105, "i"}, {106, "j"}, {107, "k"}, {108, "l"}, {109, "m"}, {110, "n"}, {111, "o"}, {112, "p"}, {113, "q"}, {114, "r"}, {115, "s"}, {116, "t"}, {117, "u"}, {118, "v"}, {119, "w"}, {120, "x"}, {121, "y"}, {122, "z"}, {127, "Delete"}, {256, "Num 0"}, {257, "Num 1"}, {258, "Num 2"}, {259, "Num 3"}, {260, "Num 4"}, {261, "Num 5"}, {262, "Num 6"}, {263, "Num 7"}, {264, "Num 8"}, {265, "Num 9"}, {266, "Num ."}, {267, "Num /"}, {268, "Num *"}, {269, "Num -"}, {270, "Num +"}, {271, "Num Enter"}, {272, "Equals"}, {273, "Up"}, {274, "Down"}, {275, "Right"}, {276, "Left"}, {277, "Insert"}, {278, "Home"}, {279, "End"}, {280, "Page Up"}, {281, "Page Down"}, {282, "F1"}, {283, "F2"}, {284, "F3"}, {285, "F4"}, {286, "F5"}, {287, "F6"}, {288, "F7"}, {289, "F8"}, {290, "F9"}, {291, "F10"}, {292, "F11"}, {293, "F12"}, {294, "F13"}, {295, "F14"}, {296, "F15"}, {300, "Num Lock"}, {301, "Caps Lock"}, {302, "Scroll Lock"}, {303, "Right Shift"}, {304, "Left Shift"}, {305, "Right Ctrl"}, {306, "Left Ctrl"}, {307, "Right Alt"}, {308, "Left Alt"}, {311, "Left Super"}, {312, "Right Super"}, {316, "Print Screen"}, {319, "Menu"}
        };
        /// <summary>MUGEN WIN版按键编码表</summary>
        private static readonly Dictionary<ushort, string> KeyCodeWIN = new Dictionary<ushort, string>()
        {
            {0, "Not Used"}, {1, "Esc"}, {2, "1"}, {3, "2"}, {4, "3"}, {5, "4"}, {6, "5"}, {7, "6"}, {8, "7"}, {9, "8"}, {10, "9"}, {11, "0"}, {12, "-"}, {13, "="}, {14, "Backspace"}, {15, "Tab"}, {16, "Q"}, {17, "W"}, {18, "E"}, {19, "R"}, {20, "T"}, {21, "Y"}, {22, "U"}, {23, "I"}, {24, "O"}, {25, "P"}, {26, "["}, {27, "]"}, {28, "Enter"}, {29, "Left Ctrl"}, {30, "A"}, {31, "S"}, {32, "D"}, {33, "F"}, {34, "G"}, {35, "H"}, {36, "J"}, {37, "K"}, {38, "L"}, {39, ";"}, {40, "'"}, {41, "`"}, {42, "Left Shift"}, {43, "\\"}, {44, "Z"}, {45, "X"}, {46, "C"}, {47, "V"}, {48, "B"}, {49, "N"}, {50, "M"}, {51, ", "}, {52, "."}, {53, "/"}, {54, "Right Shift"}, {55, "Pad *"}, {56, "Left Alt"}, {57, "Space"}, {58, "Caps Lock"}, {59, "F1"}, {60, "F2"}, {61, "F3"}, {62, "F4"}, {63, "F5"}, {64, "F6"}, {65, "F7"}, {66, "F8"}, {67, "F9"}, {68, "F10"}, {69, "Num Lock"}, {70, "Scroll Lock"}, {71, "Pad 7"}, {72, "Pad 8"}, {73, "Pad 9"}, {74, "Pad -"}, {75, "Pad 4"}, {76, "Pad 5"}, {77, "Pad 6"}, {78, "Pad +"}, {79, "Pad 1"}, {80, "Pad 2"}, {81, "Pad 3"}, {82, "Pad 0"}, {83, "Pad ."}, {87, "F11"}, {88, "F12"}, {156, "Pad Enter"}, {157, "Right Ctrl"}, {181, "Pad /"}, {184, "Right Alt"}, {199, "Home"}, {200, "Up"}, {201, "Page Up"}, {203, "Left"}, {205, "Right"}, {207, "End"}, {208, "Down"}, {209, "Page Down"}, {210, "Insert"}, {211, "Delete"}
        };

        private string _keyPressType;
        private ushort _jump;
        private ushort _crouch;
        private ushort _left;
        private ushort _right;
        private ushort _a;
        private ushort _b;
        private ushort _c;
        private ushort _x;
        private ushort _y;
        private ushort _z;
        private ushort _start;

        /// <summary>
        /// 获取或设置按键类型
        /// </summary>
        public string KeyPressType
        {
            get { return _keyPressType; }
            set { _keyPressType = value; }
        }

        /// <summary>
        /// 获取或设置Jump按键码
        /// </summary>
        public ushort Jump
        {
            get { return _jump; }
            set { _jump = value; }
        }

        /// <summary>
        /// 获取或设置Crouch按键码
        /// </summary>
        public ushort Crouch
        {
            get { return _crouch; }
            set { _crouch = value; }
        }

        /// <summary>
        /// 获取或设置Left按键码
        /// </summary>
        public ushort Left
        {
            get { return _left; }
            set { _left = value; }
        }

        /// <summary>
        /// 获取或设置Right按键码
        /// </summary>
        public ushort Right
        {
            get { return _right; }
            set { _right = value; }
        }

        /// <summary>
        /// 获取或设置A按键码
        /// </summary>
        public ushort A
        {
            get { return _a; }
            set { _a = value; }
        }

        /// <summary>
        /// 获取或设置B按键码
        /// </summary>
        public ushort B
        {
            get { return _b; }
            set { _b = value; }
        }

        /// <summary>
        /// 获取或设置C按键码
        /// </summary>
        public ushort C
        {
            get { return _c; }
            set { _c = value; }
        }

        /// <summary>
        /// 获取或设置X按键码
        /// </summary>
        public ushort X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// 获取或设置Y按键码
        /// </summary>
        public ushort Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// 获取或设置Z按键码
        /// </summary>
        public ushort Z
        {
            get { return _z; }
            set { _z = value; }
        }

        /// <summary>
        /// 获取或设置Start按键码
        /// </summary>
        public ushort Start
        {
            get { return _start; }
            set { _start = value; }
        }

        /// <summary>
        /// 获取MUGEN按键编码表
        /// </summary>
        public static Dictionary<ushort, string> KeyCode
        {
            get
            {
                if (MugenSetting.Version == MugenSetting.MugenVersion.WIN) return KeyCodeWIN;
                else return KeyCodeV1_X;
            }
        }

        /// <summary>
        /// 根据指定按键类型创建<see cref="KeyPressSetting"/>类新实例
        /// </summary>
        /// <param name="keyPressType">按键类型</param>
        /// <exception cref="System.ApplicationException"></exception>
        public KeyPressSetting(string keyPressType)
        {
            KeyPressType = keyPressType;
            ReadKeyPressSetting();
        }

        /// <summary>
        /// 读取MUGEN按键设置
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public void ReadKeyPressSetting()
        {
            if (!File.Exists(MugenSetting.MugenCfgPath)) throw new ApplicationException("mugen.cfg文件不存在！");
            try
            {
                IniFiles ini = new IniFiles(MugenSetting.MugenCfgPath);
                Jump = (ushort)ini.ReadInteger(KeyPressType, SettingInfo.JumpItem, 0);
                Crouch = (ushort)ini.ReadInteger(KeyPressType, SettingInfo.CrouchItem, 0);
                Left = (ushort)ini.ReadInteger(KeyPressType, SettingInfo.LeftItem, 0);
                Right = (ushort)ini.ReadInteger(KeyPressType, SettingInfo.RightItem, 0);
                A = (ushort)ini.ReadInteger(KeyPressType, SettingInfo.AItem, 0);
                B = (ushort)ini.ReadInteger(KeyPressType, SettingInfo.BItem, 0);
                C = (ushort)ini.ReadInteger(KeyPressType, SettingInfo.CItem, 0);
                X = (ushort)ini.ReadInteger(KeyPressType, SettingInfo.XItem, 0);
                Y = (ushort)ini.ReadInteger(KeyPressType, SettingInfo.YItem, 0);
                Z = (ushort)ini.ReadInteger(KeyPressType, SettingInfo.ZItem, 0);
                Start = (ushort)ini.ReadInteger(KeyPressType, SettingInfo.StartItem, 0);
            }
            catch (Exception)
            {
                throw new ApplicationException("读取MUGEN按键失败！");
            }
        }

        /// <summary>
        /// 保存MUGEN按键设置
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        public void Save()
        {
            if (!File.Exists(MugenSetting.MugenCfgPath)) throw new ApplicationException("mugen.cfg文件不存在！");
            try
            {
                IniFiles ini = new IniFiles(MugenSetting.MugenCfgPath);
                ini.WriteInteger(KeyPressType, SettingInfo.JumpItem, Jump);
                ini.WriteInteger(KeyPressType, SettingInfo.CrouchItem, Crouch);
                ini.WriteInteger(KeyPressType, SettingInfo.LeftItem, Left);
                ini.WriteInteger(KeyPressType, SettingInfo.RightItem, Right);
                ini.WriteInteger(KeyPressType, SettingInfo.AItem, A);
                ini.WriteInteger(KeyPressType, SettingInfo.BItem, B);
                ini.WriteInteger(KeyPressType, SettingInfo.CItem, C);
                ini.WriteInteger(KeyPressType, SettingInfo.XItem, X);
                ini.WriteInteger(KeyPressType, SettingInfo.YItem, Y);
                ini.WriteInteger(KeyPressType, SettingInfo.ZItem, Z);
                ini.WriteInteger(KeyPressType, SettingInfo.StartItem, Start);
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("按键设置保存失败！");
            }
        }

        /// <summary>
        /// 获取指定的按键编码名称
        /// </summary>
        /// <param name="keyCode">按键编码</param>
        /// <returns>按键编码名称</returns>
        public static string GetKeyName(ushort keyCode)
        {
            if (KeyCode.ContainsKey(keyCode)) return KeyCode[keyCode];
            else return LeftDelimeter + keyCode + RightDelimeter;
        }

        /// <summary>
        /// 获取指定的按键编码
        /// </summary>
        /// <param name="keyName">按键编码名称</param>
        /// <returns>按键编码</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public static ushort GetKeyCode(string keyName)
        {
            Regex regex = new Regex(@"\((\d+)\)");
            ushort keyCode = 0;
            if (regex.IsMatch(keyName))
            {
                try
                {
                    keyCode = Convert.ToUInt16(regex.Match(keyName).Groups[1].Value);
                }
                catch (Exception)
                {
                    throw new ApplicationException("按键编码格式错误");
                }
                return keyCode;
            }
            else
            {
                try
                {
                    keyCode = KeyCode.First(k => k.Value.ToLower() == keyName.ToLower()).Key;
                }
                catch (Exception)
                {
                    throw new ApplicationException("按键编码格式错误");
                }
                return keyCode;
            }
        }
    }

    #endregion
}