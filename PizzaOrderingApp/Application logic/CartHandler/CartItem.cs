using PizzaOrderingApp.Application_logic.Decorators;

namespace PizzaOrderingApp.Application_logic.CartHandler
{

	//Class defines the structure for a shoppingcart object, including the pizza object from IPizza class
	public class CartItem
	{
		public IPizza Pizza { get; set; }
		public int Quantity { get; set; }

		public int TotalPrice => Pizza.Price * Quantity;
		public CartItem(IPizza pizza, int quantity)
		{
			Pizza = pizza;
			Quantity = quantity;
		}

	}

}