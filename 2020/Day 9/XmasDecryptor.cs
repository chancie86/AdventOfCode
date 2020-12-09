using System;
using System.Collections.Generic;
using System.IO;

namespace Day_9
{
    public class XmasDecryptor
    {
        private long[] _data;

        public XmasDecryptor(long[] data)
        {
            _data = data;
        }

        public long Smallest { get; private set; }

        public long Largest { get; private set; }


        public long FindFirstValue()
        {
            const int preambleLength = 25;
            var workingSet = new CircularQueue<long>(preambleLength);

            for (var i = 0; i < _data.Length; i++)
            {
                var currentVal = _data[i];

                if (i < preambleLength)
                {
                    workingSet.Enqueue(currentVal);
                    continue;
                }

                if (!IsValid(workingSet, currentVal))
                {
                    return currentVal;
                }

                workingSet.Dequeue();
                workingSet.Enqueue(currentVal);
            }

            throw new InvalidDataException();
        }

        public void FindEncryptionWeakness(long number)
        {
            for (var i = 0; i < _data.Length - 1; i++)
            {
                for (var j = i + 1; j < _data.Length; j++)
                {
                    var span = new Span<long>(_data, i, j - i);
                    var sum = Sum(span);

                    if (sum == number)
                    {
                        var smallest = long.MaxValue;
                        var largest = long.MinValue;

                        foreach (var val in span)
                        {
                            if (val < smallest)
                            {
                                smallest = val;
                            }

                            if (val > largest)
                            {
                                largest = val;
                            }
                        }

                        Smallest = smallest;
                        Largest = largest;
                        return;
                    }
                }
            }

            throw new InvalidDataException();
        }

        private bool IsValid(CircularQueue<long> workingSet, long currentValue)
        {
            for (var i = 0; i < workingSet.Count; i++)
            {
                for (var j = i + 1; j < workingSet.Count; j++)
                {
                    if (workingSet[i] + workingSet[j] == currentValue)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static long Sum(Span<long> span)
        {
            var sum = 0l;

            foreach (var val in span)
            {
                sum += val;
            }

            return sum;
        }
    }
}
