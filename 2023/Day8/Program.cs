using System.Text.RegularExpressions;
using Day8;

var (network, instructions) = await ReadInput();
Part1(network, instructions);
Part2(network, instructions);

public static partial class Program
{
    private static async Task<(Network, Instructions)> ReadInput()
    {
        //var filename = "example1.txt";
        //var filename = "example2.txt";
        var filename = "input.txt";
        var lines = await File.ReadAllLinesAsync(filename);

        // First line contains the instructions.
        var instructions = new Instructions(lines[0]);

        // Second line is blank

        var network = new Network();

        // Following lines describe the network
        for (var i = 2; i < lines.Length; i++)
        {
            var regex = new Regex("(?<nodeId>[0-9A-Z]{3}) = \\((?<leftId>[0-9A-Z]{3}), (?<rightId>[0-9A-Z]{3})\\)");
            var matches = regex.Match(lines[i]);

            if (!matches.Success)
            {
                throw new InvalidDataException(lines[i]);
            }

            var nodeId = matches.Groups["nodeId"].Value;
            var leftId = matches.Groups["leftId"].Value;
            var rightId = matches.Groups["rightId"].Value;

            network.AddLink(nodeId, leftId, rightId);
        }

        return (network, instructions);
    }

    private static void Part1(Network network, Instructions instructions)
    {
        var node = network.GetNode("AAA");
        var count = 0;

        while (node.Id != "ZZZ")
        {
            var instruction = instructions.Pop();

            switch (instruction)
            {
                case Instruction.Left:
                    node = node.Left;
                    break;
                case Instruction.Right:
                    node = node.Right;
                    break;
            }

            count++;
        }

        Console.WriteLine($"Part 1: {count}");
    }

    private static void Part2(Network network, Instructions instructions)
    {
        var nodes = network.Where(x => x.Id.EndsWith('A')).ToList();
        var count = 0L;
        
        while (!nodes.All(x => x.Id.EndsWith('Z')))
        {
            //Console.WriteLine($"Count: {count}, NumNodes: {nodes.Count()}, ids: {string.Join(',', nodes.Select(x => x.Id))}");

            var instruction = instructions.Pop();

            switch (instruction)
            {
                case Instruction.Left:
                    nodes = nodes.Select(x => x.Left).ToList();
                    break;
                case Instruction.Right:
                    nodes = nodes.Select(x => x.Right).ToList();
                    break;
            }

            count++;
        }

        Console.WriteLine($"Part 2: {count}");
    }
}