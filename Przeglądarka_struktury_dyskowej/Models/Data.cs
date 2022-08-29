using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Przeglądarka_struktury_dyskowej.Models
{

    public class Data
    {
        
        public List<string> GetValues(string path)
        {
            string DirName = @"C:\Users\rataj\Desktop\exe";
            string[] files =Directory.GetFiles(DirName+path);
            string[] dir=Directory.GetDirectories(DirName+path);
            return Makelist(files, dir);
        }
        private List<string> Makelist(string[] fiArr, string[] dir)
        {
            List<string> filesInformation = new List<string>();
            foreach (string s in dir)
            {
                FileInfo di = new FileInfo(s);
                filesInformation.Add(GetDirInfo(di));
            }
            foreach (string s in fiArr)
            {
                FileInfo fi = new FileInfo(s);
                filesInformation.Add(GetFileInfo(fi));
            }
            return filesInformation;
        }
        private string GetFileInfo(FileInfo fi)
        {
            string info = (
                fi.Extension + "*" +
                fi.Name + "*" +
                fi.LastWriteTime.ToString() + "*" +
                fi.Length.ToString() + "*" +
                fi.Attributes.ToString());
            return info;
        }
        private string GetDirInfo(FileInfo fi)
        {
            string info = (
                fi.Extension + "*" +
                fi.Name + "*" +
                fi.LastWriteTime.ToString() + "*" +
                fi.Attributes.ToString());
            return info;
        }
    }
}