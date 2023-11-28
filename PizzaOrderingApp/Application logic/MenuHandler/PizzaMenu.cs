using PizzaOrderingApp.Technical_services.CRUD;
using PizzaOrderingApp.Application_logic.MenuHandler.Decorators;
using PizzaOrderingApp.MenuHandler;
using PizzaOrderingApp.Application_logic.Decorators;

namespace PizzaOrderingApp.Entities
{
	public class PizzaMenu : Menu
	{
		private IPizza selectedPizza; // Egenskap for å holde på den valgte pizzaen

		// Relasjon til koblingstabellen
		public ICollection<Pizza_Order>? Pizza_Order { get; set; }
		// CRUD
		CrudOperationsMenu crudOperationsMenu = new CrudOperationsMenu();

		public IPizza GetSelectedPizza()
		{
			return selectedPizza;
		}

		public override void PrintMenu()
		{
			Console.WriteLine($"\n{Divider}\nHere is the pizza menu:\n{Divider}");

			try
			{
				List<Pizza> pizzas = crudOperationsMenu.GetAllPizzas(); // Explicit type instead of var

				if (pizzas.Any())
				{
					foreach (Pizza pizza in pizzas) // Explicit type instead of var
					{
						Console.WriteLine($"Nr. {pizza.PizzaId}. {pizza.PizzaName} {pizza.Price}kr");
						Console.WriteLine($"Description: {pizza.Description} \n");
					}

					Console.WriteLine("Please enter the number of the pizza you want to select:");
					if (int.TryParse(Console.ReadLine(), out int pizzaId))
					{
						Pizza tempSelectedPizza = crudOperationsMenu.GetPizzaById(pizzaId); // Explicit type instead of var

						if (tempSelectedPizza != null)
						{
							this.selectedPizza = tempSelectedPizza; // Updating selected pizza

							PizzaToppingSelectionHandler toppingHandler = new PizzaToppingSelectionHandler(); // Explicit type instead of var
							toppingHandler.HandleToppingSelection(this.selectedPizza);
							// Here you can also handle the decorated pizza if necessary
						}
						else
						{
							Console.WriteLine("\nInvalid pizza number, please try again.");
							PrintMenu();
						}
					}
					else
					{
						Console.WriteLine("\nPlease enter a number.");
						PrintMenu();
					}
				}
				else
				{
					Console.WriteLine("There is nothing in this menu, sorry!");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error, could not fetch the pizza menu");
				Console.WriteLine(ex.Message);
			}
		}
	}
}