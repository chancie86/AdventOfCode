namespace Day_9
{
    public class Part1Task
        : Task
    {
        public Part1Task(long[] data) : base(data)
        {
        }

        public override void Run()
        {
            var decryptor = new XmasDecryptor(Data);
            Result = decryptor.FindFirstValue();
        }
    }
}
