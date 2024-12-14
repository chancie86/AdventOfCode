using System.Drawing;

namespace Day6.Extensions
{
    internal static class PositionExtensions
    {
        public static Position AddX(this Position self, int increment)
        {
            return new Position(self.X + increment, self.Y);
        }

        public static Position AddY(this Position self, int increment)
        {
            return new Position(self.X, self.Y + increment);
        }
    }
}
