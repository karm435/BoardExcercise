using System.Collections.Generic;

namespace Battleship.Entities
{
    public class Board
    {
        public List<BoardPoint> BoardPoints { get; set; }

        public Board()
        {
            BoardPoints = new List<BoardPoint>();

            for (int row = 1; row <= 10; row++)
            {
                for (int column = 1; column <= 10; column++)
                {
                    BoardPoints.Add(new BoardPoint(row,column));
                }
            }
        }
    }

    
}