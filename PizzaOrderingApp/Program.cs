namespace PizzaOrderingApp
{
    internal class Program {
		static void Main(string[] args) {
			Console.WriteLine("Welcome to Pizza Factory");
			HandleCustomer customer = new();
			customer.AddCustomer();
		}
	}
}