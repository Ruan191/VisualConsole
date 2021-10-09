using System;
using System.Diagnostics;
using VisualConsole.General;
using System.Threading.Tasks;

namespace VisualConsole
{
    class Program
    {
        //set to false if no changes were made to your sprites, animation and audio folder and settings file. Keep true for first time run or if changes were made
        static bool changeWhereMadeToFiles = true;

        static void Main(string[] args)
        {
            if (changeWhereMadeToFiles)
                FileManager.AttemptCopyOfProjectFiles();


            Settings.Initialize();
            Console.Title = Settings.ConsoleName;
            Console.CursorVisible = false;
            InitializeObjects();
            Play.PerformStart();

            Stopwatch stopwatch = new Stopwatch();
            double timeAtPreviousFrame = 0;
            stopwatch.Start();

            Controls.KeyPressed();

            double timeBetweenMoves = 8.1;
            double timeSinceLastMove = 0;

            while (Settings.UpdateEnabled)
            {
                double deltaTimeMS = stopwatch.Elapsed.TotalMilliseconds - timeAtPreviousFrame;
                timeAtPreviousFrame = stopwatch.Elapsed.TotalMilliseconds;

                timeSinceLastMove += deltaTimeMS;

                if (timeSinceLastMove > timeBetweenMoves)
                {
                    (uint id, IRenderable action) toRun;
                    if (Renderer.renderQueue.TryDequeue(out toRun))
                    {
                        toRun.action.Render();
                    }

                    timeSinceLastMove -= timeBetweenMoves;
                }

                Play.PerformUpdate();
                Task.Delay(Settings.PauseTimeBetweenUpdates).Wait();
                Play.PerformLateUpdate();
            }
        }

        static void InitializeObjects()
        {
            Example ex = new Example();
        }
    }
}
