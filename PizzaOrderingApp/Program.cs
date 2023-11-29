using PizzaOrderingApp.Application_runner;

namespace PizzaOrderingApp
{
	internal class Program
	{
		static void Main(string[] args)
		{

			RunPizzaApp runPizzaApp = new RunPizzaApp();
			runPizzaApp.Run();

		}
	}
}