using System.Drawing;
using System.Text;
using Day6.Extensions;

namespace Day6
{
    public class Map
    {
        private readonly char[,] _map;
        private readonly bool[,] _visited;
        private Position? _currentPosition;

        private Map(string[] lines)
        {
            if (lines == null)
            {
                throw new ArgumentNullException(nameof(lines));
            }

            if (lines.Length == 0)
            {
                throw new InvalidDataException("Map must container at least one line");
            }

            _map = new char[lines.Length, lines[0].Length];
            for (var y = 0; y < lines.Length; y++)
            {
                for (var x = 0; x < lines[y].Length; x++)
                {
                    _map[x, y] = lines[y][x];
                }
            }

            _visited = new bool[Width, Height];

            var position = RefreshGuardPosition();
            if (position == null)
            {
                throw new InvalidDataException("Guard is not on the _map");
            }

            _currentPosition = position;
            Visit(position.Value, GetDirection(position.Value));
        }

        public char this[int x, int y]
        {
            get => _map[x, y];
            set => _map[x, y] = value;
        }

        public int Width => _map.GetLength(0);
        public int Height => _map.GetLength(1);
        public int VisitedCount { get; private set; }

        public static async Task<Map> ReadFile(string inputPath)
        {
            var lines = await File.ReadAllLinesAsync(inputPath);
            return new Map(lines);
        }

        public SpaceType GetSpaceType(int x, int y)
        {
            switch (this[x, y])
            {
                case '#':
                    return SpaceType.Obstacle;
                case '^':
                case '>':
                case '<':
                case 'v':
                    return SpaceType.Guard;
                default:
                    return SpaceType.Free;
            }
        }

        public bool Iterate()
        {
            if (_currentPosition == null)
            {
                return false;
            }

            var result = GetNextPosition();

            if (result == null)
            {
                // Guard has left the map
                return false;
            }

            var nextPosition = result.Value.nextPosition;
            var nextDirection = result.Value.nextDirection;

            Visit(nextPosition, nextDirection);

            return true;
        }

        private void Visit(Position nextPosition, Direction nextDirection)
        {
            this[_currentPosition.Value.X, _currentPosition.Value.Y] = '.';
            this[nextPosition.X, nextPosition.Y] = nextDirection.ToChar();

            if (!_visited[nextPosition.X, nextPosition.Y])
            {
                VisitedCount++;
            }

            _currentPosition = nextPosition;
            _visited[nextPosition.X, nextPosition.Y] = true;
        }

        private Position? RefreshGuardPosition()
        {
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    var spaceType = GetSpaceType(x, y);
                    if (spaceType == SpaceType.Guard)
                    {
                        return new Position(x, y);
                    }
                }
            }

            return null;
        }

        private Direction GetDirection(Position position)
        {
            var c = this[position.X, position.Y];

            return c switch
            {
                '^' => Direction.Up,
                '>' => Direction.Right,
                'v' => Direction.Down,
                '<' => Direction.Left,
                _ => throw new InvalidDataException($"Invalid character '{c}'")
            };
        }

        private bool HasExitedMap(Position position)
        {
            if (position.X < 0
                || position.X >= Width
                || position.Y < 0
                || position.Y >= Height)
            {
                return true;
            }

            return false;
        }

        private (Position nextPosition, Direction nextDirection)? GetNextPosition()
        {
            var direction = GetDirection(_currentPosition.Value);
            
            // Try to head in the same direction
            var nextPosition = Traverse(direction);

            if (HasExitedMap(nextPosition))
            {
                // Guard has left the _map
                return null;
            }

            var nextSpaceType = GetSpaceType(nextPosition.X, nextPosition.Y);
            if (nextSpaceType == SpaceType.Obstacle)
            {
                // We can't go this way. Turn right and try again.
                direction = direction switch
                {
                    Direction.Up => Direction.Right,
                    Direction.Right => Direction.Down,
                    Direction.Down => Direction.Left,
                    Direction.Left => Direction.Up,
                    _ => throw new InvalidDataException($"Invalid direction '{direction}'")
                };

                nextPosition = Traverse(direction);

                if (HasExitedMap(nextPosition))
                {
                    // Guard has left the _map
                    return null;
                }
            }

            return (nextPosition, direction);
        }

        private Position Traverse(Direction direction)
        {
            Position nextPosition;

            switch (direction)
            {
                case Direction.Up:
                    nextPosition = _currentPosition.Value.AddY(-1);
                    break;
                case Direction.Right:
                    nextPosition = _currentPosition.Value.AddX(1);
                    break;
                case Direction.Down:
                    nextPosition = _currentPosition.Value.AddY(1);
                    break;
                case Direction.Left:
                    nextPosition = _currentPosition.Value.AddX(-1);
                    break;
                default:
                    throw new InvalidDataException($"Invalid direction '{direction}'");
            }

            return nextPosition;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (var y = 0; y < _map.GetLength(1); y++)
            {
                for (var x = 0; x < _map.GetLength(0); x++)
                {
                    sb.Append(this[x, y]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }

    public enum SpaceType
    {
        Free,
        Obstacle,
        Guard
    }
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left,
    }
}
