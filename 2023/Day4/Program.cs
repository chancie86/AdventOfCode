using System.Text.RegularExpressions;
using Day4;

var cards = await ReadInput();

// Part 1
var points = cards.Sum(x => x.GetPoints());
Console.WriteLine($"Part 1: {points}");

// Part 2
Console.WriteLine($"Part 2: {CountCopies(cards)}");

public static partial class Program
{
    public static async Task<IList<Card>> ReadInput()
    {
        var lines = await File.ReadAllLinesAsync("input.txt");
        var cardRegex = new Regex("Card[ ]+(?<cardId>[0-9]+):[ ]+(?<winningNumbers>[^|]+)+\\|[ ]+(?<cardNumbers>[^$]+)+");

        var result = new List<Card>();

        foreach (var line in lines)
        {
            var match = cardRegex.Match(line);

            var id = int.Parse(match.Groups["cardId"].Value);
            
            var winningNumbersText = match.Groups["winningNumbers"].Value;
            var winningNumbers = winningNumbersText
                .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            
            var cardNumbersText = match.Groups["cardNumbers"].Value;
            var cardNumbers = cardNumbersText
                .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            result.Add(new Card(id, winningNumbers, cardNumbers));
        }

        return result;
    }


    public static int CountCopies(IList<Card> cards)
    {
        var instances = cards.ToDictionary(x => x, _ => 1);

        for (var i = 0; i < cards.Count; i++)
        {
            var card = cards[i];
            var matches = card.GetNumberOfMatches();

            for (var j = i + 1; j < i + 1 + matches; j++)
            {
                if (j < cards.Count)
                {
                    instances[cards[j]] += instances[cards[i]];
                }
            }
        }
        
        return instances.Sum(x => x.Value);
    }
}