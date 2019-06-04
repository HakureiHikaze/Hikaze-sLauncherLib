using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace LauncherLib.Utilities
{
    public static class Utils
    {
        public static void ConsoleWriteLineColored(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static int CreateDir(string FullPath)
        {
            try
            {
                if (File.Exists(FullPath))
                {
                    return 0;
                }
                else //判断路径中的文件夹是否存在
                {
                    if(Directory.Exists(FullPath))
                    {
                        return 0;
                    }
                    string dirpath = FullPath.Substring(0, FullPath.LastIndexOf('\\'));
                    string[] pathes = dirpath.Split('\\');
                    if (pathes.Length > 1)
                    {
                        string path = pathes[0];
                        for (int i = 1; i < pathes.Length; i++)
                        {
                            path += "\\" + pathes[i];
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                        }
                    }
                    return 1;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Problem occurred: " + e.Message);
                return -1;
            }
        }
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
        /// <param name="sources">原路徑</param>
        /// <param name="dest">目標路徑</param>        
        public static void CopyFile(string sources, string dest,bool willOverwrite)
        {
            if (Directory.Exists(sources))
            {
                DirectoryInfo dinfo = new DirectoryInfo(sources);//   傳的是文件路徑，所以不能包含後綴名
                foreach (FileSystemInfo f in dinfo.GetFileSystemInfos())
                {
                    //  目標路徑destName = 目標文件夾路徑 + 原文件夾下的子路徑(或文件夾)名字  
                    String destName = Path.Combine(dest, f.Name);
                    if (f is FileInfo)//    如果是文件就复制                     
                    {
                        System.IO.File.Copy(f.FullName, destName, willOverwrite);//  true代表可以覆盖同名文件                     
                    }
                    else//  如果是文件夾就創建文件夾然后复制然后递归复制                     
                    {
                        if (!Directory.Exists(destName))
                        {
                            Directory.CreateDirectory(destName);
                        }
                        CopyFile(f.FullName, destName,willOverwrite);//   遞歸調用                     
                    }
                }
            }
        }
        /// <summary>
        /// 删除文件夹及子文件内文件
        /// </summary>
        /// <param name="str"></param>
        /// <summary>
        /// 递归删除文件夹目录及文件
        /// </summary>
        /// <param name="dir"></param>  
        /// <returns></returns>
        public static void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir)) //如果存在这个文件夹删除之 
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                        File.Delete(d); //直接删除其中的文件                        
                    else
                        DeleteFolder(d); //递归删除子文件夹 
                }
                Directory.Delete(dir, true); //删除已空文件夹                 
            }
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
                            else continue;
                        }
                    }
                    else continue;
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
