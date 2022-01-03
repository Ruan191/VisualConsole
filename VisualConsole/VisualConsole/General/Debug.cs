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
        static FileStream writer = new FileStream(@$"{FileManager.projectDir}\debug.txt", FileMode.Open, FileAccess.Write, FileShare.ReadWrite);

        /// <summary>
        /// Sends messages on the out side of the Map
        /// </summary>
        /// <param name="content">Message to be printed</param>
        /// <param name="position">Determines where the printed message should go in the Debug space. If left empty then the message will be printed on a new line</param>
        public static void Log(object content)
        {
            if (Scene.activeScene.settings.DebugEnabled)
                foreach (char c in content.ToString())
                {
                    writer.WriteByte((byte)c);
                }

            writer.Position = 0;
        }

        public static void Error(object content)
        {
            if (Scene.activeScene.settings.DebugEnabled)
                foreach (char c in '!' + content.ToString())
                {
                    writer.WriteByte((byte)c);
                }

            writer.Position = 0;
        }
    }
}
