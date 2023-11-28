using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.MenuHandler;

namespace PizzaOrderingApp.Application_logic.MenuHandler
{

	//Class to display all the menus
	public class DisplayMenus : Menu
	{
		private readonly List<Menu> _menus; //store the menus
		private IPizza SelectedPizza;

		public DisplayMenus()
		{
			_menus = new List<Menu> {
				new PizzaMenu() 
                // Add more menus here
            };
		}

		public IPizza GetSelectedPizza()
		{
			return SelectedPizza; 
		}

		public override void PrintMenu()
		{
			Console.WriteLine($"\n{Divider}\nSelect a menu:\n{Divider}");
			for (int i = 0; i < _menus.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {_menus[i].GetType().Name}");
			}

			int userChoice = GetMenuChoice();
			if (userChoice > 0 && userChoice <= _menus.Count)
			{
				
				Menu chosenMenu = _menus[userChoice - 1];
				chosenMenu.PrintMenu();
				if (chosenMenu is PizzaMenu)
				{
					SelectedPizza = ((PizzaMenu) chosenMenu).GetSelectedPizza();
				}
			}
			else
			{
				Console.WriteLine("\nInvalid input, please try again!");
				PrintMenu();
			}
		}

		private int GetMenuChoice()
		{
			int choice;
			while (!int.TryParse(Console.ReadLine(), out choice))
			{
				Console.WriteLine("Please enter a number from the list.");
			}
			return choice;
		}
	}
}
