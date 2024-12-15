using System.Text.RegularExpressions;

namespace Day7
{
    public class Equation
    {
        

        public Equation(long testValue, List<long> numbers)
        {
            TestValue = testValue;
            Numbers = numbers;
        }

        public static Equation Parse(string data)
        {
            var match = Regex.Matches(data, "(?<test>[0-9]+):( (?<num>[0-9]+))+").Single();

            var testValue = long.Parse(match.Groups["test"].Value);
            var numbers = match
                .Groups["num"]
                .Captures
                .Select(c => long.Parse(c.Value))
                .ToList();

            return new Equation(testValue, numbers);
        }

        public long TestValue { get; set; }
        public List<long> Numbers { get; set; }
    }
}
