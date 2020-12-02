namespace Day_2
{
    public class Part2Policy
        : IPolicy
    {
        public Part2Policy(int first, int second, char character)
        {
            First = first;
            Second = second;
            Character = character;
        }

        public int First { get; }

        public int Second { get; }

        public char Character { get; }

        public bool IsValid(string password)
        {
            return (password[First - 1] == Character && password[Second - 1] != Character)
                   || ((password[First - 1] != Character && password[Second - 1] == Character));
        }
    }
}
