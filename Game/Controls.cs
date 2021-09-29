using System;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    public class Controls
    {
        public static event EventHandler<KeyPressedHandler> OnKeyPressed;
        public class KeyPressedHandler : EventArgs{
            public ConsoleKey keyPressed;
        }

        public static ConsoleKey keyPressed;
        public static async void KeyPressed(){
            await Task.Run(() => {
                while(true){
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    keyPressed = key.Key;

                    if (keyPressed != ConsoleKey.NoName){
                        OnKeyPressed.Invoke(null, new KeyPressedHandler(){keyPressed = keyPressed});
                    }

                    keyPressed = ConsoleKey.NoName;
                }
            });
        }
    }
}