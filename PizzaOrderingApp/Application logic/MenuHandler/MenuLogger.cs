using PizzaOrderingApp.Entities;
using PizzaOrderingApp.MenuHandler;

namespace PizzaOrderingApp.Application_logic.MenuHandler
{
	public class MenuLogger : Menu
	{
		private readonly Menu _menu;

		public MenuLogger(Menu menu)
		{
			_menu = menu;
		}


		public override void PrintMenu()
		{
			_menu.PrintMenu();
		}
	}
}
