using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day5
{
    public abstract class Task
    {
        private IList<string> _data;

        protected Task(IList<string> data)
        {
            _data = data;
        }

        public abstract void Run();

        protected IEnumerable<BoardingPass> ParseBoardingPasses()
        {
            return _data.Select(ParseBoardingPass);
        }

        private BoardingPass ParseBoardingPass(string data)
        {
            var rowData = data.Substring(0, 7).Select(c => c == 'F').ToArray();
            var columnData = data.Substring(7, 3).Select(c => c == 'L').ToArray();

            var row = ParseNumber(rowData);
            var column = ParseNumber(columnData);

            return new BoardingPass(row, column);
        }

        private int ParseNumber(IList<bool> input)
        {
            // 0: lower half, 1: upper half
            var minVal = 0;
            var range = (int)Math.Pow(2, input.Count);
            var maxVal = range - 1;
            
            foreach (var isLower in input)
            {
                range /= 2;

                if (isLower)
                {
                    maxVal -= range;
                }
                else // isHigher
                {
                    minVal += range;
                }
            }

            if (minVal != maxVal)
            {
                throw new InvalidOperationException($"{nameof(minVal)} ({minVal}) should match {nameof(maxVal)} ({maxVal})");
            }

            return minVal;
        }
    }
}
