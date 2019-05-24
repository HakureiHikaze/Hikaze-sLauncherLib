using LauncherLib.Download;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherLib.Assets
{
    interface IAssetDownload
    {
        DownloadTask GenDownTasks(string GamePath);
        bool CheckExistence(string GamePath);
        bool CheckSize(string GamePath);
        bool CheckSHA1(string GamePath);
    }
}
