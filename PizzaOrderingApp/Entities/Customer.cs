using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Entities {
	//1:* relationship to order
	public class Customer {
		//Properties
		//now the user can have only one addess
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty; //is it OK for string variables here to be empty?
		public string Address { get; set; } = string.Empty;
		public int PhoneNr { get; set; }

		//does this class have a default empty constructor?

		public ICollection<Order>? Order { get; set; }
	}
}
