using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LauncherLib.Utilities;
using Newtonsoft.Json.Linq;
namespace LauncherLib.Configs
{
    using WindowSize = OrderedPair;
    using Memory = OrderedPair;
    public class Config
    {
        const string DefaultJVMArgs = 
            "-XX:+UseG1GC "+
            "-XX:MaxGCPauseMillis=30 "+
            "-XX:-UseAdaptiveSizePolicy "+
            "-XX:-OmitStackTraceInFastThrow ";
        const string DefaultMCArgs =
            "-Dfml.ignoreInvalidMinecraftCertificates=true "+
            "-Dfml.ignorePatchDiscrepancies=true ";
        const int DefaultMinMem = 1024;
        const int DefaultMaxMem = 1024;
        const int DefaultWinWid = 854;
        const int DefaultWinHgt = 480;
        const string DefaultGamePath = @".\.minecraft";
        public PlayerInfo player;
        /// <summary>
        /// x for MinMemory; 
        /// y for MaxMemory
        /// </summary>
        public Memory memory;
        public string JavaPath;
        public string GamePath;
        /// <summary>
        /// x for width; 
        /// y for height
        /// </summary>
        public WindowSize windowSize;
        public string JVMArguments;
        public string MCArguments;
        public string Server;
        public bool EnterServer;
        public Config(JObject ConfigJson)
        {
            memory.x        = ConfigJson != null ? ConfigJson["MinMem"]         != null ? Convert.ToInt32(ConfigJson["MinMem"].ToString())          : DefaultMinMem             : DefaultMinMem;
            memory.y        = ConfigJson != null ? ConfigJson["MaxMem"]         != null ? Convert.ToInt32(ConfigJson["MaxMem"].ToString())          : DefaultMaxMem             : DefaultMaxMem;
            JavaPath        = ConfigJson != null ? ConfigJson["JavaPath"]       != null ? ConfigJson["JavaPath"].ToString()                         : PathTools.GetJavaPath()   : PathTools.GetJavaPath();
            GamePath        = ConfigJson != null ? ConfigJson["GamePath"]       != null ? ConfigJson["GamePath"].ToString()                         : DefaultGamePath           : DefaultGamePath;
            JVMArguments    = ConfigJson != null ? ConfigJson["JVMArguments"]   != null ? ConfigJson["JVMArguments"].ToString()                     : DefaultJVMArgs            : DefaultJVMArgs;
            MCArguments     = ConfigJson != null ? ConfigJson["MCArguments"]    != null ? ConfigJson["MCArguments"].ToString()                      : DefaultMCArgs             : DefaultMCArgs;
            windowSize.x    = ConfigJson != null ? ConfigJson["WindowWidth"]    != null ? Convert.ToInt32(ConfigJson["WindowWidth"].ToString())     : DefaultWinWid             : DefaultWinWid;
            windowSize.y    = ConfigJson != null ? ConfigJson["WindowHeight"]   != null ? Convert.ToInt32(ConfigJson["WindowHeight"].ToString())    : DefaultWinHgt             : DefaultWinHgt;
            Server          = ConfigJson != null ? ConfigJson["Server"]         != null ? ConfigJson["Server"].ToString()                           : null                      : null;
            EnterServer     = ConfigJson != null ? ConfigJson["EnterServer"]    != null ? Convert.ToInt32(ConfigJson["EnterServer"].ToString()) != 0 ? true : false : false : false;
            player =
                ConfigJson != null ?
                    ConfigJson["player"] != null ?
                        ConfigJson["player"]["Name"] != null && ConfigJson["Player"]["UUID"] != null ?
                            new PlayerInfo(ConfigJson["player"]["Name"].ToString(), ConfigJson["player"]["UUID"].ToString()) :
                        new PlayerInfo("SetName") :
                    new PlayerInfo("SetName") :
                new PlayerInfo("SetName");
        }
    }
}
