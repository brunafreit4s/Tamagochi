using Tamagochi.Models;

namespace Tamagochi.Controllers
{
    public class UtilController
    {
        public string FormataOpcoes(Task<PokemonResponse> pokemon)
        {
            int count = 1;
            string menu = "";

            foreach (var item in pokemon.Result.Results ?? new List<PokemonResult>())
            {
                menu += $"{count} - " + item.Nome + "\n";
                count++;
            }

            return menu.ToUpper();
        }

        public void RetornaOpcaoInvalida()
        {
            Console.WriteLine("\nEscolha inválida. Tente novamente.");
        }
    }
}
