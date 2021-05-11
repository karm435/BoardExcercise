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

		[Fact]
		public async void ShouldReportAHit()
		{
			//Arrange
			var client = _factory.CreateClient();
			var atPoint = new StringContent(JsonSerializer.Serialize(new Point(2, 3)));
			//Act
			var response = await client.PostAsync("battleship/attack", atPoint);
			//Assert
			response.EnsureSuccessStatusCode();
			var responseString = await response.Content.ReadAsStringAsync();
			var attackResponse = JsonConvert.DeserializeObject<AttackResponseDto>(responseString);
			Assert.True(attackResponse.isHit);
		}
		
		[Fact]
		public async void ShouldReportAMiss()
		{
			//Arrange
			var client = _factory.CreateClient();
			var atPoint = new StringContent(JsonSerializer.Serialize(new Point(1, 1)));
			//Act
			var response = await client.PostAsync("battleship/attack", atPoint);
			//Assert
			response.EnsureSuccessStatusCode();
			var responseString = await response.Content.ReadAsStringAsync();
			var attackResponse = JsonConvert.DeserializeObject<AttackResponseDto>(responseString);
			Assert.False(attackResponse.isHit);
		}
	}
}
