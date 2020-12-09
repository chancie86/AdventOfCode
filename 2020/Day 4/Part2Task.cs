using System;
using System.Collections.Generic;
using System.Text;

namespace Day_4
{
    public class Part2Task
        : Task
    {
        public Part2Task(string batchData)
            : base(batchData)
        {
        }

        public override void Run()
        {
            Parse(true);
        }
    }
}
