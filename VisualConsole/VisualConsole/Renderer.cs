using System;
using System.Collections.Concurrent;

namespace VisualConsole
{
    static class Renderer
    {
        public static ConcurrentQueue<(uint, IRenderable)> renderQueue = new ConcurrentQueue<(uint, IRenderable)>();

        public static void RequestRender((uint, IRenderable) render)
        {
            foreach (var item in renderQueue)
            {
                if (item.Item1.Equals(render.Item1))
                {
                    return;
                }
            }

            renderQueue.Enqueue(render);
        }
    }
}
