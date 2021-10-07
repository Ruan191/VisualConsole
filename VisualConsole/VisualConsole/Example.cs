using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        Animation animation;
        Animation animation2;
        Animation animation3;
        Animation animation4;
        SoundPlayer soundPlayer;

        Sprite sprite;
        int animationSpeed = 30;

        void _Start(object sender, EventArgs e)
        {
            Map.Build(new Vector2(100, 50));
            sprite = new Sprite("BA75.txt", new Vector2());

            animation = new Animation("badapple", new Vector2(), ConsoleColor.Red);
            animation.pausesBetweenFrames = animationSpeed;

            animation2 = new Animation("badapple", new Vector2(sprite.size.x, 0), ConsoleColor.Blue);
            animation2.pausesBetweenFrames = animationSpeed;

            animation3 = new Animation("badapple", new Vector2(0, sprite.size.y), ConsoleColor.Green);
            animation3.pausesBetweenFrames = animationSpeed;

            animation4 = new Animation("badapple", new Vector2(sprite.size.x, sprite.size.y), ConsoleColor.Yellow);
            animation4.pausesBetweenFrames = animationSpeed;

            if (OperatingSystem.IsWindows())
            {
                soundPlayer = new SoundPlayer("BadApple.wav");
                soundPlayer.Load();
            }


            Console.SetWindowSize(sprite.size.x * 2, sprite.size.y * 2);
            Console.SetWindowPosition(0, 0);
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
                soundPlayer.PlayLooping();

                animation.Play();

                animation2.Play();

                animation3.Play();

                animation4.Play();
            }
        }

    }
}
