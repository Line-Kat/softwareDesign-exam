using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.Menu;

namespace PizzaOrderingApp {
	public class PizzaOrderingDbContext : DbContext {
		public DbSet<Customer> Customer => Set<Customer>();
		public DbSet<MenuItem> MenuItems { get; set; }
		public DbSet<MenuCategory> MenuCategories => Set<MenuCategory>();
		public DbSet<Order> Order => Set<Order>();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlite(@"Data Source = Resources\PizzaOrdering.db");
		}
	}
}
