namespace Day4
{
    public class WordSearch
    {
        private readonly string[] _input;

        public WordSearch(string[] input)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
        }

        public char this[int x, int y] => _input[y][x];

        public int Width => _input[0].Length;
        public int Height => _input.Length;
    }
}
