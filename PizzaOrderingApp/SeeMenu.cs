using System;
using Microsoft.Data.Sqlite;
namespace PizzaOrderingApp


	//Metode for å vise menyen til brukeren. Databasenavnet er MenuItems.db og table navnet er Pizza.
	//kilde: PG3302_08_CodeExamples.zip på canvas under materiell fra undervisningen.. 
{
	public class SeeMenuuu
	{
		public List<Pizza> ShowMenu()
		{
			List<Pizza> pizzas = new List<Pizza>();

			using SQLiteConnection connection = new("Data Source = MenuItems.db");
			connection.Open();
			SQLiteCommand command = connection.CreateCommand();
			command.CommandText = "SELECT * FROM pizza";

			using SqliteDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				int id = reader.GetInt32(0);
				string name = reader.GetString(1);
				double price = reader.GetDouble(2);
				string size = reader.GetString(3);
				string description = reader.IsDBNull(4) ? null : reader.GetString(4);

				Pizza pizza = new Pizza
				{
					Id = id,
					Name = name,
					Price = price,
					Size = size,
					Description = description
				};

				pizzas.Add(pizza);
			}
			return pizzas;
		}
	}
}

