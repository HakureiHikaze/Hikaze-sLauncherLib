using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherLib.Upgrader
{
    public static class PackageMaker
    {
        public static Package MakePackage(string GamePath)
        {
            //TODO
            return null;
        }
        //public static Package GenerateInfoFromZIP(string )
        //TODO
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
}
