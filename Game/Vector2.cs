namespace Game
{
    public class Vector2
    {
        public int x;
        public int y;

        public Vector2() 
        {
            x = 0;
            y = 0;
        }

        public Vector2(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString() => $"({x}, {y})";

        public void Up() => y++;
        public void Right() => x++;
        public void Down() => y--;
        public void Left() => x--;
    }
}