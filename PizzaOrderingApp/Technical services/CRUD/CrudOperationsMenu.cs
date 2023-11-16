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

		public void AddPizza(Pizza pizza)
		{
			using var db = new PizzaOrderingDbContext();
			db.Pizza.Add(pizza);
			db.SaveChanges();
		}

		public void UpdatePizza(Pizza pizza)
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
		}

	
	}
}
