using PizzaOrderingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Technical_services {
	public class CrudOperations {


		public Customer getCustomerByPhoneNr(int phoneNumber) {
			using PizzaOrderingDbContext db = new();

			Customer customer = db.Customer.FirstOrDefault(customer => customer.PhoneNr == phoneNumber);
			return customer;
		}

		public Customer getCustomerById(int id) {
			using PizzaOrderingDbContext db = new();


			Customer customer = db.Customer.Where(customer => customer.CustomerId == id).FirstOrDefault();
			return customer;
		}

		public Customer addCustomer(Customer customer) {

			using PizzaOrderingDbContext db = new();

			db.Customer.Add(customer);
			db.SaveChanges();

			return customer;

		}

		//denne kan være void
		public Customer updateCustomer(Customer customer) {
			using PizzaOrderingDbContext db = new();
			db.Update(customer);
			db.SaveChanges();

			return customer;
		}

		public void deleteCustomer(Customer customer) {
			using PizzaOrderingDbContext db = new();
			db.Customer.Remove(customer);
			db.SaveChanges();
		}
	}
}
