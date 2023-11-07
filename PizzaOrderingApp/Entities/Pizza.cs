using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Entities {
	public class Pizza : Menu {
		

		//relasjon til koblingstabellen
		public ICollection<Pizza_Order>? Pizza_Order { get; set; }

		public override void PrintMenu()
		{
			Console.WriteLine("Here is the pizza menu:");

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
							Console.WriteLine($"Nr. {pizza.Id}");
							Console.WriteLine($"Name: {pizza.Name}");
							Console.WriteLine($"Price: {pizza.Price}kr"); 
							Console.WriteLine($"Description: {pizza.Description}");

						}
					}
					else
					{
						Console.WriteLine("There is nothing in this menu, sorry!");
					}
				}
				catch (Exception ex) {

					Console.WriteLine("Error, could not fetch the pizza menu");
					Console.WriteLine(ex.Message); //printer ut error meldingen
				}
				
				
			}
				
				
		}
	}
}
