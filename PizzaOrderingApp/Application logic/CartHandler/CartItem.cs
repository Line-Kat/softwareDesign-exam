using PizzaOrderingApp.Application_logic.Decorators;

namespace PizzaOrderingApp.Application_logic.CartHandler
{
	public class CartItem
	{
		public IPizza Pizza { get; set; }
		public int Quantity { get; set; }

		// Her kan du legge til en beregning for totalpris basert på Pizza.Price og Quantity
		public int TotalPrice => Pizza.Price * Quantity;
		public CartItem(IPizza pizza, int quantity)
		{
			Pizza = pizza;
			Quantity = quantity;
		}

	}

}