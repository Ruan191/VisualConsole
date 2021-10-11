using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualConsole.General;

namespace VisualConsole
{
    class Settings
    {
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<string, Settings> settings = new Dictionary<string, Settings>()
        {
            
        };

        Settings()
        {
            
        }

        Settings(string name, bool controlsEnabled, bool updateEnabled, bool debugEnabled, int pauseTimeBetweenUpdates, double timeBetweenRenderTrigger)
        {
            ConsoleName = name;
            ControlsEnabled = controlsEnabled;
            UpdateEnabled = updateEnabled;
            PauseTimeBetweenUpdates = pauseTimeBetweenUpdates;
            TimeBetweenRenderTrigger = timeBetweenRenderTrigger;
            DebugEnabled = debugEnabled;
        }

        public string ConsoleName { get; set; } = "MyProject";
        public bool ControlsEnabled { get; set; } = true;
        public bool UpdateEnabled { get; set; } = true;
        public int PauseTimeBetweenUpdates { get; set; } = 15;
        public double TimeBetweenRenderTrigger { get; set; } = 41;
        public bool DebugEnabled { get; set; } = false;

        /// <summary>
        /// Assigns your settings here
        /// </summary>
        public static void InitializeSettings()
        {
            settings.Add("Default", new Settings());
            settings.Add("Test", new Settings("T", true, true, false, 1000, 41));
        }
    }
}
