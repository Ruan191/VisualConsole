using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VisualConsole
{
    class Program
    {
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
