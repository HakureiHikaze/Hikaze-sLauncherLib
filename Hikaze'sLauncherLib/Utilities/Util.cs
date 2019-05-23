using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;

namespace LauncherLib.Utilities
{
    public static class Utils
    {
        public static int getPairedSign(string input, int j)
        {
            for (int i =j+1; i<input.Length; i++)
            {
                if (input[i] == '\"')
                {
                    return i;
                }
            }
            return j;
        }
    }
    public static class PathTools
    {
        public static string GetJavaPath()
        {
            if (Environment.GetEnvironmentVariable("JAVA_HOME")!=null)
            {
                return Environment.GetEnvironmentVariable("JAVA_HOME") + @"bin\javaw.exe ";
            }
            else
            {
                RegistryKey Software = Registry.LocalMachine.OpenSubKey("SOFTWARE");
                foreach (string SubName in Software.GetSubKeyNames())
                {
                    if (SubName == "JavaSoft")
                    {
                        RegistryKey JavaSoft = Software.OpenSubKey("JavaSoft");
                        foreach (string SubJavaName in JavaSoft.GetSubKeyNames())
                        {
                            if (SubJavaName == "Java Runtime Environment")
                            {
                                RegistryKey JRE = JavaSoft.OpenSubKey("Java Runtime Environment");
                                return JRE.OpenSubKey(JRE.GetValue("CurrentVersion").ToString()).GetValue("JavaHome").ToString() + @"\bin\javaw.exe ";
                            }
                            else if (SubJavaName == "Java Development Kit")
                            {
                                RegistryKey JDK = JavaSoft.OpenSubKey("Java Development Kit");
                                return JDK.OpenSubKey(JDK.GetValue("CurrentVersion").ToString()).GetValue("JavaHome").ToString() + @"\jre\bin\javaw.exe";
                            }
                            else return "0";
                        }
                    }
                    else return "0";
                }
                return "0";
            }
        }
    }
    public static class CheckAndDownload
    {
        public static void CheckFile()
        {

        }
    }
    public struct OrderedPair
    {
        public int x;
        public int y;
        public OrderedPair(int _x,int _y)
        {
            x = _x;
            y = _y;
        }
    }
    
}
