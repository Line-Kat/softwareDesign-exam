using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Application_logic.MenuHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Application_logic.MenuHandler.Decorators
{
	public class PizzaToppingSelectionHandler
	{
		private readonly Dictionary<string, int> _toppingPrices = new Dictionary<string, int>();
		private const int MaxToppings = 3;

		public PizzaToppingSelectionHandler()
		{
			LoadToppingsFromDatabase();
		}

		private void LoadToppingsFromDatabase()
		{
			using (var db = new PizzaOrderingDbContext())
			{
				// Hente Descrition fra Pizza tabellen
				var pizzaDescriptions = db.Pizza.Select(p => p.Description).ToList();

				var allToppings = pizzaDescriptions
					.SelectMany(description => description.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
					.Distinct()
					.Select(topping => topping.Trim())
					.ToList();


				foreach (var topping in allToppings)
				{
					// 10kr pr lagt t topping
					_toppingPrices[topping] = 10; 
				}
			}
		}

		public IPizza HandleToppingSelection(IPizza pizza)
		{
			Console.WriteLine("Do you want to add extra toppings? (y/n)");
			string response = Console.ReadLine().ToLower();
			int toppingsCount = 0;

			while (response == "y" && toppingsCount < MaxToppings)
			{
				Console.WriteLine("Available toppings:");
				foreach (var topping in _toppingPrices.Keys)
				{
					Console.WriteLine(topping);
				}

				Console.WriteLine("Which topping do you want to add:");
				string toppingChoice = Console.ReadLine();

				if (_toppingPrices.ContainsKey(toppingChoice))
				{
					var decorator = new PizzaToppingDecorator(pizza, _toppingPrices);
					decorator.AddTopping(toppingChoice);
					pizza = decorator;

					toppingsCount++;
					if (toppingsCount < MaxToppings)
					{
						Console.WriteLine("Do you want to add another topping? (yes/no)");
						response = Console.ReadLine().ToLower();
					}
				}
				else
				{
					Console.WriteLine($"Topping '{toppingChoice}' is not available, sry!");
				}
			}

			return pizza;
		}
	}


}
