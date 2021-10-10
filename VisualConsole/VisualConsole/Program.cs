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

            double timeAtPreviousFrame = 0;

            Controls.KeyPressed();

            double timeBetweenMoves = 41;
            double timeSinceLastMove = 0;

            Time.Start();

            while (Settings.UpdateEnabled)
            {
                double deltaTimeMS = Time.deltaTime - timeAtPreviousFrame;
                timeAtPreviousFrame = Time.deltaTime;

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

        //Place your own classes here
        static void InitializeObjects()
        {
            Example ex = new Example();
        }
    }
}
