using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
        public static string getCorrectDirPath(string dirPath)
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
        public static string getFileDirPath(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                return getCorrectDirPath(file.DirectoryName);
            }
            catch (Exception) { return filePath; }
        }

        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>扩展名</returns>
        public static string getFileExt(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                return file.Extension;
            }
            catch (Exception) { return filePath; }
        }

        /// <summary>
        /// 获取不带扩展名的文件名
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件名</returns>
        public static string getFileNameWithoutExt(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (file.Name.LastIndexOf('.') >= 0)
                {
                    return file.Name.Substring(0, file.Name.LastIndexOf('.'));
                }
                else return file.Name;
            }
            catch (Exception) { return ""; }
        }

        /// <summary>
        /// 获取正斜杠(/)的文件(夹)路径
        /// </summary>
        /// <param name="path">文件(夹)路径</param>
        /// <returns>文件(夹)路径</returns>
        public static string getSlashPath(string path)
        {
            return path.Replace('\\', '/');
        }
    }
}
