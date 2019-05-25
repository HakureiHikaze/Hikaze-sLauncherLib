using LauncherLib.Download;
using LauncherLib.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherLib.Upgrader
{
    //public static class PackageMaker
    //{
    //    public static Package MakePackage(string GamePath)
    //    {
    //        //TODO
    //        return null;
    //    }
    //    //public static Package GenerateInfoFromZIP(string )
    //    //TODO
    //}
    public static class PackageDownloader
    {
        static string RESOURCESURL = "https://resources.eod.moe";
        static List<string> sha1List;
        public static void InitializePackageDownloader()
        {
            sha1List = new List<string>();
        }
        public static void moveCache(string Des,bool willDelete,bool willOverwrite)
        {

            if (willDelete)
            {
                Utils.DeleteFolder(Des);
                Directory.CreateDirectory(Des);
                Utils.CopyFile(@".\HikazeLauncher\temp", Des, true);
            }
            Utils.CopyFile(@".\HikazeLauncher\temp", Des, willOverwrite);
        }
        //public static void moveCache(string Des,List<string> DeleteList)
        //{

        //}
        //TODO
        public static void Unpackage(string sha1)
        {
            if (sha1List != null)
            {
                foreach(string element in sha1List)
                {
                    Unzipper.UnZip(@"\HikazeLauncher\download\" + sha1 + ".zip", @".\HikazeLauncher\temp");
                }
            }
            else
            {
                throw new NullReferenceException("sha1List Empty");
            }
        }
        public static void PackageDownload(Index index)
        {
            string url;
            string localPath;
            Queue<DownloadTask> tasks = new Queue<DownloadTask>();
            if (!Directory.Exists(@".\HikazeLauncher\download"))
            {
                Utils.CreateDir(@".\HikazeLauncher\download");
            }
            if (!Directory.Exists(@".\HikazeLauncher\temp"))
            {
                Utils.CreateDir(@".\HikazeLauncher\temp");
            }
            foreach (JFiles files in index.files)
            {
                url = RESOURCESURL + "/objects/" + files.sha1.Substring(0, 2) + "/" + files.sha1 + ".zip";
                localPath = @".\HikazeLauncher\temp\"+ files.sha1 + ".zip";
                tasks.Enqueue(new DownloadTask(url, localPath, files.sha1, files.size));
                sha1List.Add(files.sha1);
            }
            MultiDownloader multiDownloader = new MultiDownloader(tasks, 3, false);

        }
    }
    public class Package
    {
        public static readonly string HikazeResources = "https://resources.eod.moe";
        public string Name { get; }
        public string sha1 { get; }
        public int size { get; }
        public string mainVersion { get; }
        public int subVersion { get; }
        public string localPath { get; }
        public string Url { get; }
    }
    public class Version
    {
        public string mainVersion{get;}=null;
        public string subVersion{get;}=null;
        public string projectName{get;}=null;
        public string releaseTime{get;}=null;
        public Version(JToken versionJson)
        {
            mainVersion = versionJson["mainVersion"] !=null? versionJson["mainVersion"].ToString():null;
            subVersion = versionJson["subVersion"] !=null? versionJson["subVersion"].ToString():null;
            projectName = versionJson["projectName"] !=null? versionJson["projectName"].ToString():null;
            releaseTime = versionJson["releaseTime"] !=null? versionJson["releaseTime"].ToString():null;
        }
    }
    public class JFiles
    {
        public string sha1 {get;}
        public int size { get; }
        public JFiles(JToken fileJson)
        {
            sha1 = fileJson["sha1"].ToString();
            size = Convert.ToInt32(fileJson["size"].ToString());
        }
    }
    public class Index
    {
        public string Name{get;}
        public List<JFiles> files{get;}
        Version version{get;}
        public bool enabled{get;}
        public Index(JToken indexJson)
        {
            version = new Version(indexJson["version"]);
            Name = version.projectName+"-"+version.mainVersion+"-"+version.subVersion;
            files = new List<JFiles>();
            foreach(JToken element in indexJson["files"])
            {
                files.Add(new JFiles(element));
            }
            enabled = Convert.ToBoolean(indexJson["enabled"].ToString());//TODO:convert to boolean
        }
    }
    public class rootIndex
    {
        List<Index> indexes{get;}
        public rootIndex(JObject rootJson)
        {
            indexes = new List<Index>();
            foreach(JToken element in rootJson["Indexes"])
            {
                indexes.Add(new Index(element));
            }
        }
    }
}
