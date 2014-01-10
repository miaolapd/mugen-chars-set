using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace MUGENCharsSet
{
    #region Sprite文件类

    /// <summary>
    /// Sprite文件类
    /// </summary>
    public class SpriteFile
    {
        /// <summary>SFF文件版本枚举</summary>
        public enum SffVerion { Unknown, V1_01, V1_02, V2_00 };
        /// <summary>SFF V1.01头部字节大小</summary>
        public const int HeaderSizeV1_01 = 33;
        /// <summary>SFF V2.00头部字节大小</summary>
        public const int HeaderSizeV2_00 = 53;

        private string _sffPath;
        private string _signature;
        private SffVerion _version;
        private int _numberOfGroups;
        private int _numberOfImages;
        private int _firstSubheaderOffset;
        private int _subheaderSize;
        private bool _sharedPalette;

        /// <summary>
        /// 获取SFF文件绝对路径
        /// </summary>
        public string SffPath
        {
            get { return _sffPath; }
        }

        /// <summary>
        /// 获取Signature
        /// </summary>
        public string Signature
        {
            get { return _signature; }
        }

        /// <summary>
        /// 获取SFF文件版本
        /// </summary>
        public SffVerion Version
        {
            get { return _version; }
        }

        /// <summary>
        /// 获取Number of groups
        /// </summary>
        public int NumberOfGroups
        {
            get { return _numberOfGroups; }
        }

        /// <summary>
        /// 获取Number of images
        /// </summary>
        public int NumberOfImages
        {
            get { return _numberOfImages; }
        }

        /// <summary>
        /// 获取第一个子节点的偏移量
        /// </summary>
        public int FirstSubheaderOffset
        {
            get { return _firstSubheaderOffset; }
        }

        /// <summary>
        /// 获取Size of subheader in bytes
        /// </summary>
        public int SubheaderSize
        {
            get { return _subheaderSize; }
        }

        /// <summary>
        /// 获取Palette type
        /// </summary>
        public bool SharedPalette
        {
            get { return _sharedPalette; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="path">SFF文件绝对路径</param>
        /// <exception cref="System.ApplicationException"></exception>
        public SpriteFile(string path)
        {
            _sffPath = path;
            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                fs = new FileStream(SffPath, FileMode.Open);
                fs.Position = 12;
                br = new BinaryReader(fs);
                byte[] data = br.ReadBytes(4);
                fs.Position = 0;
                string version = String.Format("{0}{1}{2}{3}", data[0], data[1], data[2], data[3]);
                switch (version)
                {
                    case "0101":
                        _version = SffVerion.V1_01;
                        break;
                    case "0102":
                        _version = SffVerion.V1_02;
                        break;
                    case "0002":
                        _version = SffVerion.V2_00;
                        break;
                    default:
                        _version = SffVerion.Unknown;
                        break;
                }

                if (Version == SffVerion.V1_01) ReadHeaderV1_01(br);
                else if (Version == SffVerion.V2_00) ReadHeaderV2_00(br);
            }
            catch (Exception)
            {
                throw new ApplicationException("读取sff文件失败！");
            }
            finally
            {
                br.Close();
                fs.Close();
            }
        }

        /// <summary>
        /// 读取SFF V1.01版头部信息
        /// </summary>
        /// <param name="br">当前SFF文件的二进制数据流</param>
        /// <exception cref="System.ApplicationException"></exception>
        private void ReadHeaderV1_01(BinaryReader br)
        {
            byte[] data = br.ReadBytes(HeaderSizeV1_01);
            if (data.Length != HeaderSizeV1_01) throw new ApplicationException("数据大小错误！");
            _signature = Encoding.Default.GetString(data, 0, 11);
            _numberOfGroups = BitConverter.ToInt32(data, 16);
            _numberOfImages = BitConverter.ToInt32(data, 20);
            _firstSubheaderOffset = BitConverter.ToInt32(data, 24);
            _subheaderSize = BitConverter.ToInt32(data, 28);
            _sharedPalette = data[32] > 0;
        }

        /// <summary>
        /// 读取SFF V2.00版头部信息
        /// </summary>
        /// <param name="br">当前SFF文件的二进制数据流</param>
        private void ReadHeaderV2_00(BinaryReader br)
        {
            
        }

        /// <summary>
        /// 获取第一个子节点
        /// </summary>
        /// <returns>第一个子节点</returns>
        public SpriteFileSubNode GetFirstSubNode()
        {
            try
            {
                return new SpriteFileSubNode(SffPath, FirstSubheaderOffset, Version);
            }
            catch(ApplicationException)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取格式化的版本信息
        /// </summary>
        /// <param name="version">SFF版本</param>
        /// <returns>格式化的版本信息</returns>
        public static string GetFormatVersion(SffVerion version)
        {
            switch(version)
            {
                case SffVerion.V1_01: return "1.01";
                case SffVerion.V1_02: return "1.02";
                case SffVerion.V2_00: return "2.00";
                default: return "未知";
            }
        }
    }

    #endregion

    #region Sprite文件子节点类

    /// <summary>
    /// Sprite文件子节点类
    /// </summary>
    public class SpriteFileSubNode
    {
        /// <summary>SFF V1.01子节点头部字节大小</summary>
        public const int HeaderSizeV1_01 = 32;
        /// <summary>SFF V2.00子节点头部字节大小</summary>
        public const int HeaderSizeV2_00 = 28;

        private int _nextOffset;
        private int _imageSize;
        private Point _axis;
        private int _groupNumber;
        private int _imageNumber;
        private int _sharedIndex;
        private bool _copyLastPalette;
        private byte[] _imageData;

        /// <summary>
        /// 获取下一个子节点的偏移量
        /// </summary>
        public int NextOffset
        {
            get { return _nextOffset; }
        }

        /// <summary>
        /// 获取图像数据字节大小
        /// </summary>
        public int ImageSize
        {
            get { return _imageSize; }
        }

        /// <summary>
        /// 获取图像axis坐标
        /// </summary>
        public Point Axis
        {
            get { return _axis; }
        }

        /// <summary>
        /// 获取Group number
        /// </summary>
        public int GroupNumber
        {
            get { return _groupNumber; }
        }

        /// <summary>
        /// 获取Image number (in the group)
        /// </summary>
        public int ImageNumber
        {
            get { return _imageNumber; }
        }

        /// <summary>
        /// 获取Index of previous copy of sprite (linked sprites only)
        /// </summary>
        public int SharedIndex
        {
            get { return _sharedIndex; }
        }

        /// <summary>
        /// 获取True if palette is same as previous (or first) image
        /// </summary>
        public bool CopyLastPalette
        {
            get { return _copyLastPalette; }
        }

        /// <summary>
        /// 获取图像数据
        /// </summary>
        public byte[] ImageData
        {
            get { return _imageData; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="path">SFF文件绝对路径</param>
        /// <param name="offset">子节点偏移量</param>
        /// <param name="version">SFF文件版本</param>
        /// <exception cref="System.ApplicationException"></exception>
        public SpriteFileSubNode(string path, int offset, SpriteFile.SffVerion version)
        {
            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                fs = new FileStream(path, FileMode.Open);
                fs.Position = offset;
                br = new BinaryReader(fs);
                if (version == SpriteFile.SffVerion.V1_01) ReadV1_01(br);
                else if (version == SpriteFile.SffVerion.V2_00) ReadV2_00(br);
                else throw new Exception();
            }
            catch (Exception)
            {
                throw new ApplicationException("读取sff子节点失败！");
            }
            finally
            {
                br.Close();
                fs.Close();
            }
        }

        /// <summary>
        /// 读取SFF V1.01版子节点信息
        /// </summary>
        /// <param name="br">当前SFF文件的二进制数据流</param>
        /// <exception cref="System.ApplicationException"></exception>
        private void ReadV1_01(BinaryReader br)
        {
            byte[] data = br.ReadBytes(HeaderSizeV1_01);
            if (data.Length != HeaderSizeV1_01) throw new ApplicationException("数据大小错误！");
            _nextOffset = BitConverter.ToInt32(data, 0);
            _imageSize = BitConverter.ToInt32(data, 4);
            if (ImageSize == 0) throw new Exception();
            _axis = new Point(BitConverter.ToInt16(data, 8), BitConverter.ToInt16(data, 10));
            _groupNumber = BitConverter.ToInt16(data, 12);
            _imageNumber = BitConverter.ToInt16(data, 14);
            _sharedIndex = BitConverter.ToInt16(data, 16);
            _copyLastPalette = data[18] > 0;
            _imageData = br.ReadBytes(ImageSize);
        }

        /// <summary>
        /// 读取SFF V2.00版子节点信息
        /// </summary>
        /// <param name="br">当前SFF文件的二进制数据流</param>
        private void ReadV2_00(BinaryReader br)
        {
            
        }
    }

    #endregion
}
