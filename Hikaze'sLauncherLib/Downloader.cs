using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LauncherLib;
using System.IO;
using System.Diagnostics;

namespace LauncherLib
{
    public static class Downloader
    {
        public static void download(string URL, string LocalPath)
        {
            System.Net.WebClient DownloadClient = new System.Net.WebClient();
            DownloadClient.DownloadFile(URL, LocalPath);
        }
        public static int createdir(string filefullpath)

        {
            try
            {
                if (File.Exists(filefullpath))
                {
                    return 0;
                }
                else //判断路径中的文件夹是否存在
                {
                    string dirpath = filefullpath.Substring(0, filefullpath.LastIndexOf('\\'));
                    string[] pathes = dirpath.Split('\\');
                    if (pathes.Length > 1)
                    {
                        string path = pathes[0];
                        for (int i = 1; i < pathes.Length; i++)
                        {
                            path += "\\" + pathes[i];
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                        }
                    }
                    return 1;
                }
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("Problem occurred: "+e.Message);
                return -1;
            }


        }
    }
    public class LibDownloadInfo
    {
        public string name;
        public string path;
        public string sha1;
        public int size;
        public string url;
        public LibDownloadInfo(JToken jToken, string _name, string GamePath)
        {
            name = _name;
            path = jToken["path"] != null ? GamePath + @"\libraries\" + jToken["path"].ToString() : name != null ? GamePath + @"\libraries\" + LaunchArgs.ConvertPackageToPath(name, null) : "";
            sha1 = jToken["sha1"] != null ? jToken["sha1"].ToString() : "";
            size = jToken["size"] != null ? Convert.ToInt32(jToken["size"].ToString()) : 0;
            url = jToken["url"] != null ? jToken["url"].ToString() : "";
        }
        public LibDownloadInfo(string _name, string GamePath, string _sha1, string url)
        {
            name = _name;

        }
    }
}
