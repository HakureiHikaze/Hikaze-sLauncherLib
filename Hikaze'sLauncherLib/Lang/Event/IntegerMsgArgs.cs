using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LauncherLib.Lang.Event
{
    public class IntegerMsgArgs:EventArgs
    {
        public int msg;
        public IntegerMsgArgs(int _msg)
        {
            msg = _msg;
        }
    }
}
