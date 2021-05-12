using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Battleship.Dtos;
using Battleship.Entities;

namespace Battleship.Services
{
	public class BattleshipService : IBattleshipService
	{
		private Board _board;
		
		public void SetupBoard()
		{
			_board = new Board();
			var ships = new List<Ship>
			{
				new Ship() {Width = 5, OrientationType = Orientation.Horizontal},
				new Ship() {Width = 2, OrientationType = Orientation.Vertical},
				new Ship() {Width = 4, OrientationType = Orientation.Horizontal},
				new Ship() {Width = 6, OrientationType = Orientation.Vertical},
				new Ship() {Width = 4, OrientationType = Orientation.Horizontal}
			};
			
			_board.PlaceShips(ships);
		}

		public async Task<AttackResponseDto> Attack(int row, int column)
		{
			if (_board == null)
			{
				throw new Exception("Board must be setup before attacking");
			}
			var attachResult = _board.TakeAnAttack(row, column);
			return new AttackResponseDto()
			{
				Result = attachResult,
				Row = row,
				Column = column
			};
		}
	}
}
