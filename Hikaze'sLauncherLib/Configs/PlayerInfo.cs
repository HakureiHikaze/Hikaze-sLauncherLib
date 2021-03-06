﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LauncherLib.Configs
{
    public class PlayerInfo
    {
        public string Name;
        public readonly string UUID;
        public PlayerInfo(string _Name)
        {
            UUID = Guid.NewGuid().ToString();
            Name = _Name;
        }
        public PlayerInfo(string _Name,string _UUID)
        {
            UUID = _UUID;
            Name = _Name;
        }
    }
}
