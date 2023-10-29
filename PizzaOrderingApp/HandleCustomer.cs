using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOrderingApp.Entities;

namespace PizzaOrderingApp {
	public class HandleCustomer {
		
		//how to handle a customer not adding name and/or address and/or phoneNr?
		//data in the database dissappears. Why?
		public void AddCustomer() {
			Console.WriteLine("Enter your name: ");
			string inputName = Console.ReadLine();

			Console.WriteLine("Enter your address: ");
			string inputAddress = Console.ReadLine();

			Console.WriteLine("Enter your phone number: ");
			int inputPhoneNr = Convert.ToInt32(Console.ReadLine());

			Customer customer = new() {
				Name = inputName,
				Address = inputAddress,
				PhoneNr = inputPhoneNr
			};

			using PizzaOrderingDbContext db = new();
			db.Add(customer);
			db.SaveChanges();
		}
	}
}
