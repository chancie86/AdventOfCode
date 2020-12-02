namespace Day_2
{
    public class Part1Policy
        : IPolicy
    {
        public Part1Policy(int min, int max, char character)
        {
            Min = min;
            Max = max;
            Character = character;
        }

        public int Min { get; }

        public int Max { get; }

        public char Character { get; }

        public bool IsValid(string password)
        {
            var count = 0;

            foreach (var c in password)
            {
                if (c == Character)
                {
                    count++;
                }
            }

            return count <= Max && count >= Min;
        }
    }
}
