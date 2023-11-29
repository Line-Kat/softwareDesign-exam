namespace PizzaOrderingApp.Application_logic.Decorators {

	// IPizza interface defines the structure for a Pizza object
	public interface IPizza {
		int PizzaId { get; }
		string PizzaName { get; }
		int Price { get; }
		string Description { get; }
	}

}
