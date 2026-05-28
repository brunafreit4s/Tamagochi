using Tamagochi.Controllers;

namespace Tamagochi.Views
{
    public class TamagotchiView
    {
        public void Start()
        {
            TamagotchiController tamagochiController = new TamagotchiController();

            Console.WriteLine(tamagochiController.Titulo + "\n\n\nQual seu nome?\n");

            tamagochiController.NomeUsuario = Console.ReadLine() ?? string.Empty;

            tamagochiController.GetMenuPrincipal();
            tamagochiController.GetStart();
        }
    }
}
