using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PizzaOrderingApp.Menu.IMenuCategoryHandler;

namespace PizzaOrderingApp.Menu
{
	public class ItemMenuHandler<T> : IMenuCategoryHandler where T : MenuItem
	{

		private readonly PizzaOrderingDbContext dbContext;

		public ItemMenuHandler(PizzaOrderingDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void AddProduct(MenuItem product)
		{

			if (product is T menuItem)
			{
				dbContext.MenuItems.Add(menuItem);
				dbContext.SaveChanges();
			}
			else
			{
				throw new ArgumentException("Product must be the correct type");
			}

			dbContext.MenuItems.Add(product);
			dbContext.SaveChanges();
		}
	}
}
