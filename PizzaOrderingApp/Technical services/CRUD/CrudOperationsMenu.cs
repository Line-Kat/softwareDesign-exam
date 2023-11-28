using PizzaOrderingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaOrderingApp.Technical_services.CRUD
{
	public class CrudOperationsMenu
	{
		public List<Pizza> GetAllPizzas()
		{
			using PizzaOrderingDbContext db = new PizzaOrderingDbContext();
			return db.Pizza.ToList();
		}

		public Pizza GetPizzaById(int pizzaId)
		{
			using PizzaOrderingDbContext db = new PizzaOrderingDbContext();
			return db.Pizza.FirstOrDefault(p => p.PizzaId == pizzaId);
		}

		public void AddPizzas(List<Pizza> pizzas)
		{
			using PizzaOrderingDbContext db = new PizzaOrderingDbContext();
			foreach (Pizza pizza in pizzas)
			{
				Pizza existingPizza = db.Pizza.FirstOrDefault(p => p.PizzaName == pizza.PizzaName);
				if (existingPizza == null)
				{
					db.Pizza.Add(pizza);
				}
			}
			db.SaveChanges();
		}

		// To print out toppings
		public List<string> GetAvailablePizzaToppings()
		{
			using PizzaOrderingDbContext db = new PizzaOrderingDbContext();
			List<string> pizzaDescriptions = db.Pizza.Select(p => p.Description).ToList();
			List<string> allToppings = pizzaDescriptions
				.SelectMany(description => description.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				.Distinct()
				.Select(topping => topping.Trim())
				.ToList();
			return allToppings;
		}
	}
}
