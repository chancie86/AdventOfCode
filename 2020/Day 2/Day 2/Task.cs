using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_2
{
    public abstract class Task
    {
        private readonly IList<string> _data;
        private int? _result;

        public Task(IList<string> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public void Run()
        {
            _result = _data.Count(line => Parse(line).IsValid());
        }

        protected Password Parse(string line)
        {
            var pattern = "(?<first>[0-9]+)-(?<second>[0-9]+) (?<char>[a-z]+): (?<password>[a-z]+)";
            var matches = Regex.Matches(line, pattern);

            if (matches.Count != 1)
            {
                throw new ArgumentException($"Invalid line: {line}", nameof(line));
            }

            var match = matches.First();

            if (match.Groups.Count != 5)
            {
                throw new ArgumentException($"Invalid line: {line}", nameof(line));
            }

            return GetPassword(match);
        }

        protected abstract Password GetPassword(Match match);

        public override string ToString()
        {
            return $"{(_result.HasValue ? _result.Value.ToString() : "unknown")}";
        }
    }
}
