using System;
using System.Threading;
using System.IO;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings.Initialize();
            Console.Title = Settings.ConsoleName;
            Console.Clear();
            Console.CursorVisible = false;
            InitializeObjects();
            Play.PerformStart();
            Controls a = new Controls();

            a.KeyPressed();

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
