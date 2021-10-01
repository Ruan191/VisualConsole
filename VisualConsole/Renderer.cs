using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace VisualConsole{
    static class Renderer{
        public static ConcurrentQueue<(uint, Action)> renderQueue = new ConcurrentQueue<(uint, Action)>();

        public static void Render(MapObject obj, Vector2 location){
 
            for (int y = 0; y < obj.size.y; y++){
                for (int x = 0; x < obj.size.x; x++)
                {
                    Map.map[location.x + x, location.y + y] = obj;
                    Console.SetCursorPosition(location.x + x, location.y + y);
                    Console.ForegroundColor = obj.color;
                    Console.Write(obj.obj);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public static void Render(Sprite sprite, Vector2 location)
        {
            char currentChar;

            for (int y = 0; y < sprite.size.y; y++)
            {
                for (int x = 0; x < sprite.size.x; x++)
                {
                    if (x <= sprite.maxWidth - 1 && y <= sprite.maxHeight - 1){
                        currentChar = sprite.content[x, y];
                        Map.map[location.x + x, location.y + y] = sprite;
                        Console.SetCursorPosition(location.x + x, location.y + y);
                    }
                    else
                        currentChar = Map.background;

                    Console.ForegroundColor = sprite.color;
                    Console.Write(currentChar);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public static void DebugRender(object content, Vector2 position){
            Vector2 logPosition = position ?? new Vector2();
            Console.SetCursorPosition((Map.size.x + 5) + logPosition.x, 0 + logPosition.y);

            Console.Write("-> " + content);
        }

        public static void TextRender(TextBox text, Vector2 position){
            Map.map[position.x, position.y] = text;
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = text.color;
            Console.Write(text.text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void RequestRender((uint, Action) render){
            foreach (var item in renderQueue){
                if (item.Item1.Equals(render.Item1)){
                    return;
                }
            }
            
            renderQueue.Enqueue(render);
        }

    }
}