using PizzaOrderingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Technical_services.CRUD {
	public class CrudOperationsOrder {
		public Order AddOrder(Order order) {
			using PizzaOrderingDbContext db = new();
			db.Order.Add(order);
			db.SaveChanges();

			return order;
		}
	}
}
