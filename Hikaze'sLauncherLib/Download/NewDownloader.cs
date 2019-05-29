using LauncherLib.Lang.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace LauncherLib.Download
{
    class NewDownloader
    {
        public string path { get; }
        public int size { get; }
        public string SHA1 { get; }
        public string url { get; }

        public event EventHandler<DownloadEventArgs> DownloadProcessChanged;
        public bool ChechSHA1()
        {
            try
            {
                FileStream file = new FileStream(path, FileMode.Open);
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] retval = sha1.ComputeHash(file);
                file.Close();
                StringBuilder stringBuilder = new StringBuilder();
                for(int i =0;i<retval.Length;i++)
                {
                    stringBuilder.Append(retval[i].ToString("x2"));
                }
                if(stringBuilder.ToString() == SHA1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
        public static bool CheckSHA1(string path, string SourceSHA1)
        {
            try
            {
                FileStream file = new FileStream(path, FileMode.Open);
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] retval = sha1.ComputeHash(file);
                file.Close();
                StringBuilder sc = new StringBuilder();
                for (int i = 0; i < retval.Length; i++)
                {
                    sc.Append(retval[i].ToString("x2"));
                }
                if (sc.ToString() == SourceSHA1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
