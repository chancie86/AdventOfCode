namespace Day5
{
    public class Map
    {
        private readonly IList<Range> _ranges;
        private long _smallestIndex = long.MaxValue;
        private long _largestIndex = 0;

        public Map()
        {
            _ranges = new List<Range>();
        }

        public void Add(long destinationRangeStart, long sourceRangeStart, long rangeLength)
        {
            _ranges.Add(new Range(destinationRangeStart, sourceRangeStart, rangeLength));

            if (sourceRangeStart + rangeLength > _largestIndex)
            {
                _largestIndex = destinationRangeStart + rangeLength;
            }

            if (sourceRangeStart < _smallestIndex)
            {
                _smallestIndex = sourceRangeStart;
            }
        }

        public long GetDestination(long index)
        {
            if (index < _smallestIndex
                || index > _largestIndex)
            {
                return index;
            }

            foreach (var range in _ranges)
            {
                if (range.IsInSourceRange(index))
                {
                    return range.GetDestinationValue(index);
                }
            }

            return index;
        }
        
        private class Range
        {
            private readonly long _destinationRangeStart;
            private readonly long _sourceRangeStart;
            private readonly long _sourceRangeEnd;
            private readonly long _rangeLength;

            public Range(long destinationRangeStart, long sourceRangeStart, long rangeLength)
            {
                _destinationRangeStart = destinationRangeStart;
                _sourceRangeStart = sourceRangeStart;
                _sourceRangeEnd = sourceRangeStart + rangeLength;
                _rangeLength = rangeLength;
            }
            
            public long GetDestinationValue(long index)
            {
                var diff = index - _sourceRangeStart;
                return _destinationRangeStart + diff;
            }
            
            public bool IsInSourceRange(long index)
            {
                if (index < _sourceRangeStart
                    || index >= _sourceRangeEnd)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
