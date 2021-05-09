namespace Battleship.Services
{
    public interface IBattleshipService
    {
        void CreateBoard();
        void AddShipToBaord();
        void Attack();
    }
}