using PizzaOrderingApp.Entities;
using PizzaOrderingApp;
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
				using (PizzaOrderingDbContext db = new PizzaOrderingDbContext())
				{
					List<Pizza> pizzas = new List<Pizza>
				{
					new Pizza { PizzaName = "Margarita", Price = 129, Description = "Tomato sauce and cheese" },
					new Pizza { PizzaName = "Pepperoni", Price = 149, Description = "Tomato sauce, cheese and pepperoni" }
				};

					foreach (var pizza in pizzas)
					{
						//sjekke om pizzaen så legges til allerede finnes i db
						var existingPizza = db.Pizza.FirstOrDefault(p => p.PizzaName == pizza.PizzaName);

						if (existingPizza == null)
						{
							// Pizzaen finnes ikkje i pizza tabellen i db, den blir lagt til
							db.Pizza.Add(pizza);
						}
						else
						{
							// Pizzaen finnes allerede i db
							Console.WriteLine($"Pizza '{pizza.PizzaName}' already exists in the database.");
						}
					}
					
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


