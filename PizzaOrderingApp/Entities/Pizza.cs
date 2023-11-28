using PizzaOrderingApp.Application_logic.Decorators;


namespace PizzaOrderingApp.Entities {

	// Represents a pizza with properties conforming to the IPizza interface.
	public class Pizza : IPizza {
		public int PizzaId { get; set; }
		public string PizzaName { get; set; } = string.Empty;
		public int Price { get; set; }
		public string Description { get; set; } = string.Empty;

	}
}
