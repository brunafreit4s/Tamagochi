using System.Text.Json.Serialization;

namespace Tamagochi.Models
{
    public class Abilities
    {
        [JsonPropertyName("ability")]
        public Ability Habilidade { get; set; } = new Ability();
    }
}
