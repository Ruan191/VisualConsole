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
            //MapObject player = new MapObject(Timer.currentTime);//, new Vector2(Map.size.x / 2, Map.size.y / 2), new Vector2(3,5), ConsoleColor.Red);
            //Sprite sprite = new Sprite("wave", new Vector2(), new Vector2(25, 7));
            //Map.Spawn(player, new Vector2(((Map.size.x / 2) - (player.size.x / 2)) - 1, ((Map.size.y / 2) - (player.size.y / 2)) - 1));
            //Map.Spawn(sprite, new Vector2(5, 5));
            animation = new Animation("", new Vector2(), new Vector2(25, 7));
            animation.pausesBetweenFrames = 100;
            animation.color = ConsoleColor.Red;
            animation.Play();
            //Action<uint> a = Renderer.renderQueue.Dequeue();
            
            
        }
        int count = 0;
        void _Update(object sender, EventArgs e){
            //Debug.Log(Controls.keyPressed.ToString(), new Vector2(5,0));
        }

        void _OnKeyPressed(object sender, Controls.KeyPressedHandler e){
            if (e.keyPressed == ConsoleKey.A){
                Debug.Log(count++.ToString(), new Vector2());
                Debug.Log(count++.ToString(), new Vector2(0, 1));
            }
        }

    }
}