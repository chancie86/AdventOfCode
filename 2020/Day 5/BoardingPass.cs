namespace Day5
{
    public class BoardingPass
    {
        private int? _id;

        public BoardingPass(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }
        public int Id => _id ??= (Row * 8) + Column;
    }
}
