using PizzaOrderingApp.Technical_services.CRUD;
using PizzaOrderingApp.Application_logic.MenuHandler.Decorators;
using PizzaOrderingApp.MenuHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Entities
{
	public class PizzaMenu : Menu
	{
		//relasjon til koblingstabellen
		public ICollection<Pizza_Order>? Pizza_Order { get; set; }
		// crud
		CrudOperationsMenu crudOperationsMenu = new CrudOperationsMenu();


		public override void PrintMenu()
		{
			Console.WriteLine($"\n{Divider}\nHere is the pizza menu:\n{Divider}");

			//fetche listen med pizza fra db
			
				try
				{
					//crud
					var pizzas = crudOperationsMenu.GetAllPizzas();

					if (pizzas.Any())
					{

						foreach (var pizza in pizzas)
						{
							Console.WriteLine($"Nr. {pizza.PizzaId}. {pizza.PizzaName} {pizza.Price}kr");
							Console.WriteLine($"Description: {pizza.Description} \n");
						}

						// Hente brukerens valg av pizza
						if (int.TryParse(Console.ReadLine(), out int pizzaId))
						{
							//crud
							var selectedPizza = crudOperationsMenu.GetPizzaById(pizzaId);

							if (selectedPizza != null)
							{
								var toppingHandler = new PizzaToppingSelectionHandler();
								var decoratedPizza = toppingHandler.HandleToppingSelection(selectedPizza);

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
					Console.WriteLine(ex.Message); //printer ut error meldingen
				
			}
		}
	}
}
