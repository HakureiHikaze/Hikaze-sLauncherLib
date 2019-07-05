using LauncherLib.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace LauncherLib.Download
{
    public class DownloadTask
    {
        public readonly string url;
        public readonly string localPath;
        public readonly string sha1;
        public int size { get; }
        public bool isDownloading { get; set; } = false;
        public DownloadTask(string _url, string _localPath, string _sha1, int _size)
        {
            url = _url;
            localPath = _localPath;
            sha1 = _sha1;
            size = _size;
            Utils.CreateDir(_localPath);
        }

        string ThreadInfoWithMsg(string msg)
        {
            return "Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": " + msg;
        }
        public void SingleDownloadUncheck()
        {
            Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Starting download " + this.url + " . [SingleDownload()][0]");
            if (this.localPath != null && this.url != null)
            {
                Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Avaliable task " + " . [SingleDownload()][0]");
                if (!File.Exists(this.localPath))
                {
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": " + this.localPath + " doesn't exists, check and create dir" + " . [SingleDownload()][0]");
                    Utils.CreateDir(this.localPath);
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Start download " + this.localPath + " . [SingleDownload()][0]");
                    Downloader.DownloadFile(this.url, this.localPath);
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Downloaded " + this.localPath + " . [SingleDownload()][0]");
                }
                else
                {
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": " + this.localPath + " already exists, check downloads" + " . [SingleDownload()][0]");
                    Downloader.DownloadFile(this.url, this.localPath);
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Downloaded " + this.localPath + " . [SingleDownload()][1]");
                }
            }
        }
        public void SingleDownload()
        {
            Utils.ConsoleWriteLineColored(ConsoleColor.Blue, "Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Starting download " + this.url + " . [SingleDownload()][0]");
            if (this.localPath != null && this.url != null)
            {
                Utils.ConsoleWriteLineColored(ConsoleColor.Blue, "Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Avaliable task " + " . [SingleDownload()][0]");
                if (!File.Exists(this.localPath))
                {
                    Utils.ConsoleWriteLineColored(ConsoleColor.Yellow, "Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": " + this.localPath + " doesn't exists, check and create dir" + " . [SingleDownload()][0]");
                    Utils.CreateDir(this.localPath);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Start download " + this.localPath + " . [SingleDownload()][0]");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (!Downloader.DownloadFile(this.url, this.localPath))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Debug.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Problem occured. Redownload " + " . [SingleDownload()][0]");
                        Console.ForegroundColor = ConsoleColor.White;
                        SingleDownload();
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Downloaded " + this.localPath + " . [SingleDownload()][0]");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": " + this.localPath + " already exists, check downloads" + " . [SingleDownload()][0]");
                    Console.ForegroundColor = ConsoleColor.White;
                    FileInfo info0 = new FileInfo(this.localPath);
                    if (this.size != 0)
                    {
                        if (info0.Length != this.size)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": " + this.localPath + " size mismatch, continue downloading" + " . [SingleDownload()][0]");
                            Console.ForegroundColor = ConsoleColor.White;
                            if (!Downloader.DownloadFile(this.url, this.localPath))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Debug.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Problem occured. Redownload " + " . [SingleDownload()][0]");
                                Console.ForegroundColor = ConsoleColor.White;
                                SingleDownload();
                            }
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Downloaded " + this.localPath + " . [SingleDownload()][1]");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Utils.ConsoleWriteLineColored(ConsoleColor.Yellow, ThreadInfoWithMsg("Invalid size, skip. [SingleDownload()][0]"));
                        }
                    }
                }
                if (this.sha1 != null)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Avaliable sha1, check sha1 " + " \"" + this.sha1 + "\" " + " . [SingleDownload()][0]");
                    Console.ForegroundColor = ConsoleColor.White;
                    while (!Downloader.CheckSHA1(this.localPath, this.sha1))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": SHA1 check failed " + " \"" + this.sha1 + "\" " + " with \"" + Downloader.GetSHA1(this.localPath) + "\"" + " . [SingleDownload()][0]");
                        Console.ForegroundColor = ConsoleColor.White;
                        File.Delete(this.localPath);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Redownloading " + this.localPath + " . [SingleDownload()][0]");
                        Console.ForegroundColor = ConsoleColor.White;
                        Downloader.DownloadFile(this.url, this.localPath);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Downloaded " + this.localPath + " . [SingleDownload()][2]");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Successfully downloaded " + this.localPath + " . [SingleDownload()][2]");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
