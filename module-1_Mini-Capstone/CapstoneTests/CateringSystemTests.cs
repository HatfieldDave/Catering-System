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
            catering.ClearCartAndBalance();

            // Assert
            Assert.AreEqual(0, catering.Balance);
        }
        [TestMethod]
        public void ContainsItemShouldReturnTrue()
        {
            // Arrange 
            CateringSystem catering = new CateringSystem();

            // Act
            BeverageItem surge = new BeverageItem("", "A1", "", 0m, 0);
            catering.ItemSaver(surge);
           bool result = catering.ContainsItem("A1");

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ContainsItemShouldReturnFalse()
        {
            // Arrange 
            CateringSystem catering = new CateringSystem();

            // Act
            BeverageItem surge = new BeverageItem("", "A1", "", 0m, 0);
            catering.ItemSaver(surge);
            bool result = catering.ContainsItem("A2");

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void InStockShouldReturnTrue()
        {
            // Arrange 
            CateringSystem catering = new CateringSystem();

            // Act
            BeverageItem surge = new BeverageItem("", "A1", "", 0m, 1);
            catering.ItemSaver(surge);
            bool result = catering.InStock(surge.ItemCode);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void InStockShouldReturnFalse()
        {
            // Arrange 
            CateringSystem catering = new CateringSystem();

            // Act
            BeverageItem surge = new BeverageItem("", "A1", "", 0m, 0);
            catering.ItemSaver(surge);
            bool result = catering.InStock(surge.ItemCode);

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void SufficientStockShouldReturnFalse()
        {
            // Arrange 
            CateringSystem catering = new CateringSystem();

            // Act
            BeverageItem surge = new BeverageItem("", "A1", "", 0m, 0);
            catering.ItemSaver(surge);
            bool result = catering.SufficientStock(surge.ItemCode, 10);

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void SufficientStockShouldReturnTrue()
        {
            // Arrange 
            CateringSystem catering = new CateringSystem();

            // Act
            BeverageItem surge = new BeverageItem("", "A1", "", 0m, 10);
            catering.ItemSaver(surge);
            bool result = catering.SufficientStock(surge.ItemCode, 10);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void SufficientFundsShouldReturnTrue()
        {
            // Arrange 
            CateringSystem catering = new CateringSystem();

            // Act
            BeverageItem surge = new BeverageItem("", "A1", "", 1.50m, 0);
            catering.ItemSaver(surge);
            catering.AddMoney(10);
            bool result = catering.SufficientFunds(surge.ItemCode, 1);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void SufficientFundsShouldReturnFalse()
        {
            // Arrange 
            CateringSystem catering = new CateringSystem();

            // Act
            BeverageItem surge = new BeverageItem("", "A1", "", 1.50m, 0);
            catering.ItemSaver(surge);
            catering.AddMoney(0);
            bool result = catering.SufficientFunds(surge.ItemCode, 1);

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void DoOrderShouldChangeBalace()
        {
            // Arrange 
            CateringSystem catering = new CateringSystem();

            // Act
            BeverageItem surge = new BeverageItem("", "A1", "", 1.50m, 10);
            catering.ItemSaver(surge);
            catering.AddMoney(10);
            catering.DoOrder(surge.ItemCode, 1);

            // Assert
            Assert.AreEqual(8.50m, catering.Balance);
        }
        [TestMethod]
        public void GetStringArrayShouldReturnCorrectly()
        {
            // Arrange 
            CateringSystem catering = new CateringSystem();

            // Act
            BeverageItem surge = new BeverageItem("A", "A1", "Cake", 1.50m, 10);
            catering.ItemSaver(surge);
            string[] result = catering.GetStringArray();
            bool resultBool = result[0].Equals("A1 || Cake || 1.50 || 10");

            // Assert
            Assert.IsTrue(resultBool);
        }
    }
}
