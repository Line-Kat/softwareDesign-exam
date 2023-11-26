using PizzaOrderingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Technical_services.CRUD
{
	public class CrudOperationsMenu
	{

		public List<Pizza> GetAllPizzas()
		{
			using PizzaOrderingDbContext db = new();
			return db.Pizza.ToList();
		}

		public Pizza GetPizzaById(int pizzaId)
		{
			using var db = new PizzaOrderingDbContext();
			return db.Pizza.FirstOrDefault(p => p.PizzaId == pizzaId);
		}

		public void AddPizzas(List<Pizza> pizzas)
		{
			using var db = new PizzaOrderingDbContext();
			foreach (var pizza in pizzas)
			{
				var existingPizza = db.Pizza.FirstOrDefault(p => p.PizzaName == pizza.PizzaName);
				if (existingPizza == null)
				{
					db.Pizza.Add(pizza);
				}
			}
			db.SaveChanges();
		}


		// For å printe ut toppings

		public List<string> GetAvailablePizzaToppings()
		{
			using var db = new PizzaOrderingDbContext();
			var pizzaDescriptions = db.Pizza.Select(p => p.Description).ToList();
			var allToppings = pizzaDescriptions
				.SelectMany(description => description.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				.Distinct()
				.Select(topping => topping.Trim())
				.ToList();
			return allToppings;
		}

		/*	public void UpdatePizza(Pizza pizza)
			{
				using var db = new PizzaOrderingDbContext();
				db.Pizza.Update(pizza);
				db.SaveChanges();
			}

			public void DeletePizza(int pizzaId)
			{
				using var db = new PizzaOrderingDbContext();
				var pizza = db.Pizza.Find(pizzaId);
				if (pizza != null)
				{
					db.Pizza.Remove(pizza);
					db.SaveChanges();
				}
			} */


	}
}
