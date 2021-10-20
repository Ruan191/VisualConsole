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

            using (var reader = new FileStream($@"{directoryInfo}\debug.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                while (true)
                {

                    string text = "";

                    while (reader.Position < reader.Length)
                    {
                        text += (char)reader.ReadByte();
                    }

                    if (!text.Equals(toCompare) && text != "")
                    {
                        if (text[0] == '!')
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine(text);
                        toCompare = text;

                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    reader.Position = 0;
                    Task.Delay(41).Wait();
                }
            }
        }
    }
}
