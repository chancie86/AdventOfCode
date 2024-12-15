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

//await Part1(equations);
await Part2(equations);

public partial class Program
{
    private static bool Debug;

    private static char[] Operators { get; set; }

    public static async Task Part1(List<Equation> equations)
    {
        Operators = new[] { '+', '*' };
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
        Operators = new[] { '+', '*', '|' };
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
                    Console.WriteLine($"{string.Join("", validEquation)} = {equation.TestValue}");
                }
            }
        }

        Console.WriteLine(result);
    }

    private static void FindValidOperations(List<string> results, Equation equation)
    {
        Span<long> span = equation.Numbers.ToArray();
        var currentValue = span[0];
        var steps = new List<string>
        {
            $"{span[0]}"
        };

        FindValidOperations(results, equation.TestValue, currentValue, span.Slice(1), steps);
    }

    private static void FindValidOperations(List<string> results, long expectedResult, long currentValue, Span<long> span, List<string> steps)
    {
        if (span.IsEmpty)
        {
            if (expectedResult == currentValue)
            {
                results.Add(string.Join("", steps));
            }

            return;
        }

        foreach (var op in Operators)
        {
            var newSteps = new List<string>(steps);
            long nextValue;

            switch (op)
            {
                case '*':
                    newSteps.Add(op.ToString());
                    newSteps.Add(span[0].ToString());
                    nextValue = currentValue * span[0];
                    break;
                case '+':
                    newSteps.Add(op.ToString());
                    newSteps.Add(span[0].ToString());
                    nextValue = currentValue + span[0];
                    break;
                case '|':
                    // Replace the last element with a concatenation of the last value and the current one
                    currentValue = long.Parse($"{currentValue}{span[0]}");
                    newSteps.Add(span[0].ToString());
                    nextValue = currentValue;
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