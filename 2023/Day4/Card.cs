namespace Day4
{
    public class Card
    {
        private int? _numberOfMatches;

        public Card(int id, IReadOnlyList<int> winningNumbers, IReadOnlyList<int> cardNumbers)
        {
            Id = id;
            WinningNumbers = winningNumbers.ToHashSet();
            CardNumbers = cardNumbers;
        }

        public int Id { get; }
        public IReadOnlyCollection<int> WinningNumbers { get; }
        public IReadOnlyCollection<int> CardNumbers { get; }

        public int GetPoints()
        {
            var numberOfMatches = GetNumberOfMatches();

            if (numberOfMatches == 0)
            {
                return 0;
            }

            return (int)Math.Pow(2, numberOfMatches - 1);
        }

        public int GetNumberOfMatches()
        {
            if (!_numberOfMatches.HasValue)
            {
                var numberOfMatches = 0;

                foreach (var number in CardNumbers)
                {
                    if (WinningNumbers.Contains(number))
                    {
                        numberOfMatches++;
                    }
                }

                _numberOfMatches = numberOfMatches;
            }

            return _numberOfMatches.Value;
        }
    }
}
