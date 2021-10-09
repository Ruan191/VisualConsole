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
    }
}
