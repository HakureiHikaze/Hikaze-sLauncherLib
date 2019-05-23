using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using LauncherLib;
using LauncherLib.Configs;
using LauncherLib.Download;
using Newtonsoft.Json.Linq;
using LauncherLib.Lang.Event;
using System.Threading;
using Newtonsoft.Json;
using LauncherLib.Assets;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IndexObjects newIndet = new IndexObjects(@"D:\mc\.minecraft", @"1.12.2",false);
            Queue<DownloadTask> tasks = new Queue<DownloadTask>();
            //for (int i =0;i<newIndet.ObjList.Count;i++)
            //{
            //    Debug.WriteLine(newIndet.ObjList[i].sha1);
            //}
            foreach(SingleObject element in newIndet.ObjList)
            {
                tasks.Enqueue(new DownloadTask(element.url, @".\testAssets\" + element.path, element.sha1,element.size));
                //Debug.WriteLine(element.sha1);
            }
            MultiDownloader download1 = new MultiDownloader(tasks, 100,false);
            download1.StartDownload();
        }
    }
}
