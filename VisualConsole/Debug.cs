using System;

namespace VisualConsole{
    class Debug{
        static uint numOfRequests = 0;
        static int lastYPosition = 0;
        /// <summary>
        /// Sends messages on the out side of the Map
        /// </summary>
        /// <param name="content">Message to be printed</param>
        /// <param name="position">Determines where the printed message should go in the Debug space. If left empty then the message will be printed on a new line</param>
        public static void Log(string content, Vector2 position = null)
        {
            if (Settings.DebugEnabled){
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
}