using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LauncherLib.Configs;
using System.Diagnostics;
using System.Collections;

namespace LauncherLib.Assets
{
    public class IndexObjects
    {
        public static readonly string MOJANGURL = "https://resources.download.minecraft.net";
        public static readonly string BMCLURL = "https://bmclapi2.bangbang93.com/assets";
        public bool isBMCLMirror { get; } = false;
        public List<SingleObject> ObjList { get; } = null;
        public List<string> hashlist = null;
        public IndexObjects(string GamePath,string GameVersion,bool _isBMCL)
        {
            isBMCLMirror = _isBMCL;
            JObject JOVersion =  JsonHandler.ReadVersionJson(GamePath, GameVersion);
            hashlist = new List<string>();
            if (JOVersion["assetIndex"] != null)
            {
                ObjList = new List<SingleObject>();
                AddObjs(GamePath, JOVersion["assetIndex"]["id"].ToString());
            }
            else
            {
                if(JOVersion["inheritsFrom"] != null)
                {
                    ObjList = new List<SingleObject>();
                    JOVersion = JsonHandler.ReadVersionJson(GamePath, JOVersion["inheritsFrom"].ToString());
                    AddObjs(GamePath,JOVersion["assetIndex"].ToString());
                }
            }
        }
        void AddObjs(string GamePath,string assetIndex)
        {
            JObject IndexJson = JsonHandler.ReadAnyJson(GamePath + @"\assets\indexes\" + assetIndex + ".json");
            foreach(JToken element in IndexJson["objects"].Children())
            {
                
                string name = element.ToString().Substring(element.ToString().IndexOf('\"')+1, Utilities.Utils.getPairedSign(element.ToString(), 0)-1);
                //Debug.WriteLine(IndexJson["objects"][name]);
                SingleObject obj = new SingleObject(name, IndexJson["objects"][name],!isBMCLMirror?MOJANGURL:BMCLURL);
                if (hashlist.IndexOf(obj.sha1) != -1)
                {
                    continue;
                }
                hashlist.Add(obj.sha1);
                ObjList.Add(obj);
            }
        }
        public void debugWriteObjList()
        {
            foreach(SingleObject element in ObjList)
            {
                Debug.WriteLine("name: {0}\nsha1: {1}\nsize: {2}\ninit: {3}\npath: {4}\nhalfUrl: {5}\nurl: {6}\n",
                    element.name,
                    element.sha1,
                    element.size,
                    element.init,
                    element.path,
                    element.halfUrl,
                    element.url
                    );
            }
        }
    }
    public class SingleObject
    {
        public string name { get; }
        public string sha1 { get; }
        public int size { get; }
        public string init { get; } = "  ";
        public string path { get; }
        public string halfUrl { get; }
        public string url { get; }
        public SingleObject(string _name,JToken jToken,string initUrl)
        {
            name = _name;
            sha1 = jToken["hash"] != null ? jToken["hash"].ToString() : null;
            size = jToken["size"] != null ? Convert.ToInt32(jToken["size"].ToString()):0;
            init = sha1 != null ? sha1.Substring(0, 2) : null;
            path = sha1 != null ? init + @"\" + sha1:null;
            halfUrl = path != null ? path.Replace(@"\", "/"):null;
            url = initUrl + "/" + halfUrl;
        }
    }
}
