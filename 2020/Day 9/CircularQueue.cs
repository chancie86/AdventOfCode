using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Day_9
{
    public class CircularQueue<T>
        : IList<T>
    {
        private readonly T[] _data;
        private int? _startPointer;
        private int _endPointer;

        public CircularQueue(int size)
        {
            _endPointer = 0;
            _data = new T[size];
        }

        public int Count
        {
            get
            {
                if (!_startPointer.HasValue)
                {
                    return 0;
                }

                if (_endPointer <= _startPointer)
                {
                    return (_data.Length - _startPointer.Value) + _endPointer;
                }

                return _endPointer - _startPointer.Value;
            }
        }

        public void Enqueue(T item)
        {
            if (Count == _data.Length)
            {
                throw new IndexOutOfRangeException("Queue is full");
            }

            if (!_startPointer.HasValue)
            {
                _startPointer = 0;
            }
            
            _data[_endPointer] = item;
            _endPointer = (_endPointer + 1) % _data.Length;
        }

        public T Dequeue()
        {
            if (!_startPointer.HasValue)
            {
                throw new IndexOutOfRangeException("Queue is empty");
            }

            var result = _data[_startPointer.Value];
            _data[_startPointer.Value] = default;

            _startPointer = Count == 1 ? _startPointer = null : (_startPointer + 1) % _data.Length;
            return result;
        }

        public T this[int index]
        {
            get
            {
                if (!_startPointer.HasValue)
                {
                    throw new IndexOutOfRangeException("Queue is empty");
                }

                var relativeIndex = (_startPointer.Value + index) % _data.Length;
                return _data[relativeIndex];
            }
            set => throw new NotSupportedException();
        }

        #region Implements IList
        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            Enqueue(item);
        }

        public void Clear()
        {
            for (var i = 0; i < _data.Length; i++)
            {
                _data[i] = default;
            }

            _startPointer = _endPointer = 0;
        }

        public bool Contains(T item)
        {
            return _data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _data.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        public bool IsReadOnly => false;

        public int IndexOf(T item)
        {
            throw new NotSupportedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }
        #endregion
    }
}
