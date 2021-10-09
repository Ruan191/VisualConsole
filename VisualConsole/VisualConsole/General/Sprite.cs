using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualConsole.General
{
    public class Sprite : MapObject, IRenderable
    {
        //public char[,] content;
        public string[] content;
        public int maxWidth { get; private set; }
        public int maxHeight { get; private set; }
        /// <summary>
        /// Spawns a text object based on its content in the file
        /// </summary>
        /// <param name="sprite">Name of sprite that is in the sprites folder</param>
        public Sprite(string sprite, Vector2 position, Vector2 size = null, ConsoleColor color = ConsoleColor.White)
        {
            string[] linesContent = FileManager.ReadLines("\\sprites\\" + sprite);
            this.color = color;

            maxWidth = linesContent.Max<string>().Length;
            maxHeight = linesContent.Length;

            if (size == null)
                this.size = new Vector2(maxWidth, maxHeight);
            else
                this.size = size;

            this.position = position;

            content = linesContent;
        }

        public new void Render(Action action = null, Vector2 chosenPos = null)
        {
            int a = 0;

            foreach (string line in content)
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(position.x, position.y + a++);
                Console.Write(line);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
