using Day2;

var mode = Mode.Test;
string inputPath;

switch (mode)
{
    case Mode.Example:
        Debug = true;
        inputPath = "example.txt";
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

var reports = input.Select(x => new Report(x));

//Part1(reports);
Part2(reports);

//var cheat = new Cheat();
//var result = await cheat.SolveAsync(inputPath);
//Console.WriteLine(result);


public partial class Program
{
    private static bool Debug;

    public static void Part1(IEnumerable<Report> reports)
    {
        Run(reports, false);
    }

    public static void Part2(IEnumerable<Report> reports)
    {
        Run(reports, true);
    }

    private static void Run(IEnumerable<Report> reports, bool useDampener)
    {
        var safeCount = reports.Where(x =>
        {
            var result = x.IsSafe(useDampener);

            if (Debug)
            {
                Console.WriteLine($"{x}: {(result ? "Safe" : "Unsafe")}");
            }

            return result;
        });
        Console.WriteLine($"Safe ports: {safeCount.Count()}");
    }

    

    private enum Mode
    {
        Example,
        Test,
        Production
    }
}

public class Cheat
{
    public async Task<string> SolveAsync(string inputPath)
    {
        var input = await File.ReadAllLinesAsync(inputPath);

        var safeCount = 0;

        foreach (var line in input)
        {
            var report = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            if (IsSafe(report))
            {
                safeCount++;
            }
            else
            {
                for (int i = 0; i < report.Count; i++)
                {
                    var reportCopy = report.ToList();
                    reportCopy.RemoveAt(i);
                    if (IsSafe(reportCopy))
                    {
                        safeCount++;
                        break;
                    }
                }

                Console.WriteLine($"{line}: False");
            }
        }

        return safeCount.ToString();
    }

    public bool IsSafe(List<int> report)
    {
        if (report.Count < 2)
        {
            return true;
        }

        var firstDiff = report[1] - report[0];

        if (firstDiff == 0 || Math.Abs(firstDiff) > 3)
        {
            return false;
        }

        var expectedSgn = firstDiff / Math.Abs(firstDiff);

        for (int i = 1; i < report.Count - 1; i++)
        {
            var diff = report[i + 1] - report[i];
            if (diff == 0 || Math.Abs(diff) > 3)
            {
                return false;
            }

            var sgn = diff / Math.Abs(diff);
            if (sgn != expectedSgn)
            {
                return false;
            }
        }

        return true;
    }
}