using System;
using System.Collections.Generic;

namespace Day1
{
    public class Part1Task
    {
        private int? _result;

        public Part1Task(IList<int> data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public IList<int> Data { get; }

        public void Run()
        {
            _result = FindMatches();
        }

        private int FindMatches()
        {
            for (var i = 0; i < Data.Count; i++)
            {
                for (var j = i; j < Data.Count; j++)
                {
                    var a = Data[i];
                    var b = Data[j];

                    if (CheckSum(a, b))
                    {
                        return a * b;
                    }
                }
            }

            throw new Exception("Couldn't find expected number of matches");
        }

        protected static bool CheckSum(int a, int b)
        {
            return (a + b) == 2020;
        }

        public override string ToString()
        {
            return $"{nameof(Part1Task)}: {_result.Value}";
        }
    }
}
