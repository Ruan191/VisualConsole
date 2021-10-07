using System;
using System.IO;

namespace VisualConsole
{
    static class FileManager
    {
        public static readonly string workingDir = Directory.GetCurrentDirectory();

        public static string ReadAllText(string path) => File.ReadAllText(workingDir + "\\" + path);
        public static string[] ReadLines(string path) => File.ReadAllLines(workingDir + "\\" + path);
        public static string[] GetAllFileNames(string path) => Directory.GetFiles(workingDir + "\\" + path);
        //public static string GetFileName(string path) => File.

        public static string projectDir = "";

        public static void AttemptCopyOfProjectFiles()
        {
            try
            {
                projectDir = Directory.GetParent(workingDir).Parent.Parent.ToString();
                Directory.Delete($"{workingDir}\\sprites", true);
                DirectoryCopy($"{projectDir}\\sprites", $"{workingDir}\\sprites", true);
                File.Copy($"{projectDir}\\settings.json", $"{workingDir}\\settings.json");
            }
            catch
            {
                return;
            }
        }

        //https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories

        static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            DirectoryInfo[] dirs = dir.GetDirectories();
   
            Directory.CreateDirectory(destDirName);

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, true);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }
    }
}
