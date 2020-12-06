using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day5
{
    public class Part1Task
        : Task
    {
        private int _result;

        public Part1Task(IList<string> data) : base(data)
        {
        }


        public override void Run()
        {
            _result = ParseBoardingPasses().Max(s => s.Id);
        }

        public override string ToString()
        {
            return $"{_result}";
        }
    }
}
