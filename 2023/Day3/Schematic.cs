namespace Day3
{
    public class Schematic
    {
        private readonly IList<IList<PartNumber>> _data;
        private readonly IList<string> _lines;

        public Schematic(IList<string> lines, IList<IList<PartNumber>> data)
        {
            _data = data;
            _lines = lines;
        }
        
        public IEnumerable<PartNumber> GetAdjacentPartNumbers(int x, int y)
        {
            var rowsOfInterest = new List<IList<PartNumber>>();
            var minY = Math.Max(0, y - 1);
            var maxY = Math.Min(_lines.Count - 1, y + 1);

            for (var i = minY; i <= maxY; i++)
            {
                rowsOfInterest.Add(_data[i]);
            }

            var minX = Math.Max(0, x - 1);
            var maxX = Math.Min(_lines[0].Length - 1, x + 1);

            var results = new HashSet<PartNumber>();

            foreach (var row in rowsOfInterest)
            {
                for (var i = minX; i <= maxX; i++)
                {
                    foreach (var part in row)
                    {
                        if (part.IsOverlapping(i))
                        {
                            results.Add(part);
                        }
                    }
                }
            }

            return results;
        }

        public int Rows => _lines.Count;
        public int Columns => _lines[0].Length;

        public bool IsSymbol(int x, int y)
        {
            switch (_lines[y][x])
            {
                case var c when char.IsDigit(c):
                case '.':
                    return false;
                default:
                    return true;
            }
        }

        public bool IsGearSymbol(int x, int y)
        {
            return _lines[y][x] == '*';
        }

        public static Schematic Load(IList<string> lines)
        {
            var data = new List<IList<PartNumber>>();

            foreach (var line in lines)
            {
                var row = PartNumber.GetPartNumbers(line);
                data.Add(row);
            }

            return new Schematic(lines, data);
        }
    }
}
