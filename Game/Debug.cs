using System;

namespace Game{
    class Debug{
        public static void Log(string content, Vector2 position = null)
        {
            Vector2 logPosition = position ?? new Vector2();
            Console.SetCursorPosition((Map.size.x + 5) + logPosition.x, 0 + logPosition.y);

            Console.Write("-> " + content);
        }
    }
}