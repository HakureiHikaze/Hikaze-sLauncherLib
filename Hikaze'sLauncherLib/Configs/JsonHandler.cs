using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LauncherLib.Configs
{
    public static class JsonHandler
    {
        public static JObject ReadVersionJson(string GamePath,string GameVersion)
        {
            System.IO.StreamReader JsonFile = System.IO.File.OpenText(GamePath + @"\versions\" + GameVersion + @"\" + GameVersion + ".json");
            JsonTextReader reader = new JsonTextReader(JsonFile);
            JObject JReading = (JObject)JToken.ReadFrom(reader);
            return JReading;
        }
        public static JObject ReadAnyJson(string path)
        {
            if (path == null)
            {
                return null;
            }
            System.IO.StreamReader JsonFile = System.IO.File.OpenText(path);
            JsonTextReader reader = new JsonTextReader(JsonFile);
            JObject JReading = (JObject)JToken.ReadFrom(reader);
            return JReading;
        }
        public static void WriteJson(JObject json,string path)
        {
            File.WriteAllText(path, json.ToString(Newtonsoft.Json.Formatting.Indented), null);
        }
    }
}
