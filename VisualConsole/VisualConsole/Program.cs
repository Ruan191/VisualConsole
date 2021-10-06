using System;
using System.Threading.Tasks;

namespace VisualConsole
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

            while (Settings.UpdateEnabled)
            {
                if (!Renderer.renderQueue.IsEmpty)
                {
                    (uint id, IRenderable action) toRun;
                    if (Renderer.renderQueue.TryDequeue(out toRun))
                    {
                        toRun.action.Render();
                    }
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
