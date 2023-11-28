using PizzaOrderingApp.Entities;
using PizzaOrderingApp.Technical_services.CRUD;

namespace PizzaOrderingApp.MenuHandler
{
	public class AddMenuItems
	{
		CrudOperationsMenu crudOperationsMenu = new CrudOperationsMenu();

		//Method to add pizzas to the database
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

					crudOperationsMenu.AddPizzas(pizzas);

				// Can uncomment this to see if items are added to database
				//	Console.WriteLine("(Pizzas added to the database successfully.)");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error while adding pizzas to the database:");
				Console.WriteLine(ex.Message);
			}
		}
	}

}


