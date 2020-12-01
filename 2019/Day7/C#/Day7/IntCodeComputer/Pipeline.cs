using System;
using System.Collections.Generic;
using System.IO;

namespace chancies.adventofcode
{
    internal class Pipeline
        : IDisposable
    {
        private readonly Queue<int> _buffer;

        internal Pipeline()
        {
            _buffer = new Queue<int>();
        }

        public bool CanRead => _buffer.Count > 0;

        public void Write(int data)
        {
            _buffer.Enqueue(data);
        }

        public int Read()
        {
            if (!CanRead)
            {
                throw new IOException("No data to read");
            }

            return _buffer.Dequeue();
        }

        public void Dispose()
        {
        }
    }
}
