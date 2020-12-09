using System;
using System.Collections.Generic;

namespace Day1
{
    public class Part2Task
    {
        private int? _result;

        public Part2Task(IList<int> data)
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
                    for (var k = j; k < Data.Count; k++)
                    {
                        var a = Data[i];
                        var b = Data[j];
                        var c = Data[k];

                        if (CheckSum(a, b, c))
                        {
                            return a * b * c;
                        }
                    }
                }
            }

            throw new Exception("Couldn't find expected number of matches");
        }

        protected static bool CheckSum(int a, int b, int c)
        {
            return (a + b + c) == 2020;
        }

        public override string ToString()
        {
            return $"{nameof(Part2Task)}: {_result.Value}";
        }
    }
}