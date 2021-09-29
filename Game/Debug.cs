using System;

namespace Game{
    class Debug{
        static uint numOfRequests = 0;
        public static void Log(string content, Vector2 position = null)
        {
            Renderer.RequestRender((9999 + ++numOfRequests, () => {
                Renderer.DebugRender(content, position);
            }));
        }
    }
}