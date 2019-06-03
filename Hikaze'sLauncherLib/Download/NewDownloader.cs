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
        public static event EventHandler<ColoredConsoleEventArgs> DownloadMsgSent;
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
        public bool DownloadFileChecked()
        {
            bool flag = false;
            byte RetriedTime = 0;
            try
            {
                while(true)
                {
                    if(RetriedTime >=15)
                    {
                        _SendColoredMsg(this, "Retried 15 times, shutting down this download task.", ConsoleColor.Red);
                        flag = false;
                        break;
                    }
                    if(DownloadFile())
                    {
                        if(CheckSHA1())
                        {
                            flag = true;
                            break;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                _SendColoredMsg(this, "Caught exception at NewDownloader.DowwloadFileChecked() :\n\t\t" +e.Message, ConsoleColor.Red);
            }
            return flag;
        }
        public bool DownloadFile()
        {
            bool flag;
            long DownloadPosition;
            long FileLenthFromHttp = GetHttpLength(url);
            if(FileLenthFromHttp != size)
            {
                _SendColoredMsg(this, "Error: Local-size was dead, mismatch.", ConsoleColor.Red);
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
                _SendColoredMsg(this,"Caught exception at NewDownloader.DowwloadFile() :\n\t\t" + e.Message, ConsoleColor.Red);
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
        public bool CheckSHA1()
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
                if (stringBuilder.ToString() == SHA1) { return true; }
                else { return false; }
            }
            catch (Exception e)
            {
                _SendColoredMsg(this, "Caught exception at NewDownloader.CheckSHA1() :\n\t\t" + e.Message, ConsoleColor.Red);
                return false;
            }
        }
        public long GetHttpLength(string url)
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
                _SendColoredMsg(this,"Caught exception at NewDownloader.GetHttpLenth() :\n\t\t" + wex.Message, ConsoleColor.Red);
                return 0;
            }
        }
        public static void _SendColoredMsg(object sender,string _message,ConsoleColor _color)
        {
            DownloadMsgSent?.Invoke(sender, new ColoredConsoleEventArgs(_message, _color));
        }
    }
}
