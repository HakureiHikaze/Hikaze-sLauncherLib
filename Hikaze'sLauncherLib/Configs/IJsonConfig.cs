using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace LauncherLib.Configs
{
    interface IJsonConfig
    {
        JObject UpdateJsonObj();
        bool WriteJsonObj();
    }
}
