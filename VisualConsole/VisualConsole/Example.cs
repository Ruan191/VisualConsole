using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualConsole
{
    class Example : Play
    {
        //Example code on how to use the framework

        public Example()
        {
            Start += _Start;
            Update += _Update;
            Controls.OnKeyPressed += _OnKeyPressed;
            Controls.OnCKPressed += _OnCKPressed;
        }

        void _Start(object sender, EventArgs e)
        {
            //Spawns the 2D map
            Map.Build(new Vector2(100, 50));

            Console.SetWindowSize(Map.size.x, Map.size.y); //= Map.size.x;
            //Console.WindowHeight = Map.size.y;

            //Creates text to be spawned in the Map and sets it to be at the center
            MapObject middleText = new MapObject("Type Enter to end the program");
            Vector2 middleTextCenter = Vector2.Center() - new Vector2(middleText.obj.ToString().Length / 2, 0);
            Map.Spawn(middleText, middleTextCenter);

            Animation animation = new Animation("explosion", (new Vector2((middleTextCenter.x / 2) + 2, middleTextCenter.y - 2)), ConsoleColor.DarkCyan);
            animation.pausesBetweenFrames = 1000;
            animation.color = ConsoleColor.Red;
            animation.Play();

            Animation animation2 = new Animation("explosion", (new Vector2(middleTextCenter.x * 2, middleTextCenter.y - 2)), ConsoleColor.Red);
            animation2.pausesBetweenFrames = 1000;
            animation2.Play();

            TextBox textBox = new TextBox(middleTextCenter + new Vector2(0, 1));
            textBox.maxCharAllowed = 5;
            textBox.color = ConsoleColor.DarkGreen;
            TextBox.Select(textBox);
        }

        void _Update(object sender, EventArgs e)
        {
        }

        void _OnKeyPressed(object sender, Controls.KeyPressedHandler e)
        {

        }

        void _OnCKPressed(object sender, Controls.CKPressedHandler e)
        {
            if (e.keyPressed == ConsoleKey.Enter)
            {
                if (TextBox.currentSelectedTextRead.text.ToString() == "Enter")
                {
                    System.Environment.Exit(1);
                }
            }
        }

    }
}
