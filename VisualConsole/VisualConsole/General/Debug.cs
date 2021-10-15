using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualConsole.General
{
    class Debug
    {
        /// <summary>
        /// Sends messages on the out side of the Map
        /// </summary>
        /// <param name="content">Message to be printed</param>
        /// <param name="position">Determines where the printed message should go in the Debug space. If left empty then the message will be printed on a new line</param>
        public static void Log(string content, Vector2 position = null)
        {
            if (Scene.activeScene.settings.DebugEnabled)
                using (var writer = new FileStream(@"C:\Users\Ruan\Documents\GitHub\Basic-Console-GameEngine\VisualConsole\VisualConsole\debug.txt", FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
                {
                    foreach (char c in content)
                    {
                        writer.WriteByte((byte)c);
                    }
                }
        }
    }
}
