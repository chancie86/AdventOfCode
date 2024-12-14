using Day6;

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

var map = await Map.ReadFile(inputPath);

Part1(map);
//Part2(rules, updates);

public partial class Program
{
    private static bool Debug;

    public static void Part1(Map map)
    {
        bool result;

        do
        {
            result = map.Iterate();

            if (Debug)
            {
                Console.WriteLine(map);
            }
        } while (result);
        
        Console.WriteLine($"Visited {map.VisitedCount} positions");
    }

    public static void Part2(Map map)
    {
        var result = 0;
        Console.WriteLine(result);
    }

    private enum Mode
    {
        Example,
        Test,
        Production
    }
}