using Battleship.Entities;

namespace Battleship.Dtos
{
    public class AttackResponseDto
    {
        public AttackResult Result { get; set; }

        public Point AtPoint { get; set; }
    }
}