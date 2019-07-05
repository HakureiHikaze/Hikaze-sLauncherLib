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
