using System;

namespace Game{
    class Example : Play
    {

        public Example(){
            Start += _Start;
            Update += _Update;
            Controls.OnKeyPressed += _OnKeyPressed;
            Controls.OnCKPressed += _OnCKPressed;
        }
        Animation animation;
        TextBox read2;
        void _Start(object sender, EventArgs e){
            Map.Build(new Vector2(100, 50));

            MapObject middleText = new MapObject("Type Enter to end the program");
            Vector2 middleTextCenter = Vector2.Center() - new Vector2(middleText.obj.ToString().Length / 2, 0);
            Map.Spawn(middleText, middleTextCenter);

            animation = new Animation("explosion", (new Vector2((middleTextCenter.x / 2) + 2, middleTextCenter.y - 2)), new Vector2(20,20),ConsoleColor.DarkCyan);
            animation.pausesBetweenFrames = 1000;
            animation.color = ConsoleColor.Red;
            animation.Play();

            Animation animation2 = new Animation("explosion", (new Vector2(middleTextCenter.x * 2, middleTextCenter.y - 2)), new Vector2(20,20),ConsoleColor.Red);
            animation2.pausesBetweenFrames = 1000;
            animation2.Play();

            TextBox textBox = new TextBox(middleTextCenter + new Vector2(0, 1));
            textBox.maxCharAllowed = 5;
            TextBox.Select(textBox);
        }

        void _Update(object sender, EventArgs e){
            //Debug.Log(Controls.keyPressed.ToString(), new Vector2(5,0));
        }

        void _OnKeyPressed(object sender, Controls.KeyPressedHandler e){

        }
        void _OnCKPressed(object sender, Controls.CKPressedHandler e){
            //Debug.Log("KeyPressed = " + (int)e.keyPressed, new Vector2());
            
            if (e.keyPressed == ConsoleKey.Enter){
                if (TextBox.currentSelectedTextRead.text.ToString() == "Enter"){
                    Debug.Log("End");
                }
            }
        }

    }
}