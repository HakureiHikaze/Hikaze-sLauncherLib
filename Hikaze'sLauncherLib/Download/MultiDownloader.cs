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
        public DownloadTask(string _url, string _localPath, string _sha1)
        {
            url = _url;
            localPath = _localPath;
            sha1 = _sha1;
            Downloader.CreateDir(_localPath);
        }
        public void SingleDownload()
        {
            Console.WriteLine("Thread "+Thread.CurrentThread.ManagedThreadId.ToString()+": Starting download " + this.url + " . [SingleDownload()][0]");
            if (this.localPath != null && this.url != null)
            {
                Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Avaliable task " + " . [SingleDownload()][0]");
                if (!File.Exists(this.localPath))
                {
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": "+this.localPath+" doesn't exists, check and create dir" + " . [SingleDownload()][0]");
                    Downloader.CreateDir(this.localPath);
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Start download "+this.localPath + " . [SingleDownload()][0]");
                    Downloader.DownloadFile(this.url, this.localPath);
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Downloaded " + this.localPath + " . [SingleDownload()][0]");
                }
                else
                {
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": " + this.localPath + " already exists, check downloads" + " . [SingleDownload()][0]");
                    Downloader.DownloadFile(this.url, this.localPath);
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Downloaded " + this.localPath + " . [SingleDownload()][1]");
                }
                if (this.sha1 != null)
                {
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Avaliable sha1, check sha1 " +" \""+this.sha1+"\" " + " . [SingleDownload()][0]");
                    while (!Downloader.GetSHA1(this.localPath, this.sha1))
                    {
                        Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": SHA1 check failed " + " \"" + this.sha1 + "\" " + " . [SingleDownload()][0]");
                        Downloader.DownloadFile(this.url, this.localPath);
                        Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + ": Downloaded " + this.localPath + " . [SingleDownload()][2]");
                    }
                }
            }
        }
    }

    public class MultiDownloader
    {
        Thread[] threads;
        Queue<DownloadTask> DownloadList { get; set; }
        int DownloadThreads { get; set; }
        public MultiDownloader(Queue<DownloadTask> inDownloadList, int inDownloadThreads)
        {
            DownloadList = inDownloadList;
            DownloadThreads = inDownloadThreads;
            threads = new Thread[DownloadThreads];
        }
        void InitTasks()
        {
            for (int i = 0; i < DownloadThreads; i++)
            {
                if (DownloadList.Count != 0)
                {
                    threads[i] = new Thread(new ThreadStart(DownloadList.Dequeue().SingleDownload));
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
                        threads[i] = new Thread(new ThreadStart(DownloadList.Dequeue().SingleDownload));
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
