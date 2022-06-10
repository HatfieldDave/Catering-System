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
        //private readonly List<CateringItem> items = new List<CateringItem>();
        private Dictionary<string, CateringItem> itemDict = new Dictionary<string, CateringItem>();
        private List<CateringItem> cart = new List<CateringItem>();

        public decimal Balance { get; set; }

        public void AddMoney(int amount)
        {
            Balance += amount;
        }

        public void RemoveMoney(int amount)
        {
            Balance -= amount;
        }

        public void ClearBalance()
        {
            Balance = 0;
        }

        public bool ContainsItem(string userSelection)
        {
            if (itemDict.ContainsKey(userSelection))
            {
                return true;
            }
            return false;
        }

        public bool InStock(string userSelection)
        {
            if(itemDict[userSelection].ItemQuantity > 0)
            {
                return true;
            }
            return false;
        }

        public void DoOrder()
        {

        }

        /// <summary>
        /// Creates an array of strings based of the ToString method of each CateringItem
        /// </summary>
        /// <returns>string[] lines</returns>
       public string[] GetStringArray() // TODO Make something like this that works for a dictionary.
        {
            
            string[] lines = new string[itemDict.Count]; 

            int i = 0;
            foreach (KeyValuePair<string,CateringItem> item in itemDict)
            {
                string line = item.Value.ToString();
                lines[i] = line;
                i++;
            }
            return lines;
        }
        
        public void ItemSaver(BeverageItem beverage)
        {
            //items.Add(beverage);
        }

        public void ItemSaver2(BeverageItem beverage)
        {
            itemDict[beverage.ItemCode] = beverage;
        }
    }
}
