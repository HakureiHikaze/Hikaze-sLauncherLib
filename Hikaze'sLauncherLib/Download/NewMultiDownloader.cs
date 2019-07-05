using LauncherLib.Download;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LauncherLib.Download
{
    class NewMultiDownloader
    {
        Queue<DownloadTask> TaskList;
        bool doCheck;
        int DownloadThreads;
        Thread[] threads;
        public NewMultiDownloader(Queue<DownloadTask> _TaskList,bool _doCheck,int _DownloadThreads)
        {
            TaskList = _TaskList;
            doCheck = _doCheck;
            DownloadThreads = _DownloadThreads;
            threads = new Thread[DownloadThreads];
        }
        
    }
}
