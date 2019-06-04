using LauncherLib.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LauncherLib.Lang.Event
{
    public class ConfigChangedEventArgs:EventArgs
    {
        public Config config;
        public ConfigChangedEventArgs(Config _config)
        {
            config = _config;
        }
    }
}
