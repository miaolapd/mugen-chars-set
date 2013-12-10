using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MUGENCharsSet
{
    public static class Tools
    {
        public static string getCorrectDirPath(string path)
        {
            if (path.Length > 0 && path[path.Length - 1] != '\\')
                return path + "\\";
            else return path;
        }

        public static string getFileDir(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                return getCorrectDirPath(file.DirectoryName);
            }
            catch (Exception) { return path; }
        }

        public static string getFileExt(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                return file.Extension;
            }
            catch (Exception) { return path; }
        }

        public static string getFileNameWithoutExt(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                if (file.Name.LastIndexOf('.') >= 0)
                {
                    return file.Name.Substring(0, file.Name.LastIndexOf('.'));
                }
                else return file.Name;
            }
            catch (Exception) { return path; }
        }

        public static string getSlashDir(string path)
        {
            return path.Replace('\\', '/');
        }
    }
}
