using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public class Part1Task
        : Task
    {
        public Part1Task(IList<string> testData) : base(testData)
        {
        }

        public override void Run()
        {
            Result = Bags.Count(bag => bag.Contains("shiny gold"));
        }
    }
}
