using PizzaOrderingApp.MenuHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
namespace PizzaOrderingApp.Entities
{
	public class PizzaMenu : Menu
	{
		//relasjon til koblingstabellen
		public ICollection<Pizza_Order>? Pizza_Order { get; set; }

		public override void PrintMenu()
		{
			Console.WriteLine("Here is the pizza menu:\n");

			//fetche listen med pizza fra db
			using (var db = new PizzaOrderingDbContext())
			{
				try
				{
					var pizzas = db.Pizza.ToList();

					if (pizzas.Any())
					{
						foreach (var pizza in pizzas)
						{
							Console.WriteLine($"Nr. {pizza.PizzaId}. {pizza.PizzaName} {pizza.Price}kr");
							Console.WriteLine($"Description: {pizza.Description} \n");
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
}
