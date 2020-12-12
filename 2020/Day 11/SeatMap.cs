using System;
using System.Collections.Generic;
using System.Text;

namespace Day_11
{
    public class SeatMap
    {
        private readonly SeatStatus[,] _map;

        public SeatMap(IList<string> data)
        {
            _map = ParseInput(data);
        }

        private SeatMap(SeatMap map)
        {
            _map = new SeatStatus[map.Width, map.Height];
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    _map[x, y] = map[x, y];
                }
            }
        }

        public int NumberOfOccupiedSeats
        {
            get
            {
                var count = 0;
                for (var y = 0; y < Height; y++)
                {
                    for (var x = 0; x < Width; x++)
                    {
                        count += _map[x, y] == SeatStatus.Occupied ? 1 : 0;
                    }
                }

                return count;
            }
        }

        private static SeatStatus[,] ParseInput(IList<string> data)
        {
            var map = new SeatStatus[data[0].Length, data.Count];

            for (var y = 0; y < data.Count; y++)
            {
                var line = data[y];

                for (var x = 0; x < line.Length; x++)
                {
                    switch (line[x])
                    {
                        case '#':
                            map[x, y] = SeatStatus.Occupied;
                            break;
                        case '.':
                            map[x, y] = SeatStatus.Floor;
                            break;
                        case 'L':
                            map[x, y] = SeatStatus.Empty;
                            break;
                    }
                }
            }

            return map;
        }

        public SeatStatus this[int x, int y]
        {
            get => _map[x, y];
            set => _map[x, y] = value;
        }

        public int Width => _map.GetLength(0);

        public int Height => _map.GetLength(1);

        public void ForEachAdjacentSeat(int seatX, int seatY, Func<SeatStatus, bool> shouldContinue)
        {
            var minY = Math.Max(0, seatY - 1);
            var maxY = Math.Min(Height - 1, seatY + 1);
            var minX = Math.Max(0, seatX - 1);
            var maxX = Math.Min(Width - 1, seatX + 1);

            for (var y = minY; y <= maxY; y++)
            {
                for (var x = minX; x <= maxX; x++)
                {
                    if (seatX == x && seatY == y)
                    {
                        continue;
                    }

                    if (!shouldContinue(_map[x, y]))
                    {
                        return;
                    }
                }
            }
        }

        public bool AllAdjacentSeats(int x, int y, Predicate<SeatStatus> predicate)
        {
            var result = true;

            ForEachAdjacentSeat(x, y, status =>
            {
                if (!predicate(status))
                {
                    result = false;
                    return false;
                }

                return true;
            });

            return result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    switch (_map[x, y])
                    {
                        case SeatStatus.Occupied:
                            sb.Append('#');
                            break;
                        case SeatStatus.Empty:
                            sb.Append('L');
                            break;
                        case SeatStatus.Floor:
                            sb.Append('.');
                            break;
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public SeatMap Copy()
        {
            return new SeatMap(this);
        }
    }
}
