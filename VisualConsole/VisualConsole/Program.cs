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

            Settings.InitializeSettings();
            Scene defaultScene = new Scene("scene1", new Vector2(100, 50), Settings.settings["Default"], new Play[] { new Example() });

            Scene.Start(defaultScene);

            double timeAtPreviousFrame = 0;

            double timeBetweenMoves = Scene.activeScene.settings.TimeBetweenRenderTrigger;
            double timeSinceLastMove = 0;

            Time.Start();
            Controls.KeyPressed();

            while (Scene.activeScene.settings.UpdateEnabled)
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

                    Play.PerformUpdate();
                    Play.PerformLateUpdate();
                }

                Task.Delay(Scene.activeScene.settings.PauseTimeBetweenUpdates).Wait();
            }
        }
    }
}
