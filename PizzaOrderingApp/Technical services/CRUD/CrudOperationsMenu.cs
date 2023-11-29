using PizzaOrderingApp.Entities;

namespace PizzaOrderingApp.Technical_services.CRUD {
	// Handles database operations related to pizza menus
	public class CrudOperationsMenu {
		// Retrieves all pizzas from the database
		public List<Pizza> GetAllPizzas() {
			using PizzaOrderingDbContext db = new PizzaOrderingDbContext();
			return db.Pizza.ToList();
		}

		// Finds a single pizza by its identifier
		public Pizza GetPizzaById(int pizzaId) {
			using PizzaOrderingDbContext db = new PizzaOrderingDbContext();
			return db.Pizza.FirstOrDefault(p => p.PizzaId == pizzaId);
		}

		// Adds a list of new pizzas to the database if they don't already exist
		public void AddPizzas(List<Pizza> pizzas) {
			using PizzaOrderingDbContext db = new PizzaOrderingDbContext();
			foreach (Pizza pizza in pizzas) {
				Pizza existingPizza = db.Pizza.FirstOrDefault(p => p.PizzaName == pizza.PizzaName);
				if (existingPizza == null) {
					db.Pizza.Add(pizza);
				}
			}
			db.SaveChanges();
		}

		// Retrieves a list of unique toppings available across all pizzas
		public List<string> GetAvailablePizzaToppings() {
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
