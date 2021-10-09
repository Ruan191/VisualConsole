using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualConsole.General;

namespace VisualConsole
{
    static class Settings
    {
        public static string ConsoleName { get; set; } = "MyProject";
        public static bool ControlsEnabled { get; set; } = true;
        public static bool UpdateEnabled { get; set; } = true;
        public static int PauseTimeBetweenUpdates { get; set; } = 15;
        public static bool DebugEnabled { get; set; } = false;

        /// <summary>
        /// Assigns all the settings in settings.json to the Settings class
        /// </summary>
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
