using System;
using System.Collections.Generic;
using System.Text;

namespace Day_11.Rules
{
    public class EmptySeatRule
        : IRule
    {
        public bool Applies(SeatMap map, int x, int y, out SeatStatus? status)
        {
            if (map[x, y] == SeatStatus.Empty
                && AllAdjacentSeatsAreUnoccupied(map, x, y))
            {
                status = SeatStatus.Occupied;
                return true;
            }

            status = null;
            return false;
        }

        private bool AllAdjacentSeatsAreUnoccupied(SeatMap map, int x, int y)
        {
            return map.AllAdjacentSeats(x, y, status => status != SeatStatus.Occupied);
        }
    }
}
