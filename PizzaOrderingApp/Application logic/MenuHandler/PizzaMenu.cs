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
				var pizzas = crudOperationsMenu.GetAllPizzas();

				if (pizzas.Any())
				{
					foreach (var pizza in pizzas)
					{
						Console.WriteLine($"Nr. {pizza.PizzaId}. {pizza.PizzaName} {pizza.Price}kr");
						Console.WriteLine($"Description: {pizza.Description} \n");
					}

					Console.WriteLine("Please enter the number of the pizza you want to select:");
					if (int.TryParse(Console.ReadLine(), out int pizzaId))
					{
						var tempSelectedPizza = crudOperationsMenu.GetPizzaById(pizzaId);

						if (tempSelectedPizza != null)
						{
							this.selectedPizza = tempSelectedPizza; // Oppdaterer valgt pizza

							var toppingHandler = new PizzaToppingSelectionHandler();
							toppingHandler.HandleToppingSelection(this.selectedPizza);
							// Her kan du også håndtere den dekorerte pizzaen hvis nødvendig
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
