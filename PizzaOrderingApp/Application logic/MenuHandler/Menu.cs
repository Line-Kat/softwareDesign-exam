namespace PizzaOrderingApp.MenuHandler {
	// Abstract base class for menus
	public abstract class Menu {

		// Visual separator for menu display
		protected string Divider = "~~~~~~~~~~~~~~~~~~~~~~";

		// Abstract method that must be implemented to print the menu in derived classes
		public abstract void PrintMenu();


	}
}
