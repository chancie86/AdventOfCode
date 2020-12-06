using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day5
{
    public class Part2Task
        : Task
    {
        private int _result;

        public Part2Task(IList<string> data) : base(data)
        {
        }


        public override void Run()
        {
            var map = new Dictionary<int, BoardingPass>();
            var minId = int.MaxValue;
            var maxId = int.MinValue;

            foreach (var pass in ParseBoardingPasses())
            {
                map[pass.Id] = pass;
                if (pass.Id > maxId)
                {
                    maxId = pass.Id;
                }

                if (pass.Id < minId)
                {
                    minId = pass.Id;
                }
            }

            for (var i = minId; i <= maxId; i++)
            {
                if (!map.ContainsKey(i)
                    && map.ContainsKey(i - 1)
                    && map.ContainsKey(i + 1))
                {
                    _result = i;
                }
            }
        }

        public override string ToString()
        {
            return $"{_result}";
        }
    }
}
