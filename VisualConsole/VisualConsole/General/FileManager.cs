using System;
using System.IO;
using System.Threading.Tasks;

namespace VisualConsole.General
{
    static class FileManager
    {
        public static readonly string workingDir = Directory.GetCurrentDirectory();
        public static bool projectDirFound{ get; private set; } = false;

        public static string ReadAllText(string path) => File.ReadAllText(workingDir + "\\" + path);
        public static string[] ReadLines(string path) => File.ReadAllLines(workingDir + "\\" + path);
        public static string[] GetAllFileNames(string path) => Directory.GetFiles(workingDir + "\\" + path);
        //public static string GetFileName(string path) => File.

        public static string projectDir = "";

        /// <summary>
        /// Copies your work in your project directory to your Debug or Release build directory
        /// </summary>
        public static void AttemptCopyOfProjectFiles()
        {
            try
            {
                Console.WriteLine("Setting up your resources...");

                if (!Directory.Exists(workingDir + "\\sprites"))
                    Directory.CreateDirectory(workingDir + "\\sprites");

                if (!Directory.Exists(workingDir + "\\_audio"))
                    Directory.CreateDirectory(workingDir + "\\_audio");

                projectDir = Directory.GetParent(workingDir).Parent.Parent.ToString();
                
                if (Directory.Exists(projectDir + "\\sprites"))
                {
                    projectDirFound = true;
                    Console.WriteLine("Removing sprites...");
                    Directory.Delete($"{workingDir}\\sprites", true);
                    Console.WriteLine("Removing audio...");
                    Directory.Delete($"{workingDir}\\_audio", true);
                    Console.WriteLine("Adding current sprites in project directory...");
                    DirectoryCopy($"{projectDir}\\sprites", $"{workingDir}\\sprites", true);
                    Console.WriteLine("Adding current audio in project directory...");
                    DirectoryCopy($"{projectDir}\\_audio", $"{workingDir}\\_audio", true);
                    File.Create(projectDir + "\\debug.txt").Dispose();
                }
            }
            catch
            {
                return;
            }
        }

        public static string GetParent(string path)
        {
            return Directory.GetParent(path).FullName;
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
