using System;

namespace Game{
    class Debug{
        public static bool enabled;

        public static void Log(Map map, string content, Vector2 position = null)
        {
            Vector2 logPosition = position ?? new Vector2();
            Console.SetCursorPosition((map.size.x + 5) + logPosition.x, 0 + logPosition.y);

            Console.Write(content);
        }
    }
}