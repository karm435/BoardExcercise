using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		
		[HttpPost("createboard")]
		public void CreateBoard()
		{
			_battleshipService.CreateBoard();
		}

		[HttpPost("addshiptoboard")]
		public void AddShipToBoard()
		{
			_battleshipService.AddShipToBaord();
		}

		[HttpPost("attack")]
		public void Attack()
		{
			_battleshipService.Attack();
		}
	}
}
