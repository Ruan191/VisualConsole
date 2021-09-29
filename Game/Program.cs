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
                if (!Renderer.renderQueue.IsEmpty){
                    (uint id , Action action) toRun;
                    if (Renderer.renderQueue.TryDequeue(out toRun)){
                        toRun.action?.Invoke();
                    }
                }
                Play.PerformUpdate();
                Thread.Sleep(Settings.PauseTimeBetweenUpdates);
                Play.PerformLateUpdate();
            }
        }

        static void InitializeObjects(){
            Example ex = new Example();
        }
    }
}
