using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleship.Dtos;
using Battleship.Entities;
using Battleship.Services;

namespace Battleship.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BattleshipController : ControllerBase
	{
		private readonly IBattleshipService _battleshipService;
		
		public BattleshipController(IBattleshipService battleshipService)
		{
			_battleshipService = battleshipService;
		}
		
		[HttpPost("setupboard")]
		public void SetupBoard()
		{
			_battleshipService.SetupBoard();
		}

		[HttpPost("attack")]
		public async Task<AttackResponseDto> Attack([FromForm]Point atPoint)
		{
			return await _battleshipService.Attack(atPoint);
		}
	}
}
