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

//await Part1(inputPath);
await Part2(inputPath);

public partial class Program
{
    private static bool Debug;

    public static async Task Part1(string inputPath)
    {
        bool result;
        var map = await Map.ReadFile(inputPath);

        do
        {
            result = map.Iterate();
        } while (result);
        
        Console.WriteLine($"Visited {map.VisitedCount} positions");
    }

    public static async Task Part2(string inputPath)
    {
        var obstructionPositionCount = 0;

        var originalMap = await Map.ReadFile(inputPath);
        var previousPositions = new HashSet<string>();
        //var logs = new List<string>();

        for (var y = 0; y < originalMap.Height; y++)
        {
            for (var x = 0; x < originalMap.Width; x++)
            {
                if (originalMap[x, y] == '#'
                    || (x == originalMap.GuardPosition.X && y == originalMap.GuardPosition.Y))
                {
                    continue;
                }

                bool iterationResult;
                
                var map = originalMap.Copy();

                map[x, y] = '#';

                previousPositions.Add(GetPositionKey(map.GuardPosition, map.GuardDirection));

                do
                {
                    iterationResult = map.Iterate();

                    if (iterationResult)
                    {
                        var positionKey = GetPositionKey(map.GuardPosition, map.GuardDirection);
                        if (previousPositions.Contains(positionKey))
                        {
                            // We've found a loop!
                            obstructionPositionCount++;
                            break;
                        }

                        previousPositions.Add(positionKey);
                    }
                } while (iterationResult);

                previousPositions.Clear();
            }
        }

        Console.WriteLine($"There are {obstructionPositionCount} possible obstruction positions");
    }

    private static string GetPositionKey(Position position, Direction direction)
    {
        return $"{position}-{direction}"; ;
    }

    private enum Mode
    {
        Example,
        Test,
        Production
    }
}