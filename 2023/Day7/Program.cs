using Day7;

await Run(Part.One);
await Run(Part.Two);

public static partial class Program
{
    private static async Task<IList<Hand>> ReadInput(Part part)
    {
        //var filename = "example.txt";
        var filename = "input.txt";
        //var filename = "test.txt";
        var lines = await File.ReadAllLinesAsync(filename);
        
        return lines.Select(x => HandParser.Parse(x, part)).ToList();
    }
    
    private static async Task Run(Part part)
    {
        var hands = await ReadInput(part);

        var orderedHands = hands.OrderBy(x => x);

        var rank = 1;
        var winnings = 0;

        foreach (var hand in orderedHands)
        {
            var score = rank * hand.Bid;
            
            Console.WriteLine($"Raw: {hand.RawInput},\tRank: {rank},\tType: {hand.HandType},\tBid: {hand.Bid},\tScore: {score}");

            winnings += score;

            rank++;
        }

        Console.WriteLine($"Part {part}: {winnings}");
    }
}