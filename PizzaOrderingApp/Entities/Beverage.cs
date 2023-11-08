using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Entities
{
	public class Beverage : Menu
	{

		//relasjon til koblingstabellen
		public ICollection<Pizza_Order>? Pizza_Order { get; set; }


		public override void PrintMenu()
		{
			Console.WriteLine("Here is the beverage menu:");

			//Legger til kode for å printe drikke menyen her etterpå

		}
	}
}
