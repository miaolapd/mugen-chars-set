using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MUGENCharsSet
{
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

}