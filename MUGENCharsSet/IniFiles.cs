using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MUGENCharsSet
{
    /// <summary>
    /// INI配置类
    /// </summary>
    public class IniFiles
    {
        public string FileName; //INI文件名
        public string CommentMark = ";";    //注释分隔符

        // 声明读写INI文件的API函数
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);

        /// <summary>
        /// 类构造函数
        /// </summary>
        /// <param name="AFileName">ini文件路径</param>
        public IniFiles(string AFileName)
        {
            // 判断文件是否存在
            FileInfo fileInfo = new FileInfo(AFileName);
            //Todo:搞清枚举的用法
            if ((!fileInfo.Exists))
            { //|| (FileAttributes.Directory in fileInfo.Attributes))
                //文件不存在，建立文件
                System.IO.StreamWriter sw = new System.IO.StreamWriter(AFileName, false, Encoding.Default);
                try
                {
                    sw.Write("\r\n");
                    sw.Close();
                }

                catch
                {
                    throw (new ApplicationException("配置文件不存在！"));
                }
            }
            //必须是完全路径，不能是相对路径
            FileName = fileInfo.FullName;
        }
        
        /// <summary>
        /// 写入指定的配置项
        /// </summary>
        /// <param name="Section">配置分段</param>
        /// <param name="Ident">配置项</param>
        /// <param name="Value">配置值</param>
        public void WriteString(string Section, string Ident, string Value)
        {
            if (!WritePrivateProfileString(Section, Ident, " " + Value.TrimStart(), FileName))
            {

                throw (new ApplicationException("配置文件写入失败！"));
            }
        }
        
        /// <summary>
        /// 读取指定的配置项
        /// </summary>
        /// <param name="Section">配置分段</param>
        /// <param name="Ident">配置项</param>
        /// <param name="Default">默认值</param>
        /// <returns>配置值</returns>
        public string ReadString(string Section, string Ident, string Default)
        {
            Byte[] Buffer = new Byte[65535];
            int bufLen = GetPrivateProfileString(Section, Ident, Default, Buffer, Buffer.GetUpperBound(0), FileName);
            //必须设定0（系统默认的代码页）的编码方式，否则无法支持中文
            string s = Encoding.Default.GetString(Buffer);
            s = s.Substring(0, bufLen);
            if (s.IndexOf(CommentMark) >= 0) s = s.Substring(0, s.IndexOf(CommentMark));
            return s.Trim();
        }

        /// <summary>
        /// 读取指定的配置项(整数)
        /// </summary>
        /// <param name="Section">配置分段</param>
        /// <param name="Ident">配置项</param>
        /// <param name="Default">默认值</param>
        /// <returns>配置值</returns>
        public int ReadInteger(string Section, string Ident, int Default)
        {
            string intStr = ReadString(Section, Ident, Convert.ToString(Default));
            try
            {
                return Convert.ToInt32(intStr);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        /// <summary>
        /// 写入指定的配置项(整数)
        /// </summary>
        /// <param name="Section">配置分段</param>
        /// <param name="Ident">配置项</param>
        /// <param name="Value">配置值</param>
        public void WriteInteger(string Section, string Ident, int Value)
        {
            WriteString(Section, Ident, Value.ToString());
        }

        /// <summary>
        /// 读取指定的配置项(布尔值)
        /// </summary>
        /// <param name="Section">配置分段</param>
        /// <param name="Ident">配置项</param>
        /// <param name="Default">默认值</param>
        /// <returns>配置值</returns>
        public bool ReadBool(string Section, string Ident, bool Default)
        {
            try
            {
                return Convert.ToBoolean(ReadString(Section, Ident, Convert.ToString(Default)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        /// <summary>
        /// 写入指定的配置项(布尔值)
        /// </summary>
        /// <param name="Section">配置分段</param>
        /// <param name="Ident">配置项</param>
        /// <param name="Value">配置值</param>
        public void WriteBool(string Section, string Ident, bool Value)
        {
            WriteString(Section, Ident, Convert.ToString(Value));
        }

        /// <summary>
        /// 读取指定的配置分段中的所有项
        /// </summary>
        /// <param name="Section">配置分段</param>
        /// <param name="Idents">配置值列表</param>
        public void ReadSection(string Section, StringCollection Idents)
        {
            Byte[] Buffer = new Byte[16384];
            //Idents.Clear();

            int bufLen = GetPrivateProfileString(Section, null, null, Buffer, Buffer.GetUpperBound(0),
             FileName);
            //对Section进行解析
            GetStringsFromBuffer(Buffer, bufLen, Idents);
        }

        /// <summary>
        /// 从Buffer中获取字符串列表
        /// </summary>
        /// <param name="Buffer">Buffer</param>
        /// <param name="bufLen">Buffer长度</param>
        /// <param name="Strings">字符串列表</param>
        private void GetStringsFromBuffer(Byte[] Buffer, int bufLen, StringCollection Strings)
        {
            Strings.Clear();
            if (bufLen != 0)
            {
                int start = 0;
                for (int i = 0; i < bufLen; i++)
                {
                    if ((Buffer[i] == 0) && ((i - start) > 0))
                    {
                        String s = Encoding.Default.GetString(Buffer, start, i - start);
                        Strings.Add(s);
                        start = i + 1;
                    }
                }
            }
        }
        
        /// <summary>
        /// 读取所有的配置分段名称
        /// </summary>
        /// <param name="SectionList">配置分段名称列表</param>
        public void ReadSections(StringCollection SectionList)
        {
            //Note:必须得用Bytes来实现，StringBuilder只能取到第一个Section
            byte[] Buffer = new byte[65535];
            int bufLen = 0;
            bufLen = GetPrivateProfileString(null, null, null, Buffer,
             Buffer.GetUpperBound(0), FileName);
            GetStringsFromBuffer(Buffer, bufLen, SectionList);
        }
        

        /// <summary>
        /// 读取指定的配置分段中的所有项的键值对
        /// </summary>
        /// <param name="Section">配置分段</param>
        /// <param name="Values">配置项的键值对</param>
        public void ReadSectionValues(string Section, NameValueCollection Values)
        {
            StringCollection KeyList = new StringCollection();
            ReadSection(Section, KeyList);
            Values.Clear();
            foreach (string key in KeyList)
            {
                Values.Add(key, ReadString(Section, key, ""));

            }
        }
        ////读取指定的Section的所有Value到列表中，
        //public void ReadSectionValues(string Section, NameValueCollection Values,char splitString)
        //{　 string sectionValue;
        //　　string[] sectionValueSplit;
        //　　StringCollection KeyList = new StringCollection();
        //　　ReadSection(Section, KeyList);
        //　　Values.Clear();
        //　　foreach (string key in KeyList)
        //　　{
        //　　　　sectionValue=ReadString(Section, key, "");
        //　　　　sectionValueSplit=sectionValue.Split(splitString);
        //　　　　Values.Add(key, sectionValueSplit[0].ToString(),sectionValueSplit[1].ToString());

        //　　}
        //}
        
        /// <summary>
        /// 删除指定的配置分段
        /// </summary>
        /// <param name="Section">配置分段</param>
        public void EraseSection(string Section)
        {
            //
            if (!WritePrivateProfileString(Section, null, null, FileName))
            {

                throw (new ApplicationException("无法清除配置文件中的Section！"));
            }
        }
        
        /// <summary>
        /// 删除指定的配置项
        /// </summary>
        /// <param name="Section">配置分段</param>
        /// <param name="Ident">配置项</param>
        public void DeleteKey(string Section, string Ident)
        {
            WritePrivateProfileString(Section, Ident, null, FileName);
        }

        /// <summary>
        /// 对于Win9X，来说需要实现UpdateFile方法将缓冲中的数据写入文件。
        /// 在Win NT, 2000和XP上，都是直接写文件，没有缓冲，所以，无须实现UpdateFile。
        /// 执行完对Ini文件的修改之后，应该调用本方法更新缓冲区。
        /// </summary>
        public void UpdateFile()
        {
            WritePrivateProfileString(null, null, null, FileName);
        }

        /// <summary>
        /// 检查指定配置项是否存在
        /// </summary>
        /// <param name="Section">配置分段</param>
        /// <param name="Ident">配置项</param>
        /// <returns>是否存在</returns>
        public bool ValueExists(string Section, string Ident)
        {
            //
            StringCollection Idents = new StringCollection();
            ReadSection(Section, Idents);
            return Idents.IndexOf(Ident) > -1;
        }

        //确保资源的释放
        ~IniFiles()
        {
            UpdateFile();
        }
    }
}
