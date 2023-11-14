using PizzaOrderingApp.Entities;
using PizzaOrderingApp.MenuHandler;

namespace PizzaOrderingApp.Application_logic.MenuHandler
{


	public class DisplayMenus : Menu
	{
		
		public readonly PizzaMenu? _pizzaMenu;

		//konstruktør, vil gjøre det lettere å teste
		public DisplayMenus(PizzaMenu pizzaMenu)
		{
			_pizzaMenu = pizzaMenu;
		}

		//metode som printer alle menyene fra databasen
		public override void PrintMenu()
		{

			Console.WriteLine($"\n{Divider}\nSelect a menu:\n{Divider}");
			Console.WriteLine("1. Pizza");

			int userChoice = GetMenuChoice();

			switch (userChoice)
			{
				case 1:
					_pizzaMenu.PrintMenu();
					break;
				default:
					Console.WriteLine("Invalid choice. Please try again.");
					PrintMenu();
					break;

			}
		}

			public int GetMenuChoice()
			{
				int choice;
				while (!int.TryParse (Console.ReadLine(), out choice)) //prøver å gjøre input t int
				{
					Console.WriteLine("Invalid input. Please enter a number.");
			
				}
				return choice; //returnere
		}
	}
}
