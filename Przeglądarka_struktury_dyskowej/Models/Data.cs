using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Przeglądarka_struktury_dyskowej.Models
{

    public class Data
    {
        public List<string> GetValues(string path)
        {
            string[] files =Directory.GetFiles(path);
            string[] dir=Directory.GetDirectories(path);
            return Makelist(files, dir);
        }
        private List<string> Makelist(string[] fileArr, string[] dirArr)
        {
            List<string> filesInformation = new List<string>();
            foreach (string s in dirArr)
            {
                FileInfo directory = new FileInfo(s);
                filesInformation.Add(GetDirInfo(directory));
            }
            foreach (string s in fileArr)
            {
                FileInfo file = new FileInfo(s);
                filesInformation.Add(GetFileInfo(file));
            }
            return filesInformation;
        }
        private string GetFileInfo(FileInfo fileInfo)
        {
            string info = (
                fileInfo.Extension + "*" +
                fileInfo.Name + "*" +
                fileInfo.LastWriteTime.ToString() + "*" +
                fileInfo.Length.ToString() + "*" +
                fileInfo.Attributes.ToString());
            return info;
        }
        private string GetDirInfo(FileInfo dirInfo)
        {
            string info = (
                dirInfo.Extension + "*" +
                dirInfo.Name + "*" +
                dirInfo.LastWriteTime.ToString() + "*" +
                dirInfo.Attributes.ToString());
            return info;
        }
    }
}