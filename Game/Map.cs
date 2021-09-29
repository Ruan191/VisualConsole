using System;
using System.Collections.Generic;

namespace Game
{
    public static class Map
    {
        public static Vector2 size {get; private set;}
        public static MapObject[,] map;

        public static void Build(Vector2 size)
        {
            Console.Clear();
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            char tile = Settings.DebugEnabled ? '.' : ' ';

            Map.size = size;
            map = new MapObject[size.x, size.y];
            for (int y = 0; y < Map.size.y; y++)
            {
                for (int x = 0; x < Map.size.x; x++)
                {
                    map[x, y] = new MapObject(tile, new Vector2(x, y), new Vector2(1, 1));
                    Console.Write(tile);
                }

                Console.WriteLine();
            }
        }

        public static void Spawn(MapObject obj, Vector2 location)
        {
            obj.position = location;
            Renderer.Render(obj, location);
        }

        public static void Spawn(Sprite sprite, Vector2 location)
        {
            sprite.position = location;
            Renderer.Render(sprite, location);
        }

        public static MapObject[] GetAreaInfo(Vector2 area){
            List<MapObject> objs = new List<MapObject>();

            for (int y = 0; y < area.y; y++){
                for (int x = 0; x < area.x; x++){
                    objs.Add(Map.map[x, y]);
                }
            }

            return objs.ToArray();
        }
    }

    public class MapObject
    {

        public event EventHandler OnCollision;
        public object obj;
        static uint numOfObj = 0;
        public readonly uint id;

        public string name { get; set; }
        public Vector2 position;
        public Vector2 size;
        public ConsoleColor color = ConsoleColor.Black;

        Vector2 prev;
        Vector2 dir;

        public MapObject(object obj, Vector2 position = null, Vector2 size = null, ConsoleColor color = ConsoleColor.White)
        {
            id = ++numOfObj;
            this.obj = obj;
            this.position = position ?? new Vector2();
            this.size = size ?? new Vector2(1,1);
            this.color = color;
            prev = this.position;
        }

        public MapObject(){
            id = ++numOfObj;
            size = new Vector2();
        }
    }
}