using PizzaOrderingApp.Technical_services.CRUD;
using PizzaOrderingApp.Application_logic.MenuHandler.Decorators;
using PizzaOrderingApp.MenuHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
				List<Pizza> pizzas = crudOperationsMenu.GetAllPizzas(); // Assuming GetAllPizzas() returns List<Pizza>

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
						Pizza tempSelectedPizza = crudOperationsMenu.GetPizzaById(pizzaId); // Assuming GetPizzaById() returns a Pizza object

						if (tempSelectedPizza != null)
						{
							this.selectedPizza = tempSelectedPizza; // Updating selected pizza

							PizzaToppingSelectionHandler toppingHandler = new PizzaToppingSelectionHandler();
							toppingHandler.HandleToppingSelection(this.selectedPizza);
							// You can also handle the decorated pizza here if necessary
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
