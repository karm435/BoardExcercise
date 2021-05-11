namespace Battleship.Entities
{
    public class BoardPoint
    {
        public bool IsOccupied { get; set; }

        public Point LocationOnBoard { get; set; }

        public BoardPoint(int row, int column)
        {
            IsOccupied = false;
            LocationOnBoard = new Point {Row = row, Column = column};
        }
    }
}