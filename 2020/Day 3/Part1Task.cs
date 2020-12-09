using System.Collections.Generic;

namespace Day_3
{
    public class Part1Task
        : Task
    {
        public Part1Task(IList<string> data)
            : base(data)
        {
        }

        public override void Run()
        {
            Result = GetNumberOfTrees(3, 1);
        }
    }
}
