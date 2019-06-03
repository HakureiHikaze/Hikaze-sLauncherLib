using LauncherLib.Lang.Event;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LauncherLib.Utilities;
using LauncherLib.Configs;
namespace LauncherLib.ArgHandler
{
    public class ThisGame
    {
        public event EventHandler<IntegerMsgArgs> GetStatus;
        public List<string> VersionList;
        public string GamePath { get; }
        public string OS;
        public bool isArch64;
        public Config CurrentConfig;
        public string ConfigPath { get; }
        public ThisGame(string _GamePath,string _ConfigPath)
        {
            isArch64 = Environment.Is64BitOperatingSystem;
            OS = Environment.OSVersion.VersionString;
            GamePath = _GamePath;
            ConfigPath = _ConfigPath;
            CurrentConfig = new Config(JsonHandler.ReadAnyJson(ConfigPath+@"\Config.json"));
            VersionList = new List<string>(Directory.EnumerateDirectories(GamePath + @"\versions"));
            for (int i = 0; i < VersionList.Count; i++)
            {
                VersionList[i] = VersionList[i].Replace(GamePath + @"\versions\", "");
            }
        }
        public void MakeConfig(string FullPath)
        {
            File.WriteAllText(FullPath, CurrentConfig.JsonNewConfig().ToString());
        }
        public void SetPlayerName(string NewName)
        {
            CurrentConfig.player.Name = NewName;
        }
        public override string ToString()
        {
            return 
                "isArch64:\t\t" +isArch64.ToString()+"\n"+
                "OS:\t\t\t\t" + OS + "\n" +
                "GamePath:\t\t" + GamePath + "\n" +
                "ConfigPath:\t\t" + ConfigPath + "\n" +
                "Config:\n{\n" + CurrentConfig.ToString() + "}";
        }
    }
}
