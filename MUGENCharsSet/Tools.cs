using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MUGENCharsSet
{
    /// <summary>
    /// 工具类
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// 获取末尾带反斜杠(\)的文件夹路径
        /// </summary>
        /// <param name="dirPath">文件夹路径</param>
        /// <returns>文件夹路径</returns>
        public static string GetFormatDirPath(string dirPath)
        {
            if (dirPath.Length > 0 && dirPath[dirPath.Length - 1] != '\\')
                return dirPath + "\\";
            else return dirPath;
        }

        /// <summary>
        /// 获取文件所在的文件夹路径
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件夹路径</returns>
        public static string GetFileDirName(string filePath)
        {
            try
            {
                return Path.GetDirectoryName(filePath) + "\\";
            }
            catch (Exception) { return ""; }
        }

        /// <summary>
        /// 获取正斜杠(/)的文件(夹)路径
        /// </summary>
        /// <param name="path">文件(夹)路径</param>
        /// <returns>文件(夹)路径</returns>
        public static string GetSlashPath(string path)
        {
            return path.Replace('\\', '/');
        }

        /// <summary>
        /// 获取反斜杠(\)的文件(夹)路径
        /// </summary>
        /// <param name="path">文件(夹)路径</param>
        /// <returns>文件(夹)路径</returns>
        public static string GetBackSlashPath(string path)
        {
            return path.Replace('/', '\\');
        }

        /// <summary>
        /// 取消指定文件只读属性
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>是否修改成功</returns>
        public static bool SetFileNotReadOnly(string path)
        {
            if (!File.Exists(path)) return true;
            try
            {
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.IsReadOnly)
                {
                    fileInfo.IsReadOnly = false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取MUGEN中可用的配置文件绝对路径
        /// </summary>
        /// <param name="parentFilePath">父配置文件绝对路径</param>
        /// <param name="fileName">配置文件相对路径</param>
        /// <returns>配置文件绝对路径</returns>
        public static string GetIniFileExistPath(string parentFilePath, string fileName)
        {
            if (parentFilePath == String.Empty) return "";
            string path = Tools.GetBackSlashPath(Tools.GetFileDirName(parentFilePath) + fileName);
            if (File.Exists(path)) return path;
            path = Tools.GetBackSlashPath(MugenSetting.MugenDataDirPath + fileName);
            if (File.Exists(path)) return path;
            path = Tools.GetBackSlashPath(MugenSetting.MugenDirPath + fileName);
            if (File.Exists(path)) return path;
            else return "";
        }

        /// <summary>
        /// 判断指定字节流是否为UTF-8编码
        /// </summary>
        /// <param name="inputStream">字节流</param>
        /// <returns>是否为UTF-8编码</returns>
        public static bool IsUTF8(byte[] inputStream)
        {
            int encodingBytesCount = 0;
            bool allTextsAreASCIIChars = true;

            for (int i = 0; i < inputStream.Length; i++)
            {
                byte current = inputStream[i];

                if ((current & 0x80) == 0x80)
                {
                    allTextsAreASCIIChars = false;
                }
                // First byte
                if (encodingBytesCount == 0)
                {
                    if ((current & 0x80) == 0)
                    {
                        // ASCII chars, from 0x00-0x7F
                        continue;
                    }

                    if ((current & 0xC0) == 0xC0)
                    {
                        encodingBytesCount = 1;
                        current <<= 2;
                        // More than two bytes used to encoding a unicode char.
                        // Calculate the real length.
                        while ((current & 0x80) == 0x80)
                        {
                            current <<= 1;
                            encodingBytesCount++;
                        }
                    }
                    else
                    {
                        // Invalid bits structure for UTF8 encoding rule.
                        return false;
                    }
                }
                else
                {
                    // Following bytes, must start with 10.
                    if ((current & 0xC0) == 0x80)
                    {
                        encodingBytesCount--;
                    }
                    else
                    {
                        // Invalid bits structure for UTF8 encoding rule.
                        return false;
                    }
                }
            }
            if (encodingBytesCount != 0)
            {
                // Invalid bits structure for UTF8 encoding rule.
                // Wrong following bytes count.
                return false;
            }
            // Although UTF8 supports encoding for ASCII chars, we regard as a input stream, whose contents are all ASCII as default encoding.
            return !allTextsAreASCIIChars;
        }

        /// <summary>
        /// 将字符串从UTF-8编码转换为默认编码
        /// </summary>
        /// <param name="content">要转换的字符串</param>
        /// <returns>转换后的字符串</returns>
        public static string ConvertUTF8ToDefaultEncoding(string content)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            bytes = Encoding.Convert(Encoding.UTF8, Encoding.Default, bytes);
            return Encoding.Default.GetString(bytes);
        }

        /// <summary>
        /// 使配置文件规格化(在文件开头添加空行、将UTF-8编码的文件转换为默认编码)
        /// </summary>
        /// <param name="path">文件绝对路径</param>
        public static void IniFileStandardization(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();
                if (Tools.IsUTF8(bytes))
                {
                    string content = File.ReadAllText(path, Encoding.UTF8);
                    content = Tools.ConvertUTF8ToDefaultEncoding(content);
                    if (content[0] == '[')
                    {
                        content = "\r\n" + content;
                    }
                    File.WriteAllText(path, content, Encoding.Default);
                }
                else
                {
                    if (bytes[0] == '[')
                    {
                        string content = File.ReadAllText(path, Encoding.Default);
                        File.WriteAllText(path, "\r\n" + content, Encoding.Default);
                    }
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 获取ComboBox控件中与指定数值相同的索引项
        /// </summary>
        /// <param name="combobox">ComboBox控件</param>
        /// <param name="value">指定数值</param>
        public static int GetComboBoxEqualValueIndex(ComboBox combobox, int value)
        {
            for (int i = 0; i < combobox.Items.Count; i++)
            {
                try
                {
                    if (Convert.ToInt32(combobox.Items[i].ToString()) == value)
                    {
                        return i;
                    }
                }
                catch(Exception)
                {
                    return -1;
                }
            }
            return -1;
        }

        /// <summary>
        /// 获取ComboBox控件中与指定数值相同的索引项
        /// </summary>
        /// <param name="combobox">ComboBox控件</param>
        /// <param name="value">指定数值</param>
        public static int GetComboBoxEqualValueIndex(ComboBox combobox, string value)
        {
            for (int i = 0; i < combobox.Items.Count; i++)
            {
                if (combobox.Items[i].ToString().ToLower() == value.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
