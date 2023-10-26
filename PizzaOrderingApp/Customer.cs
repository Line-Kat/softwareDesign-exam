using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp {
	public class Customer {
		//Properties

		//how to not set set fields as optional to add

		//implement customerId when we have the database
		//int customerId { get; set; }
		string? customerName { get; set; }
		string? address { get; set; }
		int? phoneNr { get; set; }


		//Constructor
		//empty constructor for use in main
		public Customer() {
		}

		//constructor with parameters to store customer in database
		public Customer(string customerName, string address, int phoneNr) {
			this.customerName = customerName;
			this.address = address;
			this.phoneNr = phoneNr;
		}

		//Methods

		//how to not make the input optional?
		public void AddCustomer() {
			Console.WriteLine("Enter your name: ");
			string? inputName = Console.ReadLine();

			Console.WriteLine("Enter your address: ");
			string? inputAddress = Console.ReadLine();

			Console.WriteLine("Enter your phone number: ");
			int inputPhoneNr = Convert.ToInt32(Console.ReadLine());

			Customer customer = new Customer(inputName, inputAddress, inputPhoneNr);
			Console.WriteLine(customer.ToString());
		}

		public override string? ToString() {
			return $"Name: {customerName}\nAddress: {address}\nPhone number: {phoneNr}";
		}
	}
}
