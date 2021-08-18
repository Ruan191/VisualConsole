using System;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Play
    {
        public static event EventHandler Start;
        public static event EventHandler Update;

        public static void PerformStart(){
            if (Start != null){
                Start.Invoke(null, EventArgs.Empty);
            }
        }

        public static void PerformUpdate(){
            if (Update != null){
                Update.Invoke(null, EventArgs.Empty);
            }
        }
    }
}