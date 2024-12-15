using System.Text;
using Day7;

var mode = Mode.Production;
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

var equations = await ReadFile(inputPath);

await Part1(equations);
//await Part2(inputPath);

public partial class Program
{
    private static bool Debug;
    private static readonly char[] _operators = new[] { '+', '*' };

    public static async Task Part1(List<Equation> equations)
    {
        var result = 0L;

        foreach (var equation in equations)
        {
            var validEquations = new List<string>();

            FindValidOperations(validEquations, equation);

            if (validEquations.Any())
            {
                result += equation.TestValue;
            }

            if (Debug)
            {
                foreach (var validEquation in validEquations)
                {
                    Console.WriteLine($"{validEquation} = {equation.TestValue}");
                }
            }
        }

        Console.WriteLine(result);
    }

    public static async Task Part2(List<Equation> equations)
    {

    }

    private static void FindValidOperations(List<string> results, Equation equation)
    {
        Span<long> span = equation.Numbers.ToArray();
        var currentValue = span[0];
        var steps = new StringBuilder($"{span[0]}");

        FindValidOperations(results, equation.TestValue, currentValue, span.Slice(1), steps);
    }

    private static void FindValidOperations(List<string> results, long expectedResult, long currentValue, Span<long> span, StringBuilder steps)
    {
        if (span.IsEmpty)
        {
            if (expectedResult == currentValue)
            {
                results.Add(steps.ToString());
            }

            return;
        }

        foreach (var op in _operators)
        {
            var newSteps = new StringBuilder(steps.ToString());
            long nextValue;

            newSteps.Append(op);
            newSteps.Append(span[0]);

            switch (op)
            {
                case '*':
                    nextValue = currentValue * span[0];
                    break;
                case '+':
                    nextValue = currentValue + span[0];
                    break;
                default:
                    throw new InvalidOperationException();
            }

            FindValidOperations(results, expectedResult, nextValue, span.Slice(1), newSteps);
        }
    }

    public static async Task<List<Equation>> ReadFile(string inputPath)
    {
        var lines = await File.ReadAllLinesAsync(inputPath);
        return lines.Select(Equation.Parse).ToList();
    }

    private enum Mode
    {
        Example,
        Test,
        Production
    }
}