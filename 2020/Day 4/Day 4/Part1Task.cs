using System;
using System.Collections.Generic;
using System.Text;

namespace Day_4
{
    public class Part1Task
        : Task
    {
        public Part1Task(string batchData)
            : base(batchData)
        {
        }

        public override void Run()
        {
            Parse(false);
        }
    }
}
