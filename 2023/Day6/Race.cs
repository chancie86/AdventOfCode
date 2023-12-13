namespace Day6
{
    public class Race
    {
        public Race(long time, long recordDistance)
        {
            Time = time;
            RecordDistance = recordDistance;
        }

        public long Time { get; }
        public long RecordDistance { get; }
    }
}
