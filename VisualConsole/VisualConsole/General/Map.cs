using System;
using System.Collections.Generic;

namespace VisualConsole.General
{
    public static class Map
    {
        public static Vector2 size { get; private set; }
        public static MapObject[,] map;
        public static char background = ' ';

        /// <summary>
        /// Builds the map where everything can be placed upon and rendered
        /// </summary>
        /// <param name="size">Sets the size of the map</param>
        public static void Build(Vector2 size)
        {
            Console.Clear();
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            char tile = Settings.DebugEnabled ? '.' : background;

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
            obj.Render();
        }

        public static void Spawn(Sprite sprite, Vector2 location)
        {
            sprite.position = location;
            sprite.Render();
        }

        public static MapObject[] GetAreaInfo(Vector2 area)
        {
            List<MapObject> objs = new List<MapObject>();

            for (int y = 0; y < area.y; y++)
            {
                for (int x = 0; x < area.x; x++)
                {
                    objs.Add(Map.map[x, y]);
                }
            }

            return objs.ToArray();
        }
    }

    public class MapObject : IRenderable
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">To be showen on the console</param>
        /// <param name="position"></param>
        /// <param name="size"></param>
        /// <param name="color"></param>
        public MapObject(object obj, Vector2 position = null, Vector2 size = null, ConsoleColor color = ConsoleColor.White)
        {
            id = ++numOfObj;
            this.obj = obj;
            this.position = position ?? new Vector2();
            this.size = size ?? new Vector2(1, 1);
            this.color = color;
            prev = this.position;
        }

        public MapObject()
        {
            id = ++numOfObj;
            size = new Vector2();
        }

        /// <summary>
        /// Renders the MapObject to the console
        /// </summary>
        /// <param name="action">no effect</param>
        /// <param name="chosenPos">no effect</param>
        public void Render(Action action = null, Vector2 chosenPos = null)
        {
            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    Map.map[position.x + x, position.y + y] = this;
                    Console.SetCursorPosition(position.x + x, position.y + y);
                    Console.ForegroundColor = color;
                    Console.Write(obj);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
