using Tamagochi.Models;

namespace Tamagochi.Controllers
{
    public class PokedexController : PokemonController
    {
        private List<Pokemon> _pokemons = new List<Pokemon>();
        private Pokemon _pokemon = new Pokemon();

        public void PutPokedex(int codPokemon)
        {
            _pokemon = new Pokemon();
            var response = GetPokemonApi(codPokemon).Result;
        
            if (response != null)
            {
                var exists = _pokemons.Any(item => item.Id == response.Id);

                if (!exists)
                {
                    AtualizarPropriedades(response);
                    _pokemons.Add(_pokemon);
                } 
            }
        }

        public string GetPokedex()
        {
            try
            {
                string retorno = "\n---------------------------------------- Pokedex ----------------------------------------\n";

                if (_pokemons.Count > 0)
                {
                    string textPokemon = (_pokemons.Count > 1) ? "Pokemons" : "Pokemon";

                    retorno += $"\nVocê tem {_pokemons.Count} {textPokemon}:\n";

                    for (int i = 0; i < _pokemons.Count; i++)
                    {
                        retorno += $"\n{i + 1} - {_pokemons[i].Nome}";
                    }

                    retorno += $"\n\nEscolha um para interagir:\n";
                }
                else
                {
                    retorno += "\nVocê não adotou nenhum Pokemon até o momento!\n\n";
                    retorno += $"     ▄████████████████▄      \n";
                    retorno += $"     █                █      \n";
                    retorno += $"     █     █    █     █      \n";
                    retorno += $"     █    ▀      ▀    █      \n";
                    retorno += $"     █   ▀        ▀   █      \n";
                    retorno += $"     █                █      \n";
                    retorno += $"     █    ▄▀▀▀▀▀▀▄    █      \n";
                    retorno += $"     █   ▀        ▀   █      \n";
                    retorno += $"     █                █      \n";
                    retorno += $"     ▀████████████████▀      \n";
                }

                return retorno.ToUpper();
            }
            catch (ArgumentOutOfRangeException)
            {
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao consultar a Pokedex - Erro: {ex.Message}");
            }
        }

        public bool TryPokedex()
        {
            if (_pokemons.Count > 0) return true; else return false;
        }

        public Pokemon GetPokemonNaPokedex(int posicaoPokemon)
        {
            try
            {
                posicaoPokemon--;
                _pokemon = _pokemons[posicaoPokemon];
                return _pokemon;
            }
            catch (ArgumentOutOfRangeException)
            {                
                return new Pokemon();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao consultar o Pokémon na Pokedex - Erro: {ex.Message}");
            }
        }

        public void AtualizarPropriedades(Pokemon pokemonDetails)
        {
            _pokemon.Id = pokemonDetails.Id;
            _pokemon.Nome = pokemonDetails.Nome;
            _pokemon.Altura = pokemonDetails.Altura;
            _pokemon.Peso = pokemonDetails.Peso;
            _pokemon.Habilidades = pokemonDetails.Habilidades.Select(a => new Abilities { Habilidade = a.Habilidade }).ToList();
        }

        public void Alimentar(int codPokemon)
        {
            _pokemon.Status.Alimentacao = Math.Min(_pokemon.Status.Alimentacao + 2, 10);
            _pokemon.Status.Energia = Math.Max(_pokemon.Status.Energia - 1, 0);
            
            Console.WriteLine("☕︎ - Pokémon Alimentado!!! (˶ˆᗜˆ˵)");
        }

        public void Brincar(int codPokemon)
        {
            _pokemon.Status.Humor = Math.Min(_pokemon.Status.Humor + 3, 10);
            _pokemon.Status.Energia = Math.Max(_pokemon.Status.Energia - 2, 0);
            _pokemon.Status.Alimentacao = Math.Max(_pokemon.Status.Alimentacao - 1, 0);

            Console.WriteLine("❤ - Pokémon se divertiu bastante ⸜( ˆᵕˆ )⸝ ❀");
        }

        public void Descansar(int codPokemon)
        {
            _pokemon.Status.Energia = Math.Min(_pokemon.Status.Energia + 4, 10);
            _pokemon.Status.Humor = Math.Max(_pokemon.Status.Humor - 1, 0);

            Console.WriteLine("✴︎ - Pokémon dormiu bastante (ᴗ͈ ˬ ᴗ͈)ᶻᶻᶻ");
        }

        public void DarCarinho(int codPokemon)
        {
            _pokemon.Status.Humor = Math.Min(_pokemon.Status.Humor + 2, 10);
            _pokemon.Status.Saude = Math.Min(_pokemon.Status.Saude + 1, 10);

            Console.WriteLine("❤ - Pokémon está se sentindo amado! ପ(๑•ᴗ•๑)ଓ ");
        }

        public void MostrarStatus(int codPokemon)
        {
            Console.WriteLine($"Status do Pokémon: ");
            Console.WriteLine($"Alimentação: {_pokemon.Status.Alimentacao}");
            Console.WriteLine($"Humor: {_pokemon.Status.Humor}");
            Console.WriteLine($"Energia: {_pokemon.Status.Energia}");
            Console.WriteLine($"Saúde: {_pokemon.Status.Saude}");
        }
    }
}
