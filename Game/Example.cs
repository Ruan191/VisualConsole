using System;

namespace Game{
    class Example : Play
    {

        public Example(){
            Start += _Start;
        }

        void _Start(object sender, EventArgs e){
            Map map = Map.Build(new Vector2(50,50));
            MapObject player = new MapObject('#', new Vector2(map.size.x / 2, map.size.y / 2), new Vector2(3,5));
            player.Spawn(map, player, new Vector2(map.size.x / 2, map.size.y / 2));
            Debug.Log(map, "Hello World! This is a basic console game engine");
        }
    }
}