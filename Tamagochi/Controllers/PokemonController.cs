using System.Text.Json;
using Tamagochi.Models;

namespace Tamagochi.Controllers
{
    public class PokemonController
    {
        public async Task<PokemonResponse> GetListPokemon()
        {
            try
            {
                string url = "https://pokeapi.co/api/v2/pokemon/?limit=50";

                using (HttpClient client = new HttpClient())
                {
                    PokemonResponse pokemon = new PokemonResponse();

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            pokemon = JsonSerializer.Deserialize<PokemonResponse>(content) ?? new PokemonResponse();

                            return pokemon;
                        }
                        else
                        {
                            pokemon.StatusCode = 404;
                            pokemon.MessageError = "Lista do menu não encontrada!";
                            return pokemon;
                        }
                    }
                    catch (Exception ex)
                    {
                        pokemon.StatusCode = 500;
                        pokemon.MessageError = $"Ocorreu um erro no servidor - Erro: {ex.Message}";
                        return pokemon;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao consultar a lista de Pokemons - Erro: {ex.Message}");
            }
        }

        public async Task<Pokemon> GetPokemonApi(int opcao)
        {
            try
            {
                string url = $"https://pokeapi.co/api/v2/pokemon/{opcao}/";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    string content = await response.Content.ReadAsStringAsync();
                    Pokemon pokedex = JsonSerializer.Deserialize<Pokemon>(content) ?? new Pokemon();

                    return pokedex;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao consultar o Pokémon - Erro: {ex.Message}");
            }
        }

        public void GetSobrePokemon(int codPokemon)
        {
            Task<Pokemon> pokedex = GetPokemonApi(codPokemon);

            string escolhido = $"\nNome do Pokémon: {pokedex.Result.Nome}," +
                                           $"\nAltura: {pokedex.Result.Altura}," +
                                           $"\nPeso: {pokedex.Result.Peso}," +
                                           $"\nHabilidades:\n";

            if(pokedex.Result.Habilidades != null)
            {
                foreach (var item in pokedex.Result.Habilidades)
                {
                    escolhido += " - " + item.Habilidade.Nome + "\n";
                }
            }
            else
            {
                escolhido += " - Não tem habilidade\n";
            }

            Console.Write(escolhido.ToUpper());
        }
        
    }
}
