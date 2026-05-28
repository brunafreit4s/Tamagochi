using System.Text.Json.Serialization;

namespace Tamagochi.Models
{
    public class Pokemon
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Nome { get; set; } = string.Empty;

        [JsonPropertyName("abilities")]
        public List<Abilities> Habilidades { get; set; } = new List<Abilities>();

        [JsonPropertyName("height")]
        public int Altura { get; set; }

        [JsonPropertyName("weight")]
        public int Peso { get; set; }

        public FisicState Status { get; set; } = new FisicState();
    }

    public class PokemonResult
    {
        [JsonPropertyName("name")]
        public string? Nome { get; set; }
    }

    public class PokemonResponse
    {
        [JsonPropertyName("results")]
        public List<PokemonResult>? Results { get; set; } = new List<PokemonResult>();

        public int StatusCode { get; set; }
        public string? MessageError { get; set; }
    }
}
