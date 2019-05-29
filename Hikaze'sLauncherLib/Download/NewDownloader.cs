using LauncherLib.Lang.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace LauncherLib.Download
{
    class NewDownloader
    {
        public string path { get; }
        public int size { get; }
        public string SHA1 { get; }
        public string url { get; }
        float DownloadProgress;
        public event EventHandler<DownloadEventArgs> DownloadProcessChanged;
        public bool ChechSHA1()
        {
            try
            {
                FileStream file = new FileStream(path, FileMode.Open);
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] retval = sha1.ComputeHash(file);
                file.Close();
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < retval.Length; i++)
                {
                    stringBuilder.Append(retval[i].ToString("x2"));
                }
                if (stringBuilder.ToString() == SHA1)   {return true;}
                else                                    {return false;}
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
        public NewDownloader(DownloadTask task)
        {
            DownloadProgress = 0;
            try
            {
                path = task.localPath;
                SHA1 = task.sha1;
                url = task.url;
                size = task.size;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
        public bool DownloadFile()
        {
            bool flag;
            long DownloadPosition;
            long FileLenthFromHttp = GetHttpLength(url);
            if(FileLenthFromHttp != size)
            {
                Utilities.Utils.ConsoleWriteLineColored(ConsoleColor.Red, "Error: Local-size was dead, mismatch.");
            }
            FileStream fileStream = null;
            Stream stream = null;
            try
            {
                if (File.Exists(path))
                {
                    fileStream = File.OpenWrite(path);
                    DownloadPosition = fileStream.Length;
                    DownloadProgress = (float)DownloadPosition / size;
                    DownloadProcessChanged?.Invoke(this, new DownloadEventArgs(path, DownloadProgress));
                    if (DownloadPosition == FileLenthFromHttp)
                    {
                        flag= true;
                    }
                    fileStream.Seek(DownloadPosition, SeekOrigin.Current);
                }
                else
                {
                    Utilities.Utils.CreateDir(path);
                    DownloadPosition = 0;
                    DownloadProcessChanged?.Invoke(this, new DownloadEventArgs(path, 0f));
                    fileStream = new FileStream(path, FileMode.Create);
                }
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                if(DownloadPosition >0)
                {
                    httpWebRequest.AddRange(DownloadPosition);
                }
                stream = httpWebRequest.GetResponse().GetResponseStream();
                byte[] downloadContent = new byte[512];
                int intSize = 0;
                intSize = stream.Read(downloadContent, 0, 512);
                while(intSize >0)
                {
                    DownloadPosition += intSize;
                    fileStream.Write(downloadContent, 0, 512);
                    intSize = stream.Read(downloadContent, 0, 512);
                    float DownloadPercent = (float)DownloadPosition / FileLenthFromHttp;
                }
                flag = true;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                flag = false;
            }
            finally
            {
                if(fileStream != null)
                {
                    fileStream.Close();
                    fileStream.Dispose();
                }
                if(stream!= null)
                {
                    stream.Close();
                    stream.Dispose();
                }
            }
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
