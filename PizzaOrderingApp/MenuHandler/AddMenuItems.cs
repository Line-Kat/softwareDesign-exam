using PizzaOrderingApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.MenuHandler
{
	public class AddMenuItems
	{

		//Metode for å legge til pizzaer i databasen
		public void AddItems()
		{
			try
			{
				List<Pizza> pizzas = new()
				{
					new Pizza { PizzaName = "Margarita", Price = 129, Description = "Tomato sauce and cheese" },
					new Pizza { PizzaName = "Pepperoni", Price = 149, Description = "Tomato sauce, cheese and pepperoni" }
				};

				using (PizzaOrderingDbContext db = new PizzaOrderingDbContext())
				{
					db.AddRange(pizzas);
					db.SaveChanges();
				}

				Console.WriteLine("(Pizzas added to the database successfully.)");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error while adding pizzas to the database:");
				Console.WriteLine(ex.Message);
			}
		}
	}
}


