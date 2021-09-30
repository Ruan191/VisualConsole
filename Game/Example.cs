using System;

namespace Game{
    class Example : Play
    {

        public Example(){
            Start += _Start;
            Update += _Update;
            Controls.OnKeyPressed += _OnKeyPressed;
        }
        Animation animation;
        void _Start(object sender, EventArgs e){
            Map.Build(new Vector2(60, 50));
            
            MapObject topLeftText = new MapObject("Thank you for using BetterConsole!");
            Map.Spawn(topLeftText, new Vector2());

            MapObject topRightText = new MapObject("If you see the waves moving then it means the framwork is functional");
            Map.Spawn(topRightText, new Vector2(Map.size.x - 1, 0));

            animation = new Animation("explosion", new Vector2((Map.size.x / 2) + 5, 10), new Vector2(20,20),ConsoleColor.DarkCyan);
            animation.pausesBetweenFrames = 1000;
            animation.color = ConsoleColor.Red;
            animation.Play();
        }

        void _Update(object sender, EventArgs e){
            //Debug.Log(Controls.keyPressed.ToString(), new Vector2(5,0));
        }

        //string t = "";
        void _OnKeyPressed(object sender, Controls.KeyPressedHandler e){
            Debug.Log("KeyPressed = " + e.keyPressed.ToString(), new Vector2());
            MapObject txt = new MapObject( e.keyPressed.GetHashCode());
            Map.Spawn(txt, new Vector2(0, 5));
        }

    }
}