using System;
using System.IO;
using System.Linq;

namespace Game{
    public class Sprite : MapObject{
        public char[,] content;
        
        public Sprite(string sprite, Vector2 position, ConsoleColor color = ConsoleColor.Black){
            string[] linesContent = FileManager.ReadLines("\\sprites\\" + sprite);
            this.color = color;
            size = new Vector2(linesContent.Max<string>().Length, linesContent.Length);
            this.position = position;
            content = new char[size.x, size.y];

            for (int i = 0; i < linesContent.Length; i++){
                for (int k = 0; k < linesContent[i].Length; k++){
                    content[k, i] = linesContent[i][k];
                }
            }
        }

    }
}