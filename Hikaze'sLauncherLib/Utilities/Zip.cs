using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherLib.Utilities
{
    public static class Zip
    {
        /// <summary>  
        /// 压缩枚举  
        /// </summary>  
        public enum ZipEnum
        {
            ///压缩时间长，压缩率高  
            BZIP2,

            ///压缩效率高，压缩率低  
            GZIP
        }
        #region 制作压缩包（单个文件压缩）  
        /// <summary>  
        /// 制作压缩包（单个文件压缩）  
        /// </summary>  
        /// <param name="srcFileName">原文件</param>  
        /// <param name="zipFileName">压缩文件</param>  
        /// <param name="zipEnum">压缩算法枚举</param>  
        /// <returns>压缩成功标志</returns>  
        public static bool ZipFile(string srcFileName, string zipFileName, ZipEnum zipEnum)
        {
            bool flag = true;
            try
            {
                switch (zipEnum)
                {
                    case ZipEnum.BZIP2:

                        FileStream inStream = File.OpenRead(srcFileName);
                        FileStream outStream = File.Open(zipFileName, FileMode.Create);

                        //参数true表示压缩完成后，inStream和outStream连接都释放  
                        BZip2.Compress(inStream, outStream, true, 4096);

                        inStream.Close();
                        outStream.Close();


                        break;
                    case ZipEnum.GZIP:

                        FileStream srcFile = File.OpenRead(srcFileName);

                        GZipOutputStream zipFile = new GZipOutputStream(File.Open(zipFileName, FileMode.Create));

                        byte[] fileData = new byte[srcFile.Length];
                        srcFile.Read(fileData, 0, (int)srcFile.Length);
                        zipFile.Write(fileData, 0, fileData.Length);

                        srcFile.Close();
                        zipFile.Close();

                        break;
                    default: break;
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        #endregion
        #region 制作压缩包（多个文件压缩到一个压缩包，支持加密、注释）  
        /// <summary>  
        /// 制作压缩包（多个文件压缩到一个压缩包，支持加密、注释）  
        /// </summary>  
        /// <param name="topDirectoryName">压缩文件目录</param>  
        /// <param name="zipedFileName">压缩包文件名</param>  
        /// <param name="compresssionLevel">压缩级别 1-9</param>  
        /// <param name="password">密码</param>  
        /// <param name="comment">注释</param>  
        public static void ZipFiles(string topDirectoryName, string zipedFileName, int compresssionLevel, string password, string comment)
        {
            using (ZipOutputStream zos = new ZipOutputStream(File.Open(zipedFileName, FileMode.OpenOrCreate)))
            {
                if (compresssionLevel != 0)
                {
                    zos.SetLevel(compresssionLevel);//设置压缩级别  
                }

                if (!string.IsNullOrEmpty(password))
                {
                    zos.Password = password;//设置zip包加密密码  
                }

                if (!string.IsNullOrEmpty(comment))
                {
                    zos.SetComment(comment);//设置zip包的注释  
                }

                //循环设置目录下所有的*.jpg文件（支持子目录搜索）  
                foreach (string file in Directory.GetFiles(topDirectoryName, "*.jpg", SearchOption.AllDirectories))
                {
                    if (File.Exists(file))
                    {
                        FileInfo item = new FileInfo(file);
                        FileStream fs = File.OpenRead(item.FullName);
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);

                        ZipEntry entry = new ZipEntry(item.Name);
                        zos.PutNextEntry(entry);
                        zos.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
        #endregion
    }
}
