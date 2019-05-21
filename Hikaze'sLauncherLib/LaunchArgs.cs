using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
namespace LauncherLib
{
    public static class LaunchArgs
    {
        public static string GetFullLibArgs(string GamePath, string GameVersion)
        {
            ArrayList LibList = GetListFormJObject(GamePath, GameVersion);
            LibList = ConvertListedPathFromPackageList(GamePath, LibList);
            LibList = RemoveDuplicates(LibList);
            string ReturnString = @"-cp ";
            for (int i = 0; i < LibList.Count; i++)
            {
                ReturnString +=GamePath+@"\libraries\"+ LibList[i] + ";";
            }
            return ReturnString;
        }
        public static ArrayList GetListFormJObject(string GamePath, string GameVersion, string OldGameVersion = null)
        {
            ArrayList LibList = new ArrayList();
            JObject ReadingJson = JsonHandler.ReadJson(GamePath, GameVersion);
            if (ReadingJson["inheritsFrom"] != null)
            {
                LibList.AddRange(GetListFormJObject(GamePath, ReadingJson["inheritsFrom"].ToString(), GameVersion));
            }
            foreach (JToken lib in ReadingJson["libraries"])
            {
                if (lib["natives"] != null)
                {
                    if (lib["natives"]["windows"] != null)
                    {
                        if (string.IsNullOrEmpty(OldGameVersion))
                        {
                            Unzipper.UnZip(GamePath + @"\libraries\" + ConvertPackageToPath( lib["name"].ToString(), lib["natives"]["windows"].ToString()),
                                                        GamePath + @"\versions\" + GameVersion + @"\" + GameVersion + @"-natives");
                        }
                        else
                        {
                            Unzipper.UnZip(GamePath + @"\libraries\" + ConvertPackageToPath( lib["name"].ToString(), lib["natives"]["windows"].ToString()),
                                                        GamePath + @"\versions\" + OldGameVersion + @"\" + OldGameVersion + @"-natives");
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    LibList.Add(lib["name"]);
                }
            }
            return LibList;
            //TODO:分流非Natives并解压Natives
        }
        public static ArrayList ConvertListedPathFromPackageList(string GamePath, ArrayList OriginalArrayList)
        {
            for (int i = 0; i < OriginalArrayList.Count; i++)
            {
                OriginalArrayList[i] = ConvertPackageToPath( OriginalArrayList[i].ToString(), null);
            }
            return OriginalArrayList;
        }
        public static string ConvertPackageToPath( string PackageName, string Natives)
        {
            if (string.IsNullOrEmpty(Natives))
            {
                string re = "";
                bool Colon = false;
                for (int i = 0; i < PackageName.Length; i++)
                {
                    if (PackageName[i] == '.')
                    {
                        if (Colon)
                        {
                            if ((('0' <= PackageName[i - 1] && PackageName[i - 1] <= '9') && ('0' <= PackageName[i + 1] && PackageName[i + 1] <= '9'))
                                || (('0' <= PackageName[i - 1] && PackageName[i - 1] <= '9') && (PackageName[i + 1] == 'F')))//这是个特殊情况
                            {
                                re += ".";
                            }
                            else
                            {
                                re += "\\";
                            }
                        }
                        else
                        {
                            re += "\\";
                        }
                    }
                    else if (PackageName[i] == ':')
                    {
                        Colon = true;
                        re += "\\";
                        continue;
                    }
                    else
                    {
                        re += PackageName[i];
                    }
                }
                Colon = false;
                re += @"\";
                for (int i = 0; i < PackageName.Length; i++)
                {
                    if (PackageName[i] == ':')
                    {
                        if (Colon)
                        {
                            re += "-";
                            continue;
                        }
                        Colon = true;
                    }
                    else if (Colon)
                    {
                        re += PackageName[i];
                    }
                }
                Colon = false;
                return re + ".jar";
            }
            else
            {
                string re = "";
                bool Colon = false;
                for (int i = 0; i < PackageName.Length; i++)
                {
                    if (PackageName[i] == '.')
                    {
                        if (Colon)
                        {
                            if ((('0' <= PackageName[i - 1] && PackageName[i - 1] <= '9') && ('0' <= PackageName[i + 1] && PackageName[i + 1] <= '9'))
                                || (('0' <= PackageName[i - 1] && PackageName[i - 1] <= '9') && (PackageName[i + 1] == 'F')))
                            {
                                re += ".";
                            }
                            else
                            {
                                re += "\\";
                            }
                        }
                        else
                        {
                            re += "\\";
                        }
                    }
                    else if (PackageName[i] == ':')
                    {
                        Colon = true;
                        re += "\\";
                        continue;
                    }
                    else
                    {
                        re += PackageName[i];
                    }
                }
                Colon = false;
                re += @"\";
                for (int i = 0; i < PackageName.Length; i++)
                {
                    if (PackageName[i] == ':')
                    {
                        if (Colon)
                        {
                            re += "-";
                            continue;
                        }
                        Colon = true;
                    }
                    else if (Colon)
                    {
                        re += PackageName[i];
                    }
                }
                Colon = false;
                return re + "-" + Natives + ".jar";
            }
            //TODO:转换包名为文件路径，若为Natives则返回其完整路径
        }
        public static ArrayList RemoveDuplicates(ArrayList OriginalArrayList)
        {
            //TODO:去重
            for (int i = 0; i < OriginalArrayList.Count; i++)
            {
                for (int j = i + 1; j < OriginalArrayList.Count; j++)
                {
                    if (OriginalArrayList[i].ToString() == OriginalArrayList[j].ToString())
                    {
                        OriginalArrayList.RemoveAt(j);
                        j--;
                    }
                }
            }
            return OriginalArrayList;
        }
    }
}
