using System.Threading.Tasks;
using Battleship.Dtos;
using Battleship.Entities;

namespace Battleship.Services
{
    public interface IBattleshipService
    {
        void SetupBoard();
      
        Task<AttackResponseDto> Attack(int row, int column);
    }
}