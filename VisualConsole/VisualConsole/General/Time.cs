using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace VisualConsole.General
{
    static class Time
    {
        static Stopwatch stopwatch;
        public static double deltaTime 
        {
            get 
            {
                return stopwatch.Elapsed.TotalMilliseconds;
            }
        }

        public static void Start()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }
    }
}
