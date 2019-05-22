using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherLib.Lang.Event
{
    public class EventListener
    {
    }
    public class DownloadEventListener:EventListener
    {
        public DownloadInfo currentDownloadInfo;
        public void OnDownloadProgress(DownloadInfo _downloadInfo)
        {
            currentDownloadInfo = _downloadInfo;
        }
    }
    public class DownloadInfo
    {
        public readonly string DownloadUrl;
        public readonly string DownloadPath;
        public double DownloadPercent;
        public DownloadInfo(string url,string path,double percent)
        {
            DownloadUrl = url;
            DownloadPath = path;
            DownloadPercent = percent;
        }
    }
}
