using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleship.Dtos;
using Battleship.Entities;

namespace Battleship.Services
{
	public class BattleshipService : IBattleshipService
	{
		
		public void SetupBoard()
		{
			// Board size 10x10
			
			// Setup process and add random ships to the board
			
			// Verify if board is created

			// Check if there is already a ship at that location

			// check if the ship is going out of the board

			// add the ship
		}

		public async Task<AttackResponseDto> Attack(Point atPoint)
		{
			return new AttackResponseDto()
			{
				isHit = true,
				AtPoint = atPoint
			};
		}
	}
}
