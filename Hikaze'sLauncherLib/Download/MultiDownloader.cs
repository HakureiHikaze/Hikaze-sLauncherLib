using LauncherLib.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
    //TODO：尝试给Task添加一个bool值，任务开始时该值设为true，新线程创建时如果这个Task的该值为true，则跳过
    public class MultiDownloader
    {
        Thread[] threads;
        bool uncheck = false;
        Queue<DownloadTask> DownloadList { get; set; }
        int DownloadThreads { get; set; }
        public MultiDownloader(Queue<DownloadTask> inDownloadList, int inDownloadThreads, bool _uncheck)
        {
            DownloadList = inDownloadList;
            DownloadThreads = inDownloadThreads;
            threads = new Thread[DownloadThreads];
            uncheck = _uncheck;
        }
        void InitTasks()
        {
            for (int i = 0; i < DownloadThreads; i++)
            {
                if (DownloadList.Count != 0)
                {

                    if (!uncheck)
                    {
                        DownloadTask thisTask = DownloadList.Dequeue();
                        if (!thisTask.isDownloading)
                        {
                            thisTask.isDownloading = true;
                            threads[i] = new Thread(new ThreadStart(thisTask.SingleDownload));
                        }
                        else
                        {
                            continue;
                        }
                    }

                    else
                    {
                        DownloadTask thisTask = DownloadList.Dequeue();
                        if (!thisTask.isDownloading)
                        {
                            thisTask.isDownloading = true;
                            threads[i] = new Thread(new ThreadStart(thisTask.SingleDownloadUncheck));
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }
        void AddTasks()
        {
            for (int i = 0; i < DownloadThreads; i++)
            {
                if (!threads[i].IsAlive)
                {
                    if (DownloadList.Count != 0)
                    {
                        if (!uncheck)
                        {
                            DownloadTask thisTask = DownloadList.Dequeue();
                            if (!thisTask.isDownloading)
                            {
                                thisTask.isDownloading = true;
                                threads[i] = new Thread(new ThreadStart(thisTask.SingleDownload));
                            }
                            else
                            {
                                continue;
                            }
                        }

                        else
                        {
                            DownloadTask thisTask = DownloadList.Dequeue();
                            if (!thisTask.isDownloading)
                            {
                                thisTask.isDownloading = true;
                                threads[i] = new Thread(new ThreadStart(thisTask.SingleDownloadUncheck));
                            }
                            else
                            {
                                continue;
                            }
                        }
                        threads[i].Start();
                    }
                }
            }
        }
        void StartAllTasks()
        {
            for (int i = 0; i < DownloadThreads; i++)
            {
                if (threads[i] != null)
                {
                    threads[i].Start();
                }
            }
        }
        public void StartDownload()
        {
            InitTasks();
            StartAllTasks();
            while (DownloadList.Count > 0)
            {
                AddTasks();
            }

        }
    }
}
