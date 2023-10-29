using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp {
	public class HandleCustomer {
		//Properties

		//implement customerId when we have the database
		//int customerId { get; set; }
		string? customerName { get; set; }
		string? address { get; set; }
		int? phoneNr { get; set; }


		//Constructor
		//empty constructor for use in main
		public HandleCustomer() {
		}

		//constructor with parameters to store customer in database
		public HandleCustomer(string customerName, string address, int phoneNr) {
			this.customerName = customerName;
			this.address = address;
			this.phoneNr = phoneNr;
		}

		//Methods

		//how to solve that user that the user must add a name, address and pohone number (private field? if in the method AddCustomer?
		public void AddCustomer() {
			Console.WriteLine("Enter your name: ");
			string? inputName = Console.ReadLine();

			Console.WriteLine("Enter your address: ");
			string? inputAddress = Console.ReadLine();

			Console.WriteLine("Enter your phone number: ");
			int inputPhoneNr = Convert.ToInt32(Console.ReadLine());

			HandleCustomer customer = new HandleCustomer(inputName, inputAddress, inputPhoneNr);
			Console.WriteLine($"Your information: {customer.ToString()}");
		}

		public override string? ToString() {
			return $"Name: {customerName}\nAddress: {address}\nPhone number: {phoneNr}";
		}
	}
}
