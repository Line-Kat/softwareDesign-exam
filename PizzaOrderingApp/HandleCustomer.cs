using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PizzaOrderingApp.Entities;

namespace PizzaOrderingApp {
	public class HandleCustomer {
		
		//how to handle a customer not adding name and/or address and/or phoneNr?
		//previous data in the database dissappears when restarting the program. Why?
		public void AddCustomer() {
			Console.WriteLine("Enter your name: ");
			string? inputName = Console.ReadLine();

			Console.WriteLine("Enter your address: ");
			string? inputAddress = Console.ReadLine();

			Console.WriteLine("Enter your phone number: ");
			int inputPhoneNr = Convert.ToInt32(Console.ReadLine());

			Customer customer = new() {
				Name = inputName,
				Address = inputAddress,
				PhoneNr = inputPhoneNr
			};


			//should this be a global object?
			using PizzaOrderingDbContext db = new();

			db.Customer.Add(customer);
			db.SaveChanges();

			//to keep the id of the customer last added to the database
			int latestId = customer.Id;

			Console.WriteLine($"Your information:\nName: {customer.Name}\nAddress: {customer.Address}\nPhone number: {customer.PhoneNr}");

			Console.WriteLine("Is the information correct? (type Y or N)");
			string userInput = Console.ReadLine();
			if (userInput.ToUpper() == "N") {
				editCustomer(customer.Id);
			} 
		}

		//edit customers name
		public void editCustomer(int id) {
			using PizzaOrderingDbContext db = new();
			Customer? customer = db.Customer.SingleOrDefault(customer => customer.Id == id);

			Console.WriteLine("Type the number of the alternative you need to edit\n1 name\n2 address\n3 phone number");
			int userInput = int.Parse(Console.ReadLine());
			
			//use switch?
			if (userInput == 1) { 
				Console.WriteLine("Type name: ");
				string name = Console.ReadLine();

				if (customer != null) {
					customer.Name = name;
					db.Update(customer);
					db.SaveChanges();
				}
			}

			if(userInput == 2) {
				Console.WriteLine("Type address: ");
				string address = Console.ReadLine();

				if (customer != null) {
					customer.Address = address;
					db.Update(customer);
					db.SaveChanges();
				}
			}

			if(userInput == 3) { 
				Console.WriteLine("Type phone number");
				int phoneNumber = int.Parse(Console.ReadLine());

				if (customer != null) {
					customer.PhoneNr = phoneNumber;
					db.Update(customer);
					db.SaveChanges();
				}
			}
		}
	}
	
}
