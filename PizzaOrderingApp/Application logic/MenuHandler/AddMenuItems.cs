using PizzaOrderingApp.Entities;
using PizzaOrderingApp.Technical_services.CRUD;
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
		//crud
		CrudOperationsMenu crudOperationsMenu = new CrudOperationsMenu();

		//Metode for å legge til pizzaer i databasen
		public void AddItems()
		{
			try
			{
					List<Pizza> pizzas = new List<Pizza>
				{
					new Pizza { PizzaName = "Margarita", Price = 99, Description = "Tomato sauce, cheese" },
					new Pizza { PizzaName = "Pepperoni", Price = 149, Description = "Tomato sauce, cheese, pepperoni" },
					new Pizza { PizzaName = "Vegan deluxe", Price = 129, Description = "Tomato sauce, vegan cheese, peppers, olives"},
					new Pizza { PizzaName = "Hawaiian dream", Price = 149, Description = "Tomato sauce, cheese, pianpple, ham"}
				};

					//crud
					crudOperationsMenu.AddPizzas(pizzas);

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


