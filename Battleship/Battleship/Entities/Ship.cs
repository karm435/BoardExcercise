using System.Collections.Generic;
using System.Linq;

namespace Battleship.Entities
{
    public class Ship
    {
        public int Width { get; set; }
        public int Hits { get; set; }
        public Orientation OrientationType { get; set; }

        public List<Point> ShipPointsOnBoard { get; set; }
        
        public bool HasSunk => Hits >= Width;

        public bool IsAt(int row, int column)
        {
            return ShipPointsOnBoard.Any(p => p.Row == row && p.Column == column);
        }
    }

    public enum Orientation
    {
        Horizontal,
        Vertical
    }
}