using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public class Part2Task
        : Task
    {
        public Part2Task(IList<string> testData) : base(testData)
        {
        }

        public override void Run()
        {
            var bag = Bags.First(b => b.Colour == "shiny gold");
            Result = bag.NumberOfSubBags;
        }
    }
}
