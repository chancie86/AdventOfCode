namespace Day5
{
    public class Rule
    {
        public Rule(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentException($"Invalid input: '{line}'", nameof(line));
            }

            var split = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
            Before = int.Parse(split[0]);
            After = int.Parse(split[1]);
        }

        public int Before { get; set; }
        public int After { get; set; }

        public bool Validate(IEnumerable<int> data)
        {
            var foundAfter = false;

            foreach (var datum in data)
            {
                foundAfter |= datum == After;

                if (foundAfter
                    && datum == Before)
                {
                    return false;
                }
            }

            return true;
        }

        public bool Validate(int a, int b)
        {
            if (!Match(a, b))
            {
                return true;
            }

            if (a == Before)
            {
                return true;
            }

            return false;
        }

        public bool Match(int a, int b)
        {
            return (a == Before || a == After)
                && (b == Before || b == After);
        }
    }
}
