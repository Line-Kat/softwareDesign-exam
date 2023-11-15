using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp {
	public class PizzaQueue {

		/*
		public int totalPizzaNumber { get; private set; }
		public DateTime queueEnd { get; private set; }


		public PizzaQueue(int pizzaNumber, DateTime newPizzaQueue) {
			totalPizzaNumber += pizzaNumber;
			queueEnd = newPizzaQueue;
		}

		*/
		public static int totalNumberOfPizza(int userPizzaCount){
			total += userPizzaCount;
			return total;
		}
		
		private static int getpizzaNumber() {
			Console.WriteLine("Number of pizza");
			int pizzaNumber = int.Parse(Console.ReadLine());
			if (pizzaNumber <= 1) {
				return pizzaNumber;
			} else {
				Console.WriteLine("Write a number (1 or higher)");
				return getpizzaNumber();
			}
		}

		public DateTime CheckQueue(int userPizzaCount) {
			int totalPizzaNumber = 0;
			// update queueWait with queueEnd and add userPizzaCount to totalPizzaNumber
			totalPizzaNumber += userPizzaCount;
			DateTime queueEnd = new DateTime(2023, 11, 09, 13, 20, 00);

			DateTime timeNow = DateTime.Now;
			TimeSpan pizzaCookingTime = new TimeSpan(0, (userPizzaCount * 10), 0);

			if (timeNow < queueEnd) {
				DateTime queueWait = (queueEnd + pizzaCookingTime);
				Console.WriteLine(totalPizzaNumber);
				return queueWait;
			}
			else if (timeNow >= queueEnd) {
				DateTime queueWait = (timeNow + pizzaCookingTime);
				return queueWait;
			}
			return timeNow;

		}
		// method to get number of minutes

		/*
		 * // for å displaye i tid (timer)
				var queueWait = (queueEnd-timeNow);
				// regne ut tid
				var newQueueEnd = timeNow + queueWait;

		public static bool checkQueue(DateTime inQueue, DateTime orderTime) {
			var currentTime = orderTime;
			return currentTime.CompareTo(inQueue) > 0;
		}

		public DateTime pickupTime() {

			checkQueue(orderTime = DateTime.Now);
			if (checkQueue = true){
			}
			return 0;
		}
		get current time and date
		DateTime lastOrderFinished = new DateTime(2023, 11, 9, 14, 45, 20);
		DateTime orderTime = DateTime.Now;
	
			Console.WriteLine("Current date and time: " + orderTime.ToString());

		bool isAfter = lastOrderFinished orderTime; // true
		
		
		if(isAfter){
		}
		
		DateTime newQueueTime = DateTime.Now;
		string dateWithFormat = timeNow.ToLongDateString();
		
		// Console.WriteLine((newQueueTime - timeNow)).TotalHours);

		private double calcQueue() { 

		}
		*/

	}
}
