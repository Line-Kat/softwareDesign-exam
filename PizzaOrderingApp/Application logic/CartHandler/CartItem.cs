namespace PizzaOrderingApp.Application_logic.CartHandler
{
	public class CartItem
	{
		public int PizzaId { get; set; }
		public int Quantity { get; set; }
		public string PizzaName { get; set; }
		public int Price { get; set; }

		public string Description { get; set; }

		public CartItem(int pizzaId, string pizzaName, int quantity, int price)
		{
			PizzaId = pizzaId;
			PizzaName = pizzaName;
			Quantity = quantity;
			Price = price;

		}

	}

}