namespace Day2
{
    public class Game
    {
        public Game(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public IList<Reveal> Reveals { get; } = new List<Reveal>();
    }
}
