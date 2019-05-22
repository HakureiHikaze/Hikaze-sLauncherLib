using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using LauncherLib;
using LauncherLib.Download;
using Newtonsoft.Json.Linq;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject jObject = JsonHandler.ReadJson(@"D:\SNv1.12.2\.minecraft", "1.12.2");
            List<Libraries> libs = new List<Libraries>();
            foreach (JToken elements in jObject["libraries"])
            {
                libs.Add(new Libraries(LibOperation.GetLibType(elements), elements, @"D:\SNv1.12.2\.minecraft"));
            }
            Queue<DownloadTask> downloadTasks = new Queue<DownloadTask>();
            foreach (Libraries libraries in libs)
            {
                DownloadTask task = new DownloadTask(libraries.url, @".\test\test1\" + libraries.path,libraries.sha1);
                Debug.WriteLine(task.url+"   0");
                downloadTasks.Enqueue(task);
                //LibOperation.LibDownload(libraries, @".\test\");
            }
            Debug.WriteLine(downloadTasks.Count) ;
            foreach (DownloadTask elements in downloadTasks)
            {
                Debug.WriteLine(elements.url);
            }
            MultiDownloader multiDownloader = new MultiDownloader(downloadTasks, 10);
            multiDownloader.StartDownload();
        }
    }
}
