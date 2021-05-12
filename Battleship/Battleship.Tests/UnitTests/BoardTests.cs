using System.Collections.Generic;
using System.Linq;
using Battleship.Entities;
using Xunit;

namespace Battleship.Tests.UnitTests
{
    public class BattleshipServiceTests
    {
        [Fact]
        public void ShouldReportAHit()
        {
            // Arrange
            var board = new Board();
            var boardPoint = board.BoardPoints.First(x => x.Row == 1 && x.Column == 1);
            boardPoint.IsOccupied = true;
            var ship = new Ship();
            ship.ShipPointsOnBoard = new List<Point>
            {
                boardPoint
            };
            board.ShipsOnBoard.Add(ship);
            
            // Act
            var result = board.TakeAnAttack(1, 1);
            
            Assert.Equal(AttackResult.Hit, result);
        }

        [Fact]
        void ShouldReportAMiss()
        {
            // Arrange
            var board = new Board();
            var boardPoint = board.BoardPoints.First(x => x.Row == 1 && x.Column == 1);
            boardPoint.IsOccupied = true;
            var ship = new Ship();
            ship.ShipPointsOnBoard = new List<Point>
            {
                boardPoint
            };
            board.ShipsOnBoard.Add(ship);
            
            // Act
            var result = board.TakeAnAttack(2, 2);
            
            Assert.Equal(AttackResult.Miss, result);
        }
    }
}