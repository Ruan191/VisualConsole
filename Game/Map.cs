using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    public class Map
    {
        public Vector2 size;
        public MapObject[,] map;

        public Map(Vector2 size)
        {
            this.size = size;
            map = new MapObject[size.x, size.y];
        }

        public Map()
        {
            this.size = new Vector2();
            map = new MapObject[size.x, size.y];
        }

        public static Map Build(Vector2 size)
        {
            char tile = Debug.enabled ? '.' : ' ';

            Map m = new Map(size);
            for (int y = 0; y < m.size.y; y++)
            {
                for (int x = 0; x < m.size.x; x++)
                {
                    m.map[x, y] = new MapObject(m.map[x, y]?.obj ?? tile, new Vector2(x, y), new Vector2(1, 1));
                    Console.Write(m.map[x, y]?.obj ?? tile);
                }
                Console.WriteLine();
            }

            return m;
        }

        public static void Spawn(Map map, MapObject obj, Vector2 location)
        {
            for (int y = 0; y < obj.size.y; y++)
            {
                for (int x = 0; x < obj.size.x; x++)
                {
                    map.map[location.x + x, location.y + y] = obj;
                    Console.SetCursorPosition(location.x + x, location.y + y);
                    Console.Write(obj.obj);
                }
            }
        }

        public static MapObject[] GetAreaInfo(Map map, Vector2 area){
            List<MapObject> objs = new List<MapObject>();

            for (int y = 0; y < area.y; y++){
                for (int x = 0; x < area.x; x++){
                    objs.Add(map.map[x, y]);
                }
            }

            return objs.ToArray();
        }
    }

    public class MapObject
    {

        public event EventHandler OnCollision;
        public object obj;

        public string name { get; set; }
        public Vector2 position;
        public Vector2 size;
        public ConsoleColor color;

        Vector2 prev;
        Vector2 dir;

        public MapObject(object obj, Vector2 position = null, Vector2 size = null, ConsoleColor color = ConsoleColor.White)
        {
            this.obj = obj;
            this.position = position ?? new Vector2();
            this.size = size ?? new Vector2(1,1);
            this.color = color;
            prev = this.position;
        }
        public void Spawn(Map map, MapObject obj, Vector2 location){
            MapObject mapObj = null;
            for (int y = 0; y < obj.size.y; y++)
            {
                for (int x = 0; x < obj.size.x; x++)
                {
                    //Console.SetCursorPosition(map.size.x, 0);
                    //Console.Write($"  {map.map[location.x + x, location.y + y].obj} {map.map[location.x + x, location.y + y].position}");
                    mapObj = map.map[location.x + x, location.y + y];
                    Debug.Log(map, mapObj.obj.ToString());

                    if (mapObj.obj.Equals('.') || mapObj.obj.Equals(' ') || mapObj.obj.Equals(this.obj)){
                       // Thread.Sleep(25);
                        map.map[location.x + x, location.y + y] = obj;
                        //Thread.Sleep(25);
                        Console.SetCursorPosition(location.x + x, location.y + y);
                        //Thread.Sleep(25);
                        Console.ForegroundColor = color;
                        Console.Write(obj.obj);
                        Console.ForegroundColor = ConsoleColor.White;
                    }else{
                        Console.SetCursorPosition(map.size.x, 0);
                        //Console.Write($"  {map.map[location.x + x, location.y + y].obj} {c}");
                        //OnCollision(this, EventArgs.Empty);
                        
                    }
                }
            }

            /*if(hit){
                Console.SetCursorPosition(map.size.x, 0);
                c++;
                OnHit(mapObj);
            }*/
        }

        //To DO
        /*public void Move(Map map, Vector2 dir)
        {
            this.dir = dir;
            int xmove = dir.x;
            int ymove = dir.y;

            MapObject emptyObject = new MapObject(' ', size: this.size);
            Spawn(map, emptyObject, prev);
            Spawn(map, this, new Vector2(this.position.x, this.position.y));

            prev = new Vector2(this.position.x - dir.x , this.position.y - dir.y);
            
            this.position.x += xmove;
            this.position.y += ymove;

            
            for(int x = 0; x < this.size.x; x++){
                for(int y = 0; y < this.size.y; y++){
                    MapObject obj =  map.map[this.position.x + (dir.x * this.size.x), this.position.y - (dir.y * this.size.y)];
                    //Console.SetCursorPosition(this.position.x + (dir.x * this.size.x), this.position.y + (-dir.y * -this.size.y));

                    //Console.SetCursorPosition(this.position.x, this.position.y);
                    //MapObject xx = new MapObject(' ');
                    //Console.Write(xx.obj);
                    // if (!obj.obj.Equals('.')){
                    //     OnCollision(this, EventArgs.Empty);
                    //     break;
                    // }

                    //if (this.position.x + this.size.x > map.size.x / 2){
                        //OnCollision(this, EventArgs.Empty);
                        //break;
                   // }
                }
            }
            //Console.Write(map.map[this.position.x + (dir.x * this.size.x), this.position.y + (dir.y * this.size.y)].obj);
        }*/
    }
}