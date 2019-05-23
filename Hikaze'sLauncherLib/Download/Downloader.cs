using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LauncherLib;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using LauncherLib.Lang.Event;

namespace LauncherLib.Download
{
    public static class Downloader
    {
        public delegate void DownloadInfoHandler(DownloadInfo info);
        //public static DownloadInfoHandler OnDownloadInfoChange;
        public static void SimpleDownload(string URL, string LocalPath)
        {
            WebClient DownloadClient = new WebClient();
            DownloadClient.DownloadFile(URL, LocalPath);
            
        }
        public static int CreateDir(string FullPath)

        {
            try
            {
                if (File.Exists(FullPath))
                {
                    return 0;
                }
                else //判断路径中的文件夹是否存在
                {
                    string dirpath = FullPath.Substring(0, FullPath.LastIndexOf('\\'));
                    string[] pathes = dirpath.Split('\\');
                    if (pathes.Length > 1)
                    {
                        string path = pathes[0];
                        for (int i = 1; i < pathes.Length; i++)
                        {
                            path += "\\" + pathes[i];
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                        }
                    }
                    return 1;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Problem occurred: " + e.Message);
                return -1;
            }
        }
        public static bool CheckSHA1(string path,string SourceSHA1)
        {
            try
            {
                FileStream file = new FileStream(path, FileMode.Open);
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] retval = sha1.ComputeHash(file);
                file.Close();
                StringBuilder sc = new StringBuilder();
                for (int i = 0; i < retval.Length; i++)
                {
                    sc.Append(retval[i].ToString("x2"));
                }
                Debug.WriteLine(sc.ToString());
                if(sc.ToString() == SourceSHA1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public static string GetSHA1(string path)
        {
            //try
            //{
                FileStream file = new FileStream(path, FileMode.Open);
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] retval = sha1.ComputeHash(file);
                file.Close();
                StringBuilder sc = new StringBuilder();
                for (int i = 0; i < retval.Length; i++)
                {
                    sc.Append(retval[i].ToString("x2"));
                }
                Debug.WriteLine(sc.ToString());
                return sc.ToString();
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //    return null;
            //}
        }
        /// 下载文件方法
        /// 文件保存路径和文件名
        /// 返回服务器文件名
        public static void DownloadFileFromTask(DownloadTask task)
        {
            DownloadFile(task.url, task.localPath);
        }
        public static bool DownloadFile(string sourceFile, string desFile)
        {
            DownloadInfo info;
            bool flag = false;
            long SPosition = 0;
            FileStream FStream = null;
            Stream myStream = null;
            string fileName = sourceFile.Substring(sourceFile.LastIndexOf(@"/") + 1);
            if (desFile.EndsWith("\\"))
            {
                desFile = desFile + fileName;
            }
            else
            {
                //desFile = desFile + "\\" + fileName;
            }
            //try
            //{
                long downloadProgress =0;
                long serverFileLength = GetHttpLength(sourceFile);
                //判断要下载的文件夹是否存在
                if (File.Exists(desFile))
                {
                    //打开上次下载的文件
                    FStream = File.OpenWrite(desFile);
                    //获取已经下载的长度
                    SPosition = FStream.Length;
                    downloadProgress = SPosition;
                    info = new DownloadInfo(sourceFile, desFile, SPosition / (double)serverFileLength);
                    if (SPosition == serverFileLength)
                    {//文件是完整的，直接结束下载任务
                        
                        //OnDownloadInfoChange(info);
                        return true;
                    }
                    FStream.Seek(SPosition, SeekOrigin.Current);
                }
                else
                {
                    //文件不保存创建一个文件
                    FStream = new FileStream(desFile, FileMode.Create);
                    SPosition = 0;
                    info = new DownloadInfo(sourceFile, desFile, 0d);
                    //OnDownloadInfoChange(info);
                }
                //打开网络连接
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(sourceFile);
                if (SPosition > 0)
                {
                    myRequest.AddRange(SPosition);             //设置Range值
                }
                //向服务器请求,获得服务器的回应数据流
                myStream = myRequest.GetResponse().GetResponseStream();
                //定义一个字节数据
                byte[] btContent = new byte[5120];
                int intSize = 0;
                intSize = myStream.Read(btContent, 0, 5120);
                while (intSize > 0)
                {
                    downloadProgress += intSize;
                    info.DownloadPercent = downloadProgress / (double)serverFileLength;
                    //OnDownloadInfoChange(info);
                    FStream.Write(btContent, 0, intSize);
                    intSize = myStream.Read(btContent, 0, 5120);
                }
                flag = true;        //返回true下载成功
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine("下载文件时异常：" + ex.Message);
            //}
            //finally
            //{
                //关闭流
                if (myStream != null)
                {
                    myStream.Close();
                    myStream.Dispose();
                }
                if (FStream != null)
                {
                    FStream.Close();
                    FStream.Dispose();
                }
            //}
            return flag;
        }
        public static long GetHttpLength(string url)
        {
            long length = 0;
            try
            {
                var req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                req.Method = "HEAD";
                req.Timeout = 5000;
                var res = (HttpWebResponse)req.GetResponse();
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    length = res.ContentLength;
                }
                res.Close();
                return length;
            }
            catch (WebException wex)
            {
                Debug.WriteLine("异常：" + wex.Message);
                return 0;
            }
        }
    }
}
