using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualConsole.General
{
    class Scene
    {
        public static event EventHandler OnSceneChange;
        public static Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();
        public static Scene activeScene = null;
        public Settings settings;

        public string name;
        public Vector2 size;
        public readonly int sceneNum = 0;
        Play[] toRun;

        /// <summary>
        /// Creates a scene where selected Play objects can be runned on till the scene has changed 
        /// </summary>
        /// <param name="name">Name of the scene</param>
        /// <param name="size">The size of the scene</param>
        /// <param name="settings">The setting that the scene will run on</param>
        /// <param name="toRun">The objects that will be running in the scene</param>
        public Scene(string name, Vector2 size, Settings settings, Play[] toRun)
        {
            this.name = name;
            sceneNum++;
            this.size = size;
            this.toRun = toRun;
            this.settings = settings;
            scenes.Add(name ,this);
        }


        /// <summary>
        /// Starts the scene removes all previous scenes content and replace it with the new scenes content
        /// </summary>
        /// <param name="scene">The scene that will be used</param>
        public static void Start(Scene scene)
        {
            if (OnSceneChange != null)
                OnSceneChange(null, EventArgs.Empty);

            if (activeScene != null)
            {
                foreach(Play play in activeScene.toRun)
                {
                    play.Remove();
                }
            }
            
            foreach(Play play in scene.toRun)
            {
                play.SubHere();
            }

            activeScene = scene;
            
            Renderer.renderQueue.Clear();

            Console.Title = scene.settings.ConsoleName;
            Console.CursorVisible = false;

            Map.Build(scene.size);
            Play.PerformStart();
        }
    }
}
