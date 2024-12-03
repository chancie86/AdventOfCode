namespace Day2
{
    public class Report
    {
        private readonly string _data;
        private readonly List<int> _levels;

        public Report(string data)
        {
            _data = data;
            var levelsRaw = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            _levels = levelsRaw.Select(int.Parse).ToList();
        }

        public bool IsSafe(bool useDampener)
        {
            var index = Validate(ValidationMode.Increasing);

            if (index < 0)
            {
                return true;
            }

            if (useDampener)
            {
                var alternateReport = new Report(_data);
                alternateReport._levels.RemoveAt(index);
                index = alternateReport.Validate(ValidationMode.Increasing);

                if (index < 0)
                {
                    return true;
                }
            }

            if (useDampener)
            {
                var alternateReport = new Report(_data);
                alternateReport._levels.RemoveAt(0);
                index = alternateReport.Validate(ValidationMode.Increasing);

                if (index < 0)
                {
                    return true;
                }
            }

            index = Validate(ValidationMode.Decreasing);

            if (index < 0)
            {
                return true;
            }

            if (useDampener)
            {
                var alternateReport = new Report(_data);
                alternateReport._levels.RemoveAt(index);
                index = alternateReport.Validate(ValidationMode.Decreasing);

                if (index < 0)
                {
                    return true;
                }
            }

            if (useDampener)
            {
                var alternateReport = new Report(_data);
                alternateReport._levels.RemoveAt(0);
                index = alternateReport.Validate(ValidationMode.Decreasing);

                if (index < 0)
                {
                    return true;
                }
            }

            Console.WriteLine($"{ToString()}: false");

            return false;
        }

        private int Validate(ValidationMode mode)
        {
            var counts = new Dictionary<int, int>();
            foreach (var level in _levels)
            {
                if (!counts.TryAdd(level, 1))
                {
                    counts[level]++;
                }
            }

            var sortedLevels = mode == ValidationMode.Increasing
                ? _levels.OrderBy(x => x).ToList()
                : _levels.OrderByDescending(x => x).ToList();

            for (var i = 0; i < _levels.Count; i++)
            {
                if (_levels[i] != sortedLevels[i])
                {
                    return i;
                }

                if (counts[sortedLevels[i]] > 1)
                {
                    return i;
                }

                if (i != 0)
                {
                    var currentLevel = sortedLevels[i];
                    var previousLevel = sortedLevels[i - 1];

                    var difference = Math.Abs(currentLevel - previousLevel);
                    if (difference < 1
                        || difference > 3)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public override string ToString()
        {
            return _data;
        }

        private enum ValidationMode
        {
            Increasing,
            Decreasing
        }
    }
}
