using System;
using System.IO;
using System.Linq;

namespace VisualConsole{
    public class Sprite : MapObject, IRenderable{
        public char[,] content;
        public int maxWidth {get; private set;}
        public int maxHeight {get; private set;}
        /// <summary>
        /// Spawns a text object based on its content in the file
        /// </summary>
        /// <param name="sprite">Name of sprite that is in the sprites folder</param>
        public Sprite(string sprite, Vector2 position, Vector2 size = null, ConsoleColor color = ConsoleColor.White){
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

        public new void Render(Action action = null, Vector2 chosenPos = null){
            char currentChar;

            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    if (x <= maxWidth - 1 && y <= maxHeight - 1){
                        currentChar = content[x, y];
                        Map.map[position.x + x, position.y + y] = this;
                        Console.SetCursorPosition(position.x + x, position.y + y);
                    }
                    else
                        currentChar = Map.background;

                    Console.ForegroundColor = color;
                    Console.Write(currentChar);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}