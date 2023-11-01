using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Menu
{
	  public class CategoryService
	{
		private readonly MenuCategoryManager categoryManager;
		private readonly PizzaOrderingDbContext dbContext;

		public CategoryService(MenuCategoryManager categoryManager)
		{
			this.categoryManager = categoryManager;
			this.dbContext = dbContext;
		}

		public void CreateCategory(string categoryName)
		{
			categoryManager.CreateMenuCategory(categoryName);
		}

		public void AddPizzaToCategory(string categoryName, string pizzaName)
		{
			// Finn kategorien basert på kategorinavnet
			var category = dbContext.MenuCategories.FirstOrDefault(c => c.CategoryName == categoryName);

			if (category == null)
			{
				Console.WriteLine($"Kategorien '{categoryName}' eksisterer ikke.");
				return;
			}

			// Opprett en ny pizza og legg den til i kategorien
			var pizza = new MenuItem
			{
				ItemName = pizzaName,
				Category = category
			};

			dbContext.MenuItems.Add(pizza);
			dbContext.SaveChanges();

			Console.WriteLine($"Pizza '{pizzaName}' er lagt til i kategorien '{categoryName}'.");
		}

	}



}