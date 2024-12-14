namespace Day6
{
    public struct Position(int x, int y)
    {
        public int X = x;
        public int Y = y;

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
