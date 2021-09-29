using System;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    public static class Controls
    {

        public static ConsoleKey keyPressed;
        public static async void KeyPressed(){
            await Task.Run(() => {
                while(true){
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    keyPressed = key.Key;
                    Thread.Sleep(100);
                    keyPressed = ConsoleKey.Zoom;
                }
            });
        }
    }
}