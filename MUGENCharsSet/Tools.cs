using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
    }
}
