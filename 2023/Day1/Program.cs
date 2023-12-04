var lines = await File.ReadAllLinesAsync("input.txt");

// Part 1

var part1CalibrationValues = GetCalibrationValues(lines, true);
Console.WriteLine($"Part 1: {part1CalibrationValues.Sum()}");


// Part 2
var part2CalibrationValues = GetCalibrationValues(lines, false);
Console.WriteLine($"Part 2: {part2CalibrationValues.Sum()}");


public static partial class Program
{
    private static readonly IDictionary<string, char> _tokens = new Dictionary<string, char>
    {
        {"one", '1'},
        {"two", '2'},
        {"three", '3'},
        {"four", '4'},
        {"five", '5'},
        {"six", '6'},
        {"seven", '7'},
        {"eight", '8'},
        {"nine", '9'},
    };

    public static IEnumerable<int> GetCalibrationValues(IEnumerable<string> lines, bool digitsOnly)
    {
        var result = new List<int>();

        foreach (var line in lines)
        {
            var firstDigit = GetFirstNumber(line, Direction.Forward, digitsOnly);
            var lastDigit = GetFirstNumber(line, Direction.Backward, digitsOnly);
            result.Add(byte.Parse($"{firstDigit}{lastDigit}"));
        }

        return result;
    }

    private static char GetFirstNumber(string text, Direction direction, bool digitsOnly)
    {
        int startIndex, increment;
        Func<int, bool> comparator;

        if (direction == Direction.Forward)
        {
            startIndex = 0;
            increment = 1;
            comparator = x => x < text.Length;
        }
        else
        {
            startIndex = text.Length - 1;
            increment = -1;
            comparator = x => x > -1;
        }

        for (var i = startIndex; comparator(i); i += increment)
        {
            var value = text[i];

            if (char.IsDigit(value))
            {
                return value;
            }
            
            if (!digitsOnly && TryGetDigitFromWord(text, i, out var result))
            {
                return result;
            }
        }

        throw new ArgumentException($"No digit found in text '{text}'");
    }

    private static bool TryGetDigitFromWord(string text, int index, out char result)
    {
        foreach (var token in _tokens.Keys)
        {
            if (index + token.Length > text.Length)
            {
                continue;
            }

            var subs = text.Substring(index, token.Length);

            if (string.Equals(token, subs, StringComparison.OrdinalIgnoreCase))
            {
                result = _tokens[token];
                return true;
            }
        }

        result = default;
        return false;
    }

    private enum Direction
    {
        Forward,
        Backward
    }
}
