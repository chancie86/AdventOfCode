using System.Text.RegularExpressions;

var mode = Mode.Production;
string inputPath;

switch (mode)
{
    case Mode.Example1:
        Debug = true;
        inputPath = "example1.txt";
        break;
    case Mode.Example2:
        Debug = true;
        inputPath = "example2.txt";
        break;
    case Mode.Test:
        Debug = true;
        inputPath = "tests.txt";
        break;
    case Mode.Production:
        Debug = false;
        inputPath = "input.txt";
        break;
    default:
        throw new Exception("Invalid mode");
}

var input = await File.ReadAllLinesAsync(inputPath);

//Part1(input);
Part2(input);

public partial class Program
{
    private static bool Debug;

    public static void Part1(IEnumerable<string> rawData)
    {
        var pattern = "mul\\((?<first>[0-9]+),(?<second>[0-9]+)\\)";

        var result = 0;

        foreach (var line in rawData)
        {
            var matches = Regex.Matches(line, pattern);
            foreach (Match match in matches)
            {
                var first = int.Parse(match.Groups["first"].Value);
                var second = int.Parse(match.Groups["second"].Value);
                result += first * second;
            }
        }

        Console.WriteLine(result);
    }

    public static void Part2(IEnumerable<string> rawData)
    {
        var result = 0;
        var enabled = true;

        foreach (var line in rawData)
        {
            var matches = Regex.Matches(line, @"(mul\((?<first>[0-9]{1,3}),(?<second>[0-9]{1,23})\)|do\(\)|don't\(\))");

            foreach (Match match in matches)
            {
                if (match.Value.Equals("do()"))
                {
                    enabled = true;
                }
                else if (match.Value.Equals("don't()"))
                {
                    enabled = false;
                }
                else if (enabled && match.Value.StartsWith("mul"))
                {
                    var first = int.Parse(match.Groups["first"].Value);
                    var second = int.Parse(match.Groups["second"].Value);
                    result += first * second;
                }
            }
        }

        Console.WriteLine(result);
    }

    private enum Mode
    {
        Example1,
        Example2,
        Test,
        Production
    }
}