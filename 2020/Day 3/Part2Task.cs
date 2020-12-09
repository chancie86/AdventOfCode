using System.Collections.Generic;
using System.Linq;

namespace Day_3
{
    public class Part2Task
        : Task
    {
        public Part2Task(IList<string> data)
            : base(data)
        {
        }

        public override void Run()
        {
            var results = new List<int>
            {
                GetNumberOfTrees(1, 1),
                GetNumberOfTrees(3, 1),
                GetNumberOfTrees(5, 1),
                GetNumberOfTrees(7, 1),
                GetNumberOfTrees(1, 2)
            };

            long count = 1;
            foreach (var result in results)
            {
                count = count * result;
            }

            Result = count;
        }
    }
}
