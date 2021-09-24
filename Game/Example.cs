using System;

namespace Game{
    class Example : Play
    {

        public Example(){
            Start += _Start;
            Update += _Update;
        }

        void _Start(object sender, EventArgs e){
            Map.Build(new Vector2(30, 30));
            MapObject player = new MapObject('#', new Vector2(Map.size.x / 2, Map.size.y / 2), new Vector2(3,5), ConsoleColor.Red);
            player.Spawn(player, new Vector2(((Map.size.x / 2) - (player.size.x / 2)) - 1, ((Map.size.y / 2) - (player.size.y / 2)) - 1));
            Debug.Log("Hello World! This is a basic console game engine");
        }

        void _Update(object sender, EventArgs e){
            Debug.Log("KeyPress demo: " + Controls.keyPressed.ToString(), new Vector2(0, 1));
        }

    }
}