using System;

namespace Game{
    class Debug{
        static uint numOfRequests = 0;
        static int lastYPosition = 0;
        public static void Log(string content, Vector2 position = null)
        {
            if (lastYPosition >= Console.BufferHeight - 1){
                lastYPosition = 0;
            }

            Renderer.RequestRender((9999 + ++numOfRequests, () => {
                if (position == null)
                    Renderer.DebugRender(content, new Vector2(0, lastYPosition++));
                else
                    Renderer.DebugRender(content, position);
            }));
        }
    }
}