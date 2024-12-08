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

//Part1(wordSearch);
Part2(wordSearch);

public partial class Program
{
    private static bool Debug;

    public static void Part1(WordSearch wordSearch)
    {
        var result = 0;

        for (var y = 0; y < wordSearch.Height; y++)
        {
            for (var x = 0; x < wordSearch.Width; x++)
            {
                foreach (var direction in Enum.GetValues<Direction>())
                {
                    if (wordSearch.Match(x, y, "XMAS", direction))
                    {
                        result++;
                    }
                }
            }
        }

        Console.WriteLine(result);
    }

    public static void Part2(WordSearch wordSearch)
    {
        var result = 0;

        for (var y = 0; y < wordSearch.Height; y++)
        {
            for (var x = 0; x < wordSearch.Width; x++)
            {
                if (wordSearch.ConvolutionFilter(x, y))
                {
                    result++;
                }
            }
        }

        Console.WriteLine(result);
    }

    private static bool Match(WordSearch wordSearch, int x, int y, char expectedChar)
    {
        return wordSearch[x, y] == expectedChar;
    }

    private enum Mode
    {
        Example,
        Test,
        Production
    }
}