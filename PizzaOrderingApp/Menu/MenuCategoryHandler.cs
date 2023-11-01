using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Menu
{

	public class IMenuCategoryHandler
	{
		private readonly PizzaOrderingDbContext dbContext;

		public IMenuCategoryHandler(PizzaOrderingDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void AddProduct(MenuItem product)
		{
			if (product is MenuItem menuItem)
			{
				dbContext.MenuItems.Add(menuItem);
				dbContext.SaveChanges();
			}
			else
			{
				throw new ArgumentException("Product must be the correct type");
			}
		}
	}
}




