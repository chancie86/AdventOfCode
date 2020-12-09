using System;
using System.Collections.Generic;
using System.Text;

namespace Day_9
{
    public abstract class Task
    {
        protected Task(long[] data)
        {
            Data = data;
        }

        protected long[] Data { get; }

        public long Result { get; protected set; }

        public abstract void Run();

        public override string ToString()
        {
            return Result.ToString();
        }
    }
}
