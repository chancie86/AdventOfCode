using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day_3
{
    public class Map
    {
        private IList<char[]> _map;
        private readonly int _mapWidth;

        public Map(IList<string> data)
        {
            _map = new List<char[]>(data.Count);
            _mapWidth = data[0].Length;

            foreach (var line in data)
            {
                _map.Add(line.ToCharArray());
            }
        }

        public int Height => _map.Count;

        public bool IsTree(int x, int y)
        {
            return _map[y][x % _mapWidth] == '#';
        }
    }
}
