using System.Text.RegularExpressions;

//const string inputPath = "example.txt";
const string inputPath = "input.txt";

var input = await File.ReadAllLinesAsync(inputPath);

var regex = new Regex(@"(?<first>[0-9]+)\s+(?<second>[0-9]+)");

var firstList = new List<int>();
var secondList = new List<int>();

foreach (var line in input)
{
    var match = regex.Match(line);
    var first = int.Parse(match.Groups["first"].Value);
    var second = int.Parse(match.Groups["second"].Value);

    firstList.Add(first);
    secondList.Add(second);
}

//await Part1(firstList, secondList);
await Part2(firstList, secondList);

public partial class Program
{
    public static async Task Part1(List<int> firstList, List<int> secondList)
    {
        firstList = firstList.OrderBy(x => x).ToList();
        secondList = secondList.OrderBy(x => x).ToList();

        var distance = 0;

        for (var i = 0; i < firstList.Count; i++)
        {
            distance += Math.Abs(firstList[i] - secondList[i]);
        }

        Console.WriteLine(distance);
    }

    public static async Task Part2(List<int> firstList, List<int> secondList)
    {
        var numberCount = new Dictionary<int, int>();

        foreach (var item in secondList)
        {
            var count = 0;
            numberCount.TryGetValue(item, out count);
            count++;

            numberCount[item] = count;
        }

        var result = 0;

        foreach (var item in firstList)
        {
            if (numberCount.TryGetValue(item, out var count))
            {
                result += item * numberCount[item];
            }
        }

        Console.WriteLine(result);
    }
}