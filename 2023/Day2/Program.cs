using System.Text.RegularExpressions;
using Day2;

var games = await ReadInput();
var validGames = games.Where(g => IsGamePossible(g, 12, 13, 14));

Console.WriteLine($"Part 1: {validGames.Sum(g => g.Id)}");

var maxColoursGame = games
    .Select(g => GetMaxColours(g))
    .Select(g =>
    {
        var reveals = g.Reveals.Single();
        return reveals.RedCount * reveals.GreenCount * reveals.BlueCount;
    });
Console.WriteLine($"Part 2: {maxColoursGame.Sum()}");

public partial class Program
{
    private static async Task<IList<Game>> ReadInput()
    {
        var lines = await File.ReadAllLinesAsync("input.txt");

        var gameRegex = new Regex("Game (?<id>[0-9]+): (?<reveals>[^$]+)");
        var revealRegex = new Regex("(?<reveal>([^;]+))");
        var cubesRegex = new Regex("((?<count>[0-9]+) (?<colour>[a-z]+))+");

        var result = new List<Game>();

        foreach (var line in lines)
        {
            var gameMatch = gameRegex.Match(line);

            if (!gameMatch.Success)
            {
                throw new ArgumentException($"bad data: {line}");
            }

            var id = int.Parse(gameMatch.Groups["id"].Value);
            var gameText = gameMatch.Groups["reveals"].Value;

            var game = new Game(id);

            var revealMatches = revealRegex.Matches(gameText);

            foreach (Match revealMatch in revealMatches)
            {
                var reveal = revealMatch.Groups["reveal"].Value;
                var cubesMatches = cubesRegex.Matches(reveal);

                foreach (Match cubesMatch in cubesMatches)
                {
                    int red = 0, blue = 0, green = 0;
                    
                    var count = int.Parse(cubesMatch.Groups["count"].Value);
                    var colour = cubesMatch.Groups["colour"].Value;

                    switch (colour)
                    {
                        case "red":
                            red = count;
                            break;
                        case "blue":
                            blue = count;
                            break;
                        case "green":
                            green = count;
                            break;
                        default:
                            throw new NotImplementedException();
                    }

                    game.Reveals.Add(new Reveal(blue, red, green));
                }
            }

            result.Add(game);
        }

        return result;
    }

    private static Game GetMaxColours(Game game)
    {
        var red = game.Reveals.Max(x => x.RedCount);
        var green = game.Reveals.Max(x => x.GreenCount);
        var blue = game.Reveals.Max(x => x.BlueCount);

        var result = new Game(game.Id);
        result.Reveals.Add(new Reveal(blue, red, green));
        
        return result;
    }

    private static bool IsGamePossible(Game game, int red, int green, int blue)
    {
        foreach (var reveal in game.Reveals)
        {
            if (reveal.RedCount > red
                || reveal.GreenCount > green
                || reveal.BlueCount > blue)
            {
                return false;
            }
        }

        return true;
    }
}