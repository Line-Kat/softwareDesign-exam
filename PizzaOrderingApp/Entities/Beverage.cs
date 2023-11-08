using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Entities
{
	public class Beverage : Menu
	{

		//relasjon til koblingstabellen
		public ICollection<Pizza_Order>? Pizza_Order { get; set; }


		public override void PrintMenu()
		{
			Console.WriteLine("Here is the beverage menu:");

			using (var db = new PizzaOrderingDbContext())
			{
				var beverages = db.Beverage.ToList();

				if (beverages.Any())
				{
					foreach (var beverage in beverages)
					{
						Console.WriteLine($"Nr. {beverage.Id}");
						Console.WriteLine($"Name: {beverage.Name}, {beverage.Price}kr");
						Console.WriteLine($"Description: {beverage.Description}");
					}
				}
				else
				{
					Console.WriteLine("There is nothing in this menu, sorry!");
				}
			}

		}
	}
}
