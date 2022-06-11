using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class CateringItemTest
    {
        [TestMethod]
        public void GetStringArrayShouldReturnCorrectly()
        {
            // Arrange 
            CateringSystem catering = new CateringSystem();

            // Act
            BeverageItem surge = new BeverageItem("A", "A1", "Cake", 1.50m, 10);
            catering.ItemSaver(surge);
            string[] result = catering.GetStringArray();
            bool resultBool = result[0].Equals("A1 Cake                      1.50       10");

            // Assert
            Assert.IsTrue(resultBool);
        }
    }
}
