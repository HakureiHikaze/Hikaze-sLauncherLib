using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using LauncherLib.Utilities;
using Newtonsoft.Json.Linq;
namespace LauncherLib.Configs
{
    using WindowSize = OrderedPair;
    using Memory = OrderedPair;
    public class Config:IJsonConfig
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
        JObject ConfigJson;
        public Config(JObject jObject)
        {
            ConfigJson = jObject;
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
                    ConfigJson["Player"] != null ?
                        ConfigJson["Player"]["Name"] != null && ConfigJson["Player"]["UUID"] != null ?
                            new PlayerInfo(ConfigJson["Player"]["Name"].ToString(), ConfigJson["Player"]["UUID"].ToString()) :
                        new PlayerInfo("SetName") :
                    new PlayerInfo("SetName") :
                new PlayerInfo("SetName");
        }
        
        public JObject JsonNewConfig()
        {
            JObject jObject = new JObject
                (
                    new JProperty("GamePath", GamePath),
                    new JProperty("JavaPath",JavaPath),
                    new JProperty("MinMem",memory.x),
                    new JProperty("MaxMem",memory.y),
                    new JProperty("JVMArguments",JVMArguments),
                    new JProperty("MCArguments", MCArguments),
                    new JProperty("WindowWidth", windowSize.x),
                    new JProperty("WindowHeight",windowSize.y),
                    new JProperty("Server",Server),
                    new JProperty("EnterServer",EnterServer == true?1:0),
                    new JProperty
                    (
                        "Player",
                        new JObject
                        (
                            new JProperty("Name",player.Name),
                            new JProperty("UUID",player.UUID)
                        )
                    )
                ); 
            return jObject;
        }
        public JObject UpdateJsonObj()
        {
            return ConfigJson;
        }

        public bool WriteJsonObj()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return 
                "MinMem:\t\t\t" +memory.x.ToString()+"\n"+
                "MaxMem:\t\t\t" + memory.y.ToString()+"\n" +
               "JavaPath:\t\t"+JavaPath+"\n" +
               "GamePath:\t\t"+GamePath+"\n" +
               "JVMArgs:\t\t"+JVMArguments+"\n" +
               "MCArgs:\t\t\t" + MCArguments+"\n" +
               "PlayerName:\t\t"+player.Name+"\n" +
               "PlayerUUID:\t\t"+player.UUID+"\n" +
               "WindowWidth:\t"+windowSize.x+"\n" +
               "WindowHeight:\t"+windowSize.y+"\n" +
               "Server:\t\t\t" + Server+"\n" +
               "EnterServer:\t" +EnterServer.ToString()+ "\n";
        }
    }
}
