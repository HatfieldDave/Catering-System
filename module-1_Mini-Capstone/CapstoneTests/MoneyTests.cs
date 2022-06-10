/*using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class MoneyTests
    {
        [TestMethod]
        public void DepositOver1000()
        {
            // Arrange 
            Money money = new Money();

            // Act
            string result = money.AddMoney(1001);
            bool equals = result.Equals("Too much entered.  Balance set to 1000");
            // Assert
            Assert.IsTrue(equals); // Inconclusive is a marker for when something cannot be tested
        }

        [TestMethod]
        public void DepositNegativeNumber() // TODO make this pass later.
        {
            // Arrange
            Money money = new Money();

            // Act
            money.AddMoney(-1);

            // Assert
            Assert.AreEqual(0m, money.Balance,"Balance should not be able to be reduced by the AddMoney method");
        }

        [TestMethod]
        public void DepositUnder1000()
        {
            // Arrange
            Money money = new Money();

            // Act
            money.AddMoney(1);

            // Assert
            Assert.AreEqual(1m, money.Balance);
        }

        public void DepositNegativeNumbe()
        {
            // Arrange


            // Act


            // Assert
        }
    }
}*/
