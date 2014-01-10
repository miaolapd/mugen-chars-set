using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MUGENCharsSet
{
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
        /// 类构造方法
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
}