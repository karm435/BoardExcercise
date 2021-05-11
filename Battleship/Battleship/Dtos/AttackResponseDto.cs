using Battleship.Entities;

namespace Battleship.Dtos
{
    public class AttackResponseDto
    {
        public bool isHit { get; set; }

        public Point AtPoint { get; set; }
    }
}