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
        public static void Convert(string imgName, string destination, string fileName)
        {
            const int MAX = 126;
            const int MIN = 33;

            using (Bitmap bmp = new Bitmap(Image.FromFile(imgName), 100, 30))
            {
                using (StreamWriter writer = new StreamWriter($@"{destination}\{fileName}.txt"))
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {

                            Color color = bmp.GetPixel(x, y);
                            
                            byte toUse = (byte)(((color.R + color.G + color.B) / 3) / 3);
                            
                            
                            writer.Write((char)(toUse + MIN));

                        }
                        writer.Write('\n');
                    }
                }
            }
        }

        /*static byte Cap(byte input,byte min, byte max)
        {
            if (input >= max)
            {
                return 32;
            }else if (input <= min)
            {
                return min;
            }

            return input;
        }*/
    }
}
