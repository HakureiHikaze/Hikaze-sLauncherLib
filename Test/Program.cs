using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using LauncherLib;
using Newtonsoft.Json.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject jObject = JsonHandler.ReadJson(@"D:\SNv1.12.2\.minecraft", "1.12.2");
            foreach (JToken elements in jObject["libraries"])
            {
                Libraries lib = new Libraries(LibOperation.GetLibType(elements), elements, @"D:\SNv1.12.2\.minecraft");
                Debug.Write(lib.fullPath+"\n"+lib.isUseful+"\n"+File.Exists(lib.fullPath)+"\n");
                Debug.WriteLine(lib.url);
                Downloader.download("http://files.minecraftforge.net/maven/net/minecraftforge/forge/1.12.2-14.23.5.2831/forge-1.12.2-14.23.5.2831.jar", @".");
            }
        }
    }
}
