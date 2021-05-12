using System.Text.Json.Serialization;
using Battleship.Entities;

namespace Battleship.Dtos
{
    public class AttackResponseDto
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AttackResult Result { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }
    }
}