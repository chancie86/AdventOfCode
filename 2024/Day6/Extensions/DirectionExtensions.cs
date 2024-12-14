namespace Day6.Extensions
{
    internal static class DirectionExtensions
    {
        public static char ToChar(this Direction self)
        {
            return self switch
            {
                Direction.Up => '^',
                Direction.Right => '>',
                Direction.Down => 'v',
                Direction.Left => '<'
            };
        }
    }
}
