using System;
using System.Collections.Generic;
using Day_11.Rules;

namespace Day_11
{
    public class Part1Task
        : Task
    {
        public Part1Task(IList<string> data) : base(data)
        {
        }

        public override void Run()
        {
            var rules = new IRule[]
            {
                new EmptySeatRule(),
                new OccupiedSeatRule()
            };

            var map = InitialMap;
            int numChanged;

            do
            {
                map = Pass(map, rules, out numChanged);
            } while (numChanged > 0);

            Result = map.NumberOfOccupiedSeats;
        }

        public static SeatMap Pass(SeatMap map, IList<IRule> rules, out int numChanged)
        {
            var updatedMap = map.Copy();
            numChanged = 0;

            for (var y = 0; y < map.Height; y++)
            {
                for (var x = 0; x < map.Width; x++)
                {
                    foreach (var rule in rules)
                    {
                        if (rule.Applies(map, x, y, out var status))
                        {
                            updatedMap[x, y] = status.Value;
                            numChanged++;
                            break;
                        }
                    }
                }
            }

            return updatedMap;
        }
    }
}
