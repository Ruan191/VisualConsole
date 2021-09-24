using System;
using System.Threading;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Settings.Initialize();
            Console.Title = Settings.ConsoleName;
            Console.CursorVisible = false;
            InitializeObjects();
            Play.PerformStart();
            
            Controls.KeyPressed();

            while (Settings.UpdateEnabled){
                Thread.Sleep(Settings.PauseTimeBetweenUpdates);
                Play.PerformUpdate();
            }
        }

        static void InitializeObjects(){
            Example ex = new Example();
        }
    }
}
