using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LauncherLib.Lang.Event
{
    public class ColoredConsoleEventArgs:EventArgs
    {
        public string Message { get; }
        public ConsoleColor color { get; }
        public ColoredConsoleEventArgs(string _msg,ConsoleColor _color)
        {
            Message = _msg;
            color = _color;
        }
    }
}
