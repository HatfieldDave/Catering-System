using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class CateringSystemTests
    {
        [TestMethod]
        public void DepositMoney()
        {
            // Arrange 
            CateringSystem catering = new CateringSystem();

            // Act
            catering.AddMoney(10);

            // Assert
            Assert.AreEqual(10,catering.Balance);
        }

        [TestMethod]
        public void RemoveMoney()
        {
            // Arrange 
            CateringSystem catering = new CateringSystem();

            // Act
            catering.AddMoney(10);
            catering.RemoveMoney(5);

            // Assert
            Assert.AreEqual(5, catering.Balance);
        }

        [TestMethod]
        public void ClearBalance()
        {
            // Arrange 
            CateringSystem catering = new CateringSystem();

            // Act
            catering.AddMoney(10);
            catering.ClearBalance();

            // Assert
            Assert.AreEqual(0, catering.Balance);
        }
    }
}
