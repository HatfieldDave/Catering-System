using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain all the "work" for catering system management
    /// </summary>
    public class CateringSystem 
    {
        private readonly List<CateringItem> items = new List<CateringItem>();
        
        public void TestMethod()
        {
            //BeverageItem drink = new BeverageItem("B", "B1", "Faygo", 30.00m, 100);
            //items.Add(drink);

           // Console.WriteLine(drink);
           foreach(CateringItem item in items)
            {
                
            }
        }

        /// <summary>
        /// Creates an array of strings based of the ToString method of each CateringItem
        /// </summary>
        /// <returns>string[]</returns>
       public string[] GetStringArray()
        {
            
            string[] lines = new string[items.Count]; 

            int i = 0;
            foreach (CateringItem item in items)
            {
                string line = item.ToString();
                lines[i] = line;
                i++;
            }
            return lines;
        }
        
        public void ItemSaver(BeverageItem beverage)
        {
            items.Add(beverage);
        }
    }
}
