namespace Day7
{
    public class Hand
        : IComparable
    {
        public Hand(string rawInput, Card[] cards, HandType type, int bid)
        {
            cards = cards ?? throw new ArgumentNullException(nameof(cards));

            if (cards.Length != 5)
            {
                throw new ArgumentException("There must be 5 cards in a hand", nameof(cards));
            }

            if (bid < 0)
            {
                throw new ArgumentException("Bid must be > 0");
            }

            RawInput = rawInput;
            Cards = cards;
            HandType = type;
            Bid = bid;
        }

        public string RawInput { get; }

        public Card[] Cards { get; }

        public int Bid { get; }

        public HandType HandType { get; }
        
        public int CompareTo(object? obj)
        {
            var other = obj as Hand;

            if (other == null)
            {
                throw new ArgumentException(nameof(other));
            }

            if (HandType.Equals(other.HandType))
            {
                var result = 0;

                for (var i = 0; i < Cards.Length; i++)
                {
                    if (!Cards[i].Equals(other.Cards[i]))
                    {
                        result = Cards[i].CompareTo(other.Cards[i]);
                        break;
                    }
                }

                //Console.WriteLine($"\tComparing {RawInput} to {other.RawInput}. Result {result}");
                return result;
            }

            var result2 = HandType.CompareTo(other.HandType);
            //Console.WriteLine($"Comparing {HandType} to {other.HandType}. Result {result2}");
            return result2;
        }
    }
}
