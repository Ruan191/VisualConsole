using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualConsole.General
{
    public abstract class Play
    {
        protected static event EventHandler Start;
        protected static event EventHandler Update;
        protected static event EventHandler LateUpdate;

        public Play()
        {
            Scene.OnSceneChange += Scene_OnSceneChange;
            Start += _Start;
            Update += _Update;
        }

        private void Scene_OnSceneChange(object sender, EventArgs e)
        {
            Start -= _Start;
            Update -= _Update;
        }

        /// <summary>
        /// To run once before update start 
        /// </summary>
        public static void PerformStart()
        {
            if (Start != null)
            {
                Start.Invoke(null, EventArgs.Empty);
            }
        }

        /// <summary>
        /// To run on every update
        /// </summary>
        public static void PerformUpdate()
        {
            if (Update != null)
            {
                Update.Invoke(null, EventArgs.Empty);
            }
        }

        /// <summary>
        /// To run after update
        /// </summary>
        public static void PerformLateUpdate()
        {
            if (LateUpdate != null)
            {
                LateUpdate.Invoke(null, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Use this method to subscribe to the events, avoid using the constructor
        /// </summary>
        public abstract void SubHere();
        /// <summary>
        /// Use this to remove or dispose when the scene is over, Note that unsubscribeing from the events are done automatically
        /// </summary>
        public abstract void Remove();

        public abstract void _Update(object sender, EventArgs e);

        public abstract void _Start(object sender, EventArgs e);
    }
}
