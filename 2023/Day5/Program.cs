using System.Globalization;
using Day5;

var (seeds, almanac) = await ReadInput();

Part1(seeds, almanac);
Part2(seeds, almanac);


public static partial class Program
{
    private const string Seeds = "seeds: ";

    public static async Task<(IList<long> seeds, Almanac almanac)> ReadInput()
    {
        var lines = await File.ReadAllLinesAsync("input.txt");
        IList<long> seeds = null;
        Map seedToSoilMap = null;
        Map soilToFertilizerMap = null;
        Map fertilizerToWaterMap = null;
        Map waterToLightMap = null;
        Map lightToTemperatureMap = null;
        Map temperatureToHumidityMap = null;
        Map humidityToLocationMap = null;

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            if (line.StartsWith("seeds: "))
            {
                seeds = line
                    .Substring(Seeds.Length)
                    .Split((' '))
                    .Select(x => long.Parse(x.Trim()))
                    .ToList();
            }
            else if (line.StartsWith("seed-to-soil map:"))
            {
                seedToSoilMap = ParseRecords(lines, ref i);
            }
            else if (line.StartsWith("soil-to-fertilizer map:"))
            {
                soilToFertilizerMap = ParseRecords(lines, ref i);
            }
            else if (line.StartsWith("fertilizer-to-water map:"))
            {
                fertilizerToWaterMap = ParseRecords(lines, ref i);
            }
            else if (line.StartsWith("water-to-light map:"))
            {
                waterToLightMap = ParseRecords(lines, ref i);
            }
            else if (line.StartsWith("light-to-temperature map:"))
            {
                lightToTemperatureMap = ParseRecords(lines, ref i);
            }
            else if (line.StartsWith("temperature-to-humidity map:"))
            {
                temperatureToHumidityMap = ParseRecords(lines, ref i);
            }
            else if (line.StartsWith("humidity-to-location map:"))
            {
                humidityToLocationMap = ParseRecords(lines, ref i);
            }
        }

        return (seeds, new Almanac(seedToSoilMap, soilToFertilizerMap, fertilizerToWaterMap, waterToLightMap, lightToTemperatureMap, temperatureToHumidityMap, humidityToLocationMap));
    }

    private static Map ParseRecords(IList<string> lines, ref int index)
    {
        string line;
        var map = new Map();

        do
        {
            line = lines[++index];

            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            var split = line.Split(' ').Select(long.Parse).ToList();
            var destination = split[0];
            var source = split[1];
            var range = split[2];

            map.Add(destination, source, range);
        }
        while (index < lines.Count - 1);

        return map;
    }

    private static void Part1(IList<long> seeds, Almanac almanac)
    {
        var location = seeds.Select(x => almanac.GetLocationFromSeed(x)).Min();
        Console.WriteLine($"Part 1: {location}");
    }

    private static void Part2(IList<long> seeds, Almanac almanac)
    {
        long startIndex = 0, smallestLocation = long.MaxValue;

        for (var i = 0; i < seeds.Count; i++)
        {
            if (i % 2 == 0)
            {
                startIndex = seeds[i];
            }
            else
            {
                var range = seeds[i];

                Console.WriteLine($"Processing {startIndex} - {startIndex + range}");

                for (var j = startIndex; j < startIndex + range; j++)
                {
                    var location = almanac.GetLocationFromSeed(j);
                    if (location < smallestLocation)
                    {
                        smallestLocation = location;
                        Console.WriteLine($"New location: {smallestLocation}");
                    }
                }
            }
        }
    }
}