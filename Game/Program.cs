using System;
using System.Threading;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;
            InitializeObjects();
            Play.PerformStart();
            Controls a = new Controls();

            a.KeyPressed();

            while (true){
                Thread.Sleep(8);
                Play.PerformUpdate();
            }
        }

        static void InitializeObjects(){
            Example ex = new Example();
        }
    }
}
