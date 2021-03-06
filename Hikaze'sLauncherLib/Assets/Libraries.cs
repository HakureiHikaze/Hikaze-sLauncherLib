﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LauncherLib.Lang;
using LauncherLib.Download;
using System.IO;
using System.Diagnostics;
using LauncherLib.ArgHandler;

namespace LauncherLib.Assets
{
    /// <summary>
    /// 对libraries类的操作
    /// </summary>
    public static class LibOperation
    {
        public static string DOWNLOADS = "downloads"; public static string NATIVES_LINUX = "natives-linux";
        public static string ARTIFACT = "artifact"; public static string NATIVES_WIN = "natives-windows";
        public static string PATH = "path"; public static string NATIVES_OSX = "natives-osx";
        public static string SHA1 = "sha1"; public static string NATIVES = "natives";
        public static string SIZE = "size"; public static string LINUX = "linux";
        public static string URL = "url"; public static string WINDOWS = "windows";
        public static string NAME = "name"; public static string OSX = "osx";
        public static string CLASSIFIERS = "classifiers"; public static string CLIENTREQ = "clientreq";
        public static string TOTALSIZE = "totalSize"; public static string SERVER = "server";
        public static string CLIENT = "client"; public static string ASSETINDEX = "assetIndex";
        public static string ID = "id";
        /// <summary>
        /// 获取libraries元素的种类,类别如下：
        /// <para>0:   downloads(artifact(path,sha1,size,url)),name</para>
        /// <para>1:   downloads(artifact(path,sha1,size,url),classifiers(natives-linux(path,shat.size,url),natives-windows(...),natives-osx(...))),name,natives(linux,osx,windows)</para>
        /// <para>2:   name,url_half,clientreq,*path</para>
        /// <para>3:   name,*path</para>
        /// </summary>
        /// <param name="jToken">传入json中libraries数组中的元素</param>
        /// <returns>返回元素的种类</returns>
        public static int GetLibType(JToken jToken)
        {
            return jToken["downloads"] != null ? jToken["downloads"]["classifiers"] != null ? 1 : 0 : jToken["url"] != null ? 2 : 3;
        }
        //public static void LibDownload(Libraries lib, string librariesPath)
        //{
        //    if (lib.path != null)
        //    {
        //        Debug.WriteLine("Lib path isn't null. " + lib.path);
        //        if (!File.Exists(librariesPath + lib.path))
        //        {
        //            Debug.WriteLine("File doesn't exists, creating. " + lib.path);
        //            Downloader.CreateDir(librariesPath + lib.path);
        //            Debug.WriteLine("Created File Directory. " + lib.path);
        //            if (lib.url != null)
        //            {
        //                Debug.WriteLine("Lib url isn't null, downloading. " + lib.url);
        //                Downloader.DownloadFile(lib.url, librariesPath + lib.path);
        //                Debug.WriteLine("Downloaded " + lib.path);
        //                if (lib.sha1 != null)
        //                {
        //                    Debug.WriteLine("Lib sha1 isn't null, verifying. " + lib.sha1);
        //                    while (!Downloader.CheckSHA1(librariesPath + lib.path, lib.sha1))
        //                    {
        //                        Debug.WriteLine("Failed to verify, delete and redownload. " + lib.sha1);
        //                        File.Delete(librariesPath + lib.path);
        //                        Downloader.DownloadFile(lib.url, librariesPath + lib.path);
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Debug.WriteLine("File exists, is correct file? " + lib.path);
        //            Downloader.DownloadFile(lib.url, librariesPath + lib.path);
        //            if (lib.sha1 != null)
        //            {
        //                while (!Downloader.CheckSHA1(librariesPath + lib.path, lib.sha1))
        //                {
        //                    Debug.WriteLine("Failed to verify, delete and redownload. (1) " + lib.sha1);
        //                    File.Delete(librariesPath + lib.path);
        //                    Downloader.DownloadFile(lib.url, librariesPath + lib.path);
        //                }
        //            }

        //        }
        //    }
        //}
    }
    /// <summary>
    /// lib类
    /// </summary>
    public class Libraries : IAssetDownload
    {
        #region Class Variable Declarations
        /// <summary>
        /// lib种类
        /// </summary>
        public int type { get; }
        /// <summary>
        /// downloads子标签类
        /// </summary>
        public Downloads downloads { get; } = null;
        /// <summary>
        /// 包名
        /// </summary>
        public string name { get; } = null;
        /// <summary>
        /// forge的不完整域名
        /// </summary>
        public string url_half { get; } = null;
        /// <summary>
        /// 完整的包下载域名
        /// </summary>
        public string url { get; } = null;
        /// <summary>
        /// 客户端是否需求
        /// </summary>
        public bool clintReq { get; } = true;
        /// <summary>
        /// 顾名思义
        /// </summary>
        public string sha1 { get; } = null;
        /// <summary>
        /// 包的相对libraries文件夹的路径
        /// </summary>
        public string path { get; } = null;
        /// <summary>
        /// 包的完整路径
        /// </summary>
        public string fullPath { get; } = null;
        /// <summary>
        /// natives子标签类
        /// </summary>
        public Natives natives { get; } = null;
        /// <summary>
        /// 是否为要解压的natives
        /// </summary>
        public bool isNatives { get; } = false;
        /// <summary>
        /// 是否为客户端需要的lib
        /// </summary>
        public bool isUseful { get; } = true;
        #endregion
        /// <summary>
        /// lib类的构造函数
        /// </summary>
        /// <param name="jToken">传入的json标签</param>
        /// <param name="GamePath">游戏路径</param>

        public Libraries(JToken jToken, string GamePath)
        {
            type = LibOperation.GetLibType(jToken);
            switch (type)
            {
                case 0:
                    downloads = new Downloads(jToken, type);
                    name = jToken[LibOperation.NAME].ToString();
                    path = downloads.artifact.path;
                    path = path.Replace("/", @"\");
                    fullPath = GamePath + @"\libraries\" + path;
                    url = downloads.artifact.url != null ? downloads.artifact.url : null;
                    break;
                case 1:
                    downloads = new Downloads(jToken, type);
                    name = jToken[LibOperation.NAME].ToString();
                    if (downloads.classifiers.natives_windows == null)
                    {
                        if (jToken[LibOperation.NATIVES] != null)
                        {
                            natives = new Natives(jToken);
                        }
                        else
                        {
                            path = downloads.artifact.path;
                            path = path.Replace("/", @"\");
                            fullPath = GamePath + @"\libraries\" + path;
                            url = downloads.artifact.url;
                        }
                    }
                    else
                    {
                        path = downloads.classifiers.natives_windows.path;
                        path = path.Replace("/", @"\");
                        fullPath = GamePath + @"\libraries\" + path;
                        url = downloads.classifiers.natives_windows.url != null ? downloads.classifiers.natives_windows.url : null;
                    }
                    isNatives = true;
                    break;
                case 2:
                    name = jToken[LibOperation.NAME].ToString();
                    url_half = jToken[LibOperation.URL].ToString();
                    clintReq = jToken[LibOperation.CLIENTREQ] != null ? jToken[LibOperation.CLIENTREQ].ToString() == "true" ? true : false : true;
                    path = LaunchArgs.ConvertPackageToPath(name, null);
                    path = path.Replace("/", @"\");
                    url = url_half + path.Replace(@"\", "/");
                    fullPath = GamePath + @"\libraries\" + path;
                    break;
                case 3:
                    name = jToken[LibOperation.NAME].ToString();
                    path = LaunchArgs.ConvertPackageToPath(name, null);
                    path = path.Replace("/", @"\");
                    fullPath = GamePath + @"\libraries\" + path;
                    break;
                default:
                    throw (new TypeErrException("Cannot find proper type for this token."));
            }
            if (clintReq == false)
            {
                isUseful = false;
            }
        }

        public DownloadTask GenDownTasks(string GamePath)
        {
            return new DownloadTask(this.url, this.fullPath, this.sha1, 0);
        }

        public bool CheckExistence(string GamePath)
        {
            return File.Exists(this.fullPath);
        }

        public bool CheckSize(string GamePath)
        {
            return true;
        }

        public bool CheckSHA1(string GamePath)
        {
            if (this.sha1 != null)
            {
                return Downloader.CheckSHA1(this.fullPath, this.sha1);
            }
            else
            {
                return true;
            }
        }
    }
    public class assetIndex
    {
        public string id { get; } = null;
        public string sha1 { get; } = null;
        public int size { get; } = 0;
        public int totalSize { get; } = 0;
        public string url { get; } = null;
        public assetIndex(JToken jToken)
        {
            id = jToken[LibOperation.ASSETINDEX][LibOperation.ID] != null ? jToken[LibOperation.ASSETINDEX][LibOperation.ID].ToString() : null;
            sha1 = jToken[LibOperation.ASSETINDEX][LibOperation.SHA1] != null ? jToken[LibOperation.ASSETINDEX][LibOperation.SHA1].ToString() : null;
            size = jToken[LibOperation.ASSETINDEX][LibOperation.SIZE] != null ? Convert.ToInt32(jToken[LibOperation.ASSETINDEX][LibOperation.SIZE].ToString()) : 0;
            size = jToken[LibOperation.ASSETINDEX][LibOperation.TOTALSIZE] != null ? Convert.ToInt32(jToken[LibOperation.ASSETINDEX][LibOperation.TOTALSIZE].ToString()) : 0;
            url = jToken[LibOperation.ASSETINDEX][LibOperation.URL] != null ? jToken[LibOperation.ASSETINDEX][LibOperation.URL].ToString() : null;
        }
    }
    public class assets
    {

    }
    public class Downloads
    {
        public Artifact artifact { get; } = null;
        public Classifiers classifiers { get; } = null;
        public Downloads(JToken jToken, int _type)
        {
            switch (_type)
            {
                case 0:
                    artifact = new Artifact(jToken);
                    break;
                case 1:
                    artifact = jToken[LibOperation.DOWNLOADS][LibOperation.ARTIFACT] != null ? new Artifact(jToken) : null;
                    classifiers = new Classifiers(jToken);
                    break;
                default:
                    throw (new TypeErrException("Cannot find proper type for this token."));
            }
        }
    }
    public class Artifact
    {
        public string path { get; } = null;
        public string sha1 { get; } = null;
        public int size { get; } = 0;
        public string url { get; } = null;
        public Artifact(JToken jToken)
        {
            path = jToken[LibOperation.DOWNLOADS][LibOperation.ARTIFACT][LibOperation.PATH].ToString();
            sha1 = jToken[LibOperation.DOWNLOADS][LibOperation.ARTIFACT][LibOperation.SHA1].ToString();
            size = Convert.ToInt32(jToken[LibOperation.DOWNLOADS][LibOperation.ARTIFACT][LibOperation.SIZE].ToString());
            url = jToken[LibOperation.DOWNLOADS][LibOperation.ARTIFACT][LibOperation.URL].ToString();
        }
    }
    public class Classifiers
    {
        public Natives_os natives_linux { get; } = null;
        public Natives_os natives_windows { get; } = null;
        public Natives_os natives_osx { get; } = null;
        public Classifiers(JToken jToken)
        {
            natives_linux = jToken[LibOperation.DOWNLOADS][LibOperation.CLASSIFIERS][LibOperation.NATIVES_LINUX] != null ? new Natives_os(jToken, "linux") : null;
            natives_windows = jToken[LibOperation.DOWNLOADS][LibOperation.CLASSIFIERS][LibOperation.NATIVES_WIN] != null ? new Natives_os(jToken, "windows") : null;
            natives_osx = jToken[LibOperation.DOWNLOADS][LibOperation.CLASSIFIERS][LibOperation.NATIVES_OSX] != null ? new Natives_os(jToken, "osx") : null;
        }
    }
    public class Natives_os
    {
        public string path { get; } = null;
        public string sha1 { get; } = null;
        public int size { get; } = 0;
        public string url { get; } = null;
        public Natives_os(JToken jToken, string os)
        {
            path = jToken[LibOperation.DOWNLOADS][LibOperation.CLASSIFIERS][LibOperation.NATIVES + "-" + os][LibOperation.PATH].ToString();
            sha1 = jToken[LibOperation.DOWNLOADS][LibOperation.CLASSIFIERS][LibOperation.NATIVES + "-" + os][LibOperation.SHA1].ToString();
            size = Convert.ToInt32(jToken[LibOperation.DOWNLOADS][LibOperation.CLASSIFIERS][LibOperation.NATIVES + "-" + os][LibOperation.SIZE].ToString());
            url = jToken[LibOperation.DOWNLOADS][LibOperation.CLASSIFIERS][LibOperation.NATIVES + "-" + os][LibOperation.URL].ToString();
        }
    }
    public class Natives
    {
        public string linux { get; } = null;
        public string osx { get; } = null;
        public string windows { get; } = null;
        public Natives(JToken jToken)
        {
            linux = jToken[LibOperation.NATIVES][LibOperation.LINUX] != null ? jToken[LibOperation.NATIVES][LibOperation.LINUX].ToString() : null;
            osx = jToken[LibOperation.NATIVES][LibOperation.OSX] != null ? jToken[LibOperation.NATIVES][LibOperation.OSX].ToString() : null;
            windows = jToken[LibOperation.NATIVES][LibOperation.WINDOWS] != null ? jToken[LibOperation.NATIVES][LibOperation.WINDOWS].ToString() : null;
        }
    }
}
