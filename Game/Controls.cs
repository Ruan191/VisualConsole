using System;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    public static class Controls
    {

        public static ConsoleKey keyPressed;
        public static async void KeyPressed(){
            while(true){
                await Task.Run(() => {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    keyPressed = key.Key;
                });
            }
        }
    }
}