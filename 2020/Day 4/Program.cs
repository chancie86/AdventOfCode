﻿using System;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var part1 = new Part1Task(TestData.Data);
            part1.Run();
            Console.WriteLine($"Part 1: {part1}");

            var part2 = new Part2Task(TestData.Data);
            part2.Run();
            Console.WriteLine($"Part 1: {part2}");
        }
    }
}
