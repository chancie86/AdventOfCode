
using Day3;

var schematic = await ReadInput();

var partNumbers = new HashSet<PartNumber>();
var gearRatios = 0;

for (var y = 0; y < schematic.Rows; y++)
{
    for (var x = 0; x < schematic.Columns; x++)
    {
        if (schematic.IsSymbol(x, y))
        {
            var adjacentPartNumbers = schematic.GetAdjacentPartNumbers(x, y);

            foreach (var pn in adjacentPartNumbers)
            {
                partNumbers.Add(pn);
            }

            if (schematic.IsGearSymbol(x, y)
                && adjacentPartNumbers.Count() == 2)
            {
                gearRatios += adjacentPartNumbers.First().Number * adjacentPartNumbers.Last().Number;
            }
        }
    }
}

Console.WriteLine($"Part 1: {partNumbers.Sum(x => x.Number)}");

Console.WriteLine($"Part 2: {gearRatios}");

public partial class Program
{
    public static async Task<Schematic> ReadInput()
    {
        var lines = await File.ReadAllLinesAsync("input.txt");
        
        return Schematic.Load(lines);
    }
}