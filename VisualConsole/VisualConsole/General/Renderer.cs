using System;
using System.Collections.Concurrent;

namespace VisualConsole.General
{
    static class Renderer
    {
        public static ConcurrentQueue<(uint, IRenderable)> renderQueue = new ConcurrentQueue<(uint, IRenderable)>();

        /// <summary>
        /// Puts the render request in a queue to be rendered
        /// </summary>
        /// <param name="render">(id of the object, IRenderable obj) Note that no duplicate ids can be placed in the queue</param>
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
