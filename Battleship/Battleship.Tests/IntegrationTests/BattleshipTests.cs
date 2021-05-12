using System;
using System.Drawing;
using System.Net.Http;
using Battleship.Dtos;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Battleship.Tests
{
	public class BattleshipTests
		:IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public BattleshipTests(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}
		
		[Fact]
		public async void ShouldCreateABoard()
		{
			//Arrange
			var client = _factory.CreateClient();
			
			//Act
			var response = await client.PostAsync("battleship/setupboard", null);
			
			//Assert
			response.EnsureSuccessStatusCode();
		}
	}
}
