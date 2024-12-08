using Day4;

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

var input = await File.ReadAllLinesAsync(inputPath);

var wordSearch = new WordSearch(input);

Part1(wordSearch);
//Part2(input);

public partial class Program
{
    private static bool Debug;

    public static void Part1(WordSearch wordSearch)
    {
    }

    public static void Part2(WordSearch wordSearch)
    {
    }

    private static bool Match(WordSearch wordSearch, int x, int y)
    {
        var searchString = "XMAS";

        if (wordSearch[x, y] != searchString[0])
        {
            return false;
        }

        foreach (var direction in Enum.GetValues<Direction>())
        {
            
        }
    }

    private static bool Match(WordSearch wordSearch, int x, int y, char expectedChar)
    {
        return wordSearch[x, y] == expectedChar;
    }

    private static (int x, int y) GetNextCoordinate(int x, int y)
    {
        
    }

    private enum Mode
    {
        Example,
        Test,
        Production
    }
}