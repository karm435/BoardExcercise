namespace Battleship.Entities
{
    public class Point
    {
        public bool IsOccupied { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public Point(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}