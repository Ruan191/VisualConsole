using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualConsole.General
{
    class Debug
    {
        static uint numOfRequests = 0;
        static int lastYPosition = 0;
        /// <summary>
        /// Sends messages on the out side of the Map
        /// </summary>
        /// <param name="content">Message to be printed</param>
        /// <param name="position">Determines where the printed message should go in the Debug space. If left empty then the message will be printed on a new line</param>
        public static void Log(string content, Vector2 position = null)
        {
            DebugMessage debugMessage;
            
            if (Scene.activeScene.settings.DebugEnabled)
            {
                if (lastYPosition >= Console.BufferHeight - 1)
                {
                    lastYPosition = 0;
                }

                if (position == null)
                    debugMessage = new DebugMessage(content, new Vector2(0, lastYPosition++));
                else
                    debugMessage = new DebugMessage(content, position);

                Renderer.RequestRender((9999 + ++numOfRequests, debugMessage));
            }
        }

        class DebugMessage : IRenderable
        {
            public object content;
            Vector2 position;

            public DebugMessage(string content, Vector2 position)
            {
                this.content = content;
                this.position = position;
            }

            public void Render(Action action = null, Vector2 chosenPos = null)
            {
                Vector2 logPosition = chosenPos ?? new Vector2();
                Console.SetCursorPosition((Map.size.x + 5) + logPosition.x, 0 + logPosition.y);

                Console.Write("-> " + content);
            }
        }
    }
}
