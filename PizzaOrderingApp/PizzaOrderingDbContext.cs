using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOrderingApp.Entities;

namespace PizzaOrderingApp {
	public class PizzaOrderingDbContext : DbContext {
		public DbSet<Customer> Customer => Set<Customer>();
		public DbSet<Pizza_Order> Pizza_Order => Set<Pizza_Order>();
		public DbSet<Pizza> Pizza => Set<Pizza>();	
		public DbSet<Beverage> Beverage => Set<Beverage>();	
		public DbSet<Order> Order => Set<Order>();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlite(@"Data Source = Resources\PizzaOrdering.db");
		}
	}
}
