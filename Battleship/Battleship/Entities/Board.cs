using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Entities
{
    public class Board
    {
        public List<Point> BoardPoints { get; set; }
        public List<Ship> ShipsOnBoard { get; set; }
        public Board()
        {
            ShipsOnBoard = new List<Ship>();
            
            BoardPoints = new List<Point>();

            for (int row = 1; row <= 10; row++)
            {
                for (int column = 1; column <= 10; column++)
                {
                    BoardPoints.Add(new Point(row, column));
                }
            }
        }

        public void PlaceShips(IEnumerable<Ship> ships)
        {
            var randomGenerator = new Random();
            
            foreach (var ship in ships)
            {
                var shipNotPlaced = true;
                while (shipNotPlaced)
                {
                    var startRow = randomGenerator.Next(1, 11);
                    var startColumn = randomGenerator.Next(1, 11);
                    var rowEnd = startRow;
                    var columnEnd = startColumn;

                    SetBoundsOfShip(ship, rowEnd, columnEnd);

                    if (rowEnd > 10 || columnEnd > 11)
                    {
                        continue;
                    }

                    // Find if there is any ship already placed at any point of the range
                    bool thereIsAShipAtThisPoint = false;
                    for (int i = 0; i < ship.Width; i++)
                    {
                        if (ship.OrientationType == Orientation.Horizontal)
                        {
                            thereIsAShipAtThisPoint =
                                BoardPoints.Any(x => x.Row == startRow + i && x.Column == startColumn && x.IsOccupied);
                            if (thereIsAShipAtThisPoint)
                            {
                                break;
                            }
                        }
                        if (ship.OrientationType == Orientation.Vertical)
                        {
                            thereIsAShipAtThisPoint =
                                BoardPoints.Any(x => x.Row == startRow && x.Column == startColumn + i && x.IsOccupied);
                            if (thereIsAShipAtThisPoint)
                            {
                                break;
                            }
                        }
                    }

                    if (thereIsAShipAtThisPoint)
                    {
                        continue;
                    }

                    // Set the ship on the board.
                    if (ship.OrientationType == Orientation.Horizontal)
                    {
                        var boardPoints = BoardPoints.Where(x => x.Row >= startRow && x.Row <= rowEnd).ToList();
                        foreach (var boardPoint in boardPoints)
                        {
                            boardPoint.IsOccupied = true;
                        }

                        ship.ShipPointsOnBoard = boardPoints;
                    }
                    else
                    {
                        var boardPoints = BoardPoints.Where(x => x.Column >= startColumn && x.Column <= columnEnd).ToList();
                        foreach (var boardPoint in boardPoints)
                        {
                            boardPoint.IsOccupied = true;
                        }

                        ship.ShipPointsOnBoard = boardPoints;
                    }
                   
                   ShipsOnBoard.Add(ship);

                   shipNotPlaced = false;
                }
            }
        }

        public AttackResult TakeAnAttack(int row, int column)
        {
            if (!ShipsOnBoard.Any(x => x.IsAt(row, column)))
            {
                return AttackResult.Miss;
            }
            var ship = ShipsOnBoard.Single(s => s.IsAt(row, column));
            ship.Hits++;
            return AttackResult.Hit;
        }
        
        private static void SetBoundsOfShip(Ship ship, int rowEnd, int columnEnd)
        {
            if (ship.OrientationType == Orientation.Horizontal)
            {
                for (int index = 0; index < ship.Width; index++)
                {
                    rowEnd++;
                }
            }
            else
            {
                for (int index = 0; index < ship.Width; index++)
                {
                    columnEnd++;
                }
            }
        }
    }

    
}