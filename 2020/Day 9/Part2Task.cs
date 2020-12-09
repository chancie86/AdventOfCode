namespace Day_9
{
    public class Part2Task
        : Task
    {
        public Part2Task(long[] data) : base(data)
        {
        }

        public override void Run()
        {
            var decryptor = new XmasDecryptor(Data);
            var number = decryptor.FindFirstValue();
            decryptor.FindEncryptionWeakness(number);
            Result = decryptor.Smallest + decryptor.Largest;
        }
    }
}
