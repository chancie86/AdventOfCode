namespace Day3
{
    public class PartNumber
    {
        public PartNumber(int number, int startIndex, int endIndex)
        {
            Number = number;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

        public int Number { get; }
        public int StartIndex { get; }
        public int EndIndex { get; }

        public bool IsOverlapping(int index)
        {
            return index >= StartIndex && index <= EndIndex;
        }

        public static IList<PartNumber> GetPartNumbers(string line)
        {
            var result = new List<PartNumber>();
            
            for (var i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    var partNumber = ExtractNumber(line, i);
                    i = partNumber.EndIndex;

                    result.Add(partNumber);
                }
            }

            return result;
        }

        private static PartNumber ExtractNumber(string text, int startIndex)
        {
            var endIndex = startIndex + 1;

            for (endIndex = startIndex + 1; endIndex < text.Length;)
            {
                if (char.IsDigit(text[endIndex]))
                {
                    endIndex++;
                    continue;
                }

                break;
            }

            var numberText = text.Substring(startIndex, endIndex - startIndex);
            var number = int.Parse(numberText);

            return new PartNumber(number, startIndex, endIndex - 1);
        }
    }
}
