using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LauncherLib.Lang.Event
{
    internal class DownloadEventArgs:EventArgs
    {
        public string path { get; }
        public float DownloadProgress { get; }
        public DownloadEventArgs(string _path, float _DownloadProgress)
        {
            path = _path;
            DownloadProgress = _DownloadProgress;
        }
    }
}
