using System;
using System.IO;
using System.Linq;

namespace Game{
    public class Sprite : MapObject, IRenderable{
        public char[,] content;
        public int maxWidth {get; private set;}
        public int maxHeight {get; private set;}
        
        public Sprite(string sprite, Vector2 position, Vector2 size = null, ConsoleColor color = ConsoleColor.Black){
            string[] linesContent = FileManager.ReadLines("\\sprites\\" + sprite);
            this.color = color;

            maxWidth = linesContent.Max<string>().Length;
            maxHeight = linesContent.Length;

            if (size == null)
                this.size = new Vector2(maxWidth, maxHeight);
            else
                this.size = size;

            this.position = position;
            content = new char[this.size.x, this.size.y];

            for (int i = 0; i < linesContent.Length; i++){
                if (linesContent[i].Length < maxWidth){
                    linesContent[i] += new String(Map.background, maxWidth - linesContent[i].Length);
                }

                for (int k = 0; k < linesContent[i].Length; k++){
                    char c = linesContent[i][k];;
                    
                    if (c.Equals(' ')){
                        c = Map.background;
                    }

                    content[k, i] = c;
                }
            }
        }

        public void Render(Vector2 at){
            char currentChar;

            for (int y = 0; y < this.size.y; y++)
            {
                for (int x = 0; x < this.size.x; x++)
                {
                    if (x <= this.maxWidth - 1 && y <= this.maxHeight - 1){
                        currentChar = this.content[x, y];
                        Map.map[at.x + x, at.y + y] = this;
                        Console.SetCursorPosition(at.x + x, at.y + y);
                    }
                    else
                        currentChar = Map.background;

                    Console.ForegroundColor = this.color;
                    Console.Write(currentChar);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

    }
}