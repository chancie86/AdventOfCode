using System;
using System.Collections.Generic;
using System.Text;

namespace Day_11
{
    public abstract class Task
    {
        protected Task(IList<string> data)
        {
            InitialMap = new SeatMap(data);
        }

        protected SeatMap InitialMap { get; }

        public int Result { get; protected set; }

        public abstract void Run();

        public override string ToString()
        {
            return $"{Result}";
        }
    }
}
