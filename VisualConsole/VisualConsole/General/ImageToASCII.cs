using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VisualConsole.General
{
    
    public static class ImageToASCII
    {
        //static string grayScale = @" .:-=+*#%@";
        static string grayScale = @"@%#*+=-:. ";
        public static void Convert(string imgName, string destination, string fileName)
        {
            using (Bitmap bmp = new Bitmap(Image.FromFile(imgName), 220, 60))
            {
                using (StreamWriter writer = new StreamWriter($@"{destination}\{fileName}.txt"))
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {

                            Color color = bmp.GetPixel(x, y);
                            
                            byte toUse = (byte)Math.Abs(((color.R + color.G + color.B) / 3) / 25.6f);
                            writer.Write(grayScale[toUse]);
                        }
                        writer.Write('\n');
                    }
                }
            }
        }
    }
}
