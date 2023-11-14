using PizzaOrderingApp.Application_logic.Decorators;


namespace PizzaOrderingApp.Entities {
	public class Pizza : IPizza {
		public int PizzaId { get; set; }
		public string PizzaName { get; set; } = string.Empty;
		public int Price { get; set; }
		public string Description { get; set; } = string.Empty;

		//relasjon til koblingstabellen
		public ICollection<Pizza_Order>? Pizza_Order { get; set; }
	}
}
