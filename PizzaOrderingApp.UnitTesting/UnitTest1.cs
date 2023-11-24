using PizzaOrderingApp;

namespace PizzaOrderingApp.UnitTesting {
	public class Tests {
		[SetUp]
		public void Setup() {
		}

		[Test]

		//tester at det kan kjøres tester
		public void Test() {
			int one = 1;
			int two = 2;

			one.Equals(two);
		}

		public void Test1() {
			Assert.Pass();
		}
	}
}