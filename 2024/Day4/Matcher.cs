namespace Day4
{
    internal static class Matcher
    {
        public static bool Match(this WordSearch self, int x, int y, string pattern, Direction direction)
        {
            var currentX = x;
            var currentY = y;

            foreach (var currentLetter in pattern)
            {
                if (currentX < 0
                    || currentY < 0
                    || currentX >= self.Width
                    || currentY >= self.Height)
                {
                    return false;
                }

                if (currentLetter != self[currentX, currentY])
                {
                    return false;
                }

                switch (direction)
                {
                    case Direction.North:
                        currentY--;
                        break;
                    case Direction.NorthEast:
                        currentY--;
                        currentX++;
                        break;
                    case Direction.East:
                        currentX++;
                        break;
                    case Direction.SouthEast:
                        currentX++;
                        currentY++;
                        break;
                    case Direction.South:
                        currentY++;
                        break;
                    case Direction.SouthWest:
                        currentY++;
                        currentX--;
                        break;
                    case Direction.West:
                        currentX--;
                        break;
                    case Direction.NorthWest:
                        currentX--;
                        currentY--;
                        break;
                }
            }

            return true;
        }

        public static bool ConvolutionFilter(this WordSearch self, int x, int y)
        {
            var patterns = new [] { "MAS", "SAM" };

            if (self[x, y] != 'A')
            {
                return false;
            }

            if (patterns.Any(p => self.Match(x - 1, y - 1, p, Direction.SouthEast))
                && patterns.Any(p => self.Match(x + 1, y - 1, p, Direction.SouthWest)))
            {
                return true;
            }

            return false;
        }
    }
}
