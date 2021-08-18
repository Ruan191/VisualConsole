using System;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    public class Controls
    {

        public char key = ' ';
        public async void KeyPressed(){
            while(true){
                
                await Task.Run(() => {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    this.key = key.KeyChar;
                });

               // key = ' ';
            }
        }
    }
}