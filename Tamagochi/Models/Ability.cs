using System.Text.Json.Serialization;

namespace Tamagochi.Models
{
    public class Ability
    {
        [JsonPropertyName("name")]
        public string Nome { get; set; } = string.Empty;
    }
}
