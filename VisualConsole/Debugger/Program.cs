using System;
using System.Threading.Tasks;
using System.IO;

namespace Debugger
{
    public class Program
    {
        static void Main(string[] args)
        {
            string toCompare = "";
            DirectoryInfo directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
            while (true)
            {
                using (var reader = new FileStream($@"{directoryInfo}\debug.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    string text = "";

                    while (reader.Position < reader.Length)
                    {
                        text += (char)reader.ReadByte();
                    }

                    if (text != toCompare && text != "")
                    {
                        Console.WriteLine(text);
                        toCompare = text;
                    }
                }
                
                Task.Delay(41).Wait();
            }
        }
    }
}
