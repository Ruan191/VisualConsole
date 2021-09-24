using System;
using System.IO;

namespace Game{
    static class FileManager{
        public static readonly string workingDir = Directory.GetCurrentDirectory();
        
        public static string ReadAllText(string path) => File.ReadAllText(workingDir + "\\" + path);
    }
}