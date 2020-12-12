using System;
using System.Collections.Generic;
using System.Text;

namespace Day_11.Rules
{
    public class OccupiedSeatRule
        : IRule
    {
        public bool Applies(SeatMap map, int x, int y, out SeatStatus? status)
        {
            if (map[x, y] == SeatStatus.Occupied
                && FourOrMoreAdjacentSeatsAreOccupied(map, x, y))
            {
                status = SeatStatus.Empty;
                return true;
            }

            status = null;
            return false;
        }

        private bool FourOrMoreAdjacentSeatsAreOccupied(SeatMap map, int x, int y)
        {
            var count = 0;
            
            map.ForEachAdjacentSeat(x, y, status =>
            {
                if (status == SeatStatus.Occupied)
                {
                    count++;
                }

                return true;
            });

            return count >= 4;
        }
    }
}
