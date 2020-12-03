using System.Collections.Generic;

namespace Day_3
{
    public abstract class Task
    {
        private readonly Map _map;

        protected Task(IList<string> data)
        {
            _map = new Map(data);
        }

        public long Result { get; protected set; }

        public abstract void Run();

        protected int GetNumberOfTrees(int xIncrement, int yIncrement)
        {
            var count = 0;
            var x = xIncrement;

            for (int y = yIncrement; y < _map.Height; y += yIncrement)
            {
                if (_map.IsTree(x, y))
                {
                    count++;
                }

                x += xIncrement;
            }

            return count;
        }

        public override string ToString()
        {
            return $"{Result}";
        }
    }
}
