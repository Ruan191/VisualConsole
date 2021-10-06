using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualConsole
{
    public abstract class Play
    {
        protected static event EventHandler Start;
        protected static event EventHandler Update;
        protected static event EventHandler LateUpdate;

        public static void PerformStart()
        {
            if (Start != null)
            {
                Start.Invoke(null, EventArgs.Empty);
            }
        }

        public static void PerformUpdate()
        {
            if (Update != null)
            {
                Update.Invoke(null, EventArgs.Empty);
            }
        }

        public static void PerformLateUpdate()
        {
            if (LateUpdate != null)
            {
                LateUpdate.Invoke(null, EventArgs.Empty);
            }
        }
    }
}
