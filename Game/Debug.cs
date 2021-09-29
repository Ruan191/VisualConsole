using System;

namespace Game{
    class Debug{
        public static void Log(string content, Vector2 position = null)
        {
            Renderer.RequestRender((9999, () => {
                Renderer.DebugRender(content, position);
            }));
        }
    }
}