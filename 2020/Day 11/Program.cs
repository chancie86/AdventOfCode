using System;

namespace Day_11
{
    class Program
    {
        static void Main(string[] args)
        {
            var part1 = new Part1Task(TestData.Data);
            part1.Run();
            Console.WriteLine($"Part 1: {part1}");
        }
    }
}
