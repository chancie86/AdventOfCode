using System.Reflection.Metadata.Ecma335;

namespace Day7
{
    internal static class HandParser
    {
        public static Hand Parse(string input, Part part)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            var split = input.Split(' ');
            var handText = split[0];
            var bidText = split[1];

            if (handText.Length != 5)
            {
                throw new ArgumentException("Hand text must be exactly 5 characters", nameof(input));
            }

            var cards = new Card[5];
            var bid = int.Parse(bidText);

            for (var i = 0; i < handText.Length; i++)
            {
                var c = handText[i];
                
                cards[i] = ParseCard(c, part);
            }

            var handType = part == Part.One
                ? GetHandTypePart1(cards)
                : GetHandTypePart2(cards);

            return new Hand(input, cards, handType, bid);
        }

        private static Card ParseCard(char c, Part part)
        {
            switch (c)
            {
                case 'A':
                    return Card.Ace;
                case 'K':
                    return Card.King;
                case 'Q':
                    return Card.Queen;
                case 'J':
                    return part == Part.One ? Card.Jack : Card.Joker;
                case 'T':
                    return Card.Ten;
                case '9':
                    return Card.Nine;
                case '8':
                    return Card.Eight;
                case '7':
                    return Card.Seven;
                case '6':
                    return Card.Six;
                case '5':
                    return Card.Five;
                case '4':
                    return Card.Four;
                case '3':
                    return Card.Three;
                case '2':
                    return Card.Two;
                default:
                    throw new ArgumentException($"Invalid char {c}", nameof(c));
            }
        }
        
        private static HandType GetHandTypePart1(Card[] cards)
        {
            var cardCounts = GetCardCounts(cards);
            var foundTriple = false;
            var foundPair = false;

            foreach (var kvp in cardCounts)
            {
                switch (kvp.Value)
                {
                    case 5:
                        return HandType.FiveOfAKind;
                    case 4:
                        return HandType.FourOfAKind;
                    case 3:
                        foundTriple = true;
                        continue;
                    case 2:
                        if (foundTriple)
                        {
                            return HandType.FullHouse;
                        }

                        if (foundPair)
                        {
                            return HandType.TwoPair;
                        }

                        foundPair = true;
                        continue;
                    case 1:
                        if (foundTriple)
                        {
                            return HandType.ThreeOfAKind;
                        }

                        break;
                }

                break;
            }

            if (foundPair)
            {
                return HandType.OnePair;
            }
            
            return HandType.HighCard;
        }

        private static HandType GetHandTypePart2(Card[] cards)
        {
            var cardCounts = GetCardCounts(cards);
            var handType = GetHandTypePart1(cards);

            var numJokers = 0;

            foreach (var kvp in cardCounts)
            {
                if (kvp.Key == Card.Joker)
                {
                    numJokers = kvp.Value;
                    break;
                }
            }
            
            if (numJokers == 0)
            {
                return handType;
            }

            switch (handType)
            {
                case HandType.FourOfAKind:
                    return numJokers switch
                    {
                        1 => HandType.FiveOfAKind,
                        4 => HandType.FiveOfAKind,
                        _ => throw new Exception($"Invalid state, current hand type: {handType}, numJokers: {numJokers}")
                    };
                case HandType.FullHouse:
                    return numJokers switch
                    {
                        1 => HandType.FourOfAKind,
                        2 => HandType.FiveOfAKind,
                        3 => HandType.FiveOfAKind,
                        _ => throw new Exception($"Invalid state, current hand type: {handType}, numJokers: {numJokers}")
                    };
                case HandType.ThreeOfAKind:
                    return numJokers switch
                    {
                        1 => HandType.FourOfAKind,
                        3 => HandType.FourOfAKind,
                        _ => throw new Exception($"Invalid state, current hand type: {handType}, numJokers: {numJokers}")
                    };   
                case HandType.TwoPair:
                    return numJokers switch
                    {
                        1 => HandType.FullHouse,
                        2 => HandType.FourOfAKind,
                        _ => throw new Exception($"Invalid state, current hand type: {handType}, numJokers: {numJokers}")
                    };
                case HandType.OnePair:
                    return numJokers switch
                    {
                        1 => HandType.ThreeOfAKind,
                        2 => HandType.ThreeOfAKind,
                        _ => throw new Exception($"Invalid state, current hand type: {handType}, numJokers: {numJokers}")
                    };
                case HandType.HighCard:
                    return numJokers switch
                    {
                        1 => HandType.OnePair,
                        _ => throw new Exception($"Invalid state, current hand type: {handType}, numJokers: {numJokers}")
                    };
            }

            return handType;
        }

        private static IList<KeyValuePair<Card, int>> GetCardCounts(Card[] cards)
        {
            var counts = new Dictionary<Card, int>();

            foreach (var card in cards)
            {
                if (counts.ContainsKey(card))
                {
                    counts[card]++;
                }
                else
                {
                    counts[card] = 1;
                }
            }

            return counts.OrderByDescending(x => x.Value).ToList();
        }
    }
}
