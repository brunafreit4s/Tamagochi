using Tamagochi.Models;

namespace Tamagochi.Controllers
{
    public class MenuController : PokedexController
    {
        public string NomeUsuario = "";

        public void GetMenuPrincipal()
        {
            string retorno = "\n---------------------------------------- Menu ----------------------------------------\n";
            retorno += $"{NomeUsuario} você deseja:\n";
            retorno += "1 - Adotar um mascote virtual.\n2 - Ver seus mascotes.\n3 - Sair.\n";
            Console.WriteLine(retorno.ToUpper());
        }        

        public void GetMenuInteracao(int codPokemon)
        {
            var response = GetPokemonApi(codPokemon);
            string retorno = "\n-------------------- -------------------- -------------------- --------------------\n";
            retorno += $"{NomeUsuario} você deseja:\n";
            retorno += $"1 - Saber mais sobre {response.Result.Nome}.\n2 - Adotar {response.Result.Nome}.\n3 - Voltar.\n\n";

            Console.WriteLine(retorno.ToUpper());
        }

        public void GetMenuAdocao()
        {
            UtilController utilController = new UtilController();
            Task<PokemonResponse> response = GetListPokemon();
            string opcoesFormatada = "\n---------------------------------------- Adotar um Mascote ----------------------------------------\n";
            opcoesFormatada += $"{NomeUsuario} escolha uma espécie:\n";
            opcoesFormatada += utilController.FormataOpcoes(response);

            Console.WriteLine(opcoesFormatada.ToUpper());
        }

        public void GetMenuSobrePokemon(int posicaoPokemon)
        {
            var response = GetPokemonNaPokedex(posicaoPokemon);

            if(!string.IsNullOrEmpty(response.Nome))
            {
                string retorno = "\n---------------------------------------- Menu ----------------------------------------\n";
                retorno += $"{NomeUsuario} você deseja:\n";
                retorno += $"1 - Saber como {response.Nome} está.\n2 - Alimentar {response.Nome}.\n3 - Brincar com {response.Nome}.\n4 - Colocar {response.Nome} para dormir.\n5 - Dar carinho no {response.Nome}.\n6 - Voltar.\n\n";
                Console.WriteLine(retorno.ToUpper());
            }           
        }
    }
}
