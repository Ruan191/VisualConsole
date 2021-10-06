using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualConsole
{
    static class Settings
    {
        public static string ConsoleName { get; set; }
        public static bool ControlsEnabled { get; set; }
        public static bool UpdateEnabled { get; set; }
        public static int PauseTimeBetweenUpdates { get; set; }
        public static bool DebugEnabled { get; set; }

        public static void Initialize()
        {
            dynamic settings = JsonConverter.Deserialize(FileManager.ReadAllText("settings.json"));

            ConsoleName = settings.ConsoleName;
            ControlsEnabled = settings.ControlsEnabled;
            UpdateEnabled = settings.UpdateEnabled;
            PauseTimeBetweenUpdates = settings.PauseTimeBetweenUpdates;
            DebugEnabled = settings.DebugEnabled;
        }
    }
}
