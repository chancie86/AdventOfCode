namespace Day_11.Rules
{
    public interface IRule
    {
        bool Applies(SeatMap map, int x, int y, out SeatStatus? status);
    }
}
