using System;
using System.IO;

namespace Game{
    static class FileManager{
        public static readonly string workingDir = Directory.GetCurrentDirectory();
        
        public static string ReadAllText(string path) => File.ReadAllText(workingDir + "\\" + path);
        public static string[] ReadLines(string path) => File.ReadAllLines(workingDir + "\\" + path);
        public static string[] GetAllFileNames(string path) => Directory.GetFiles(workingDir + "\\" + path);

    }
}