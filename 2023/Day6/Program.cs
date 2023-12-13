using Day6;

await Part1();
await Part2();

public static partial class Program
{
    private static async Task<IList<Race>> ReadInput(bool ignoreSpaces)
    {
        var lines = await File.ReadAllLinesAsync("input.txt");
        
        if (ignoreSpaces)
        {
            var time = long.Parse(lines[0].Replace(" ", string.Empty).Substring("Time:".Length));
            var distance = long.Parse(lines[1].Replace(" ", string.Empty).Substring("Distance:".Length));

            return new[]
            {
                new Race(time, distance)
            };
        }

        var timesSplit = lines[0].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var distanceSplit = lines[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var races = new List<Race>();

        for (var i = 1; i < timesSplit.Length; i++)
        {
            var time = int.Parse(timesSplit[i]);
            var distance = int.Parse(distanceSplit[i]);

            var race = new Race(time, distance);
            races.Add(race);
        }

        return races;
    }

    private static int NumberOfWaysOfBeatingRecord(Race race)
    {
        var count = 0;

        for (var chargeTime = 1; chargeTime < race.Time; chargeTime++)
        {
            var speed = chargeTime;
            var distanceAchieved = speed * (race.Time - chargeTime);

            if (distanceAchieved > race.RecordDistance)
            {
                count++;
            }
        }

        return count;
    }

    private static async Task Part1()
    {
        var races = await ReadInput(false);
        var beatingScores = races.Select(NumberOfWaysOfBeatingRecord);

        var part1 = 1;

        foreach (var beatingScore in beatingScores)
        {
            part1 *= beatingScore;
        }

        Console.WriteLine($"Part 1: {part1}");
    }

    private static async Task Part2()
    {
        var race = (await ReadInput(true)).Single();
        Console.WriteLine($"Part 2: {NumberOfWaysOfBeatingRecord(race)}");
    }
}