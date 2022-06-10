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
        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (CateringItem item in cart)
                {
                    total += item.ItemCost * item.ItemQuantity;
                }
                return total;
            }
        }

        public decimal Balance { get; set; } = 0;

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
            if(itemDict[userSelection].ItemQuantity != 0)
            {
                return true;
            }
            return false;
        }

        public bool SufficientStock(string userSelection, int itemQuantity)
        {
            if(itemDict[userSelection].ItemQuantity >= itemQuantity) 
            {
                return true;
            }
            return false;
        }

        public bool SufficientFunds(string userSelection, int itemQuantity)
        {
            decimal itemPrice = itemDict[userSelection].ItemCost;
            decimal total = itemPrice * itemQuantity;

            if(Balance >= total)
            {
                return true;
            }
            return false;
        }

        public void DoOrder(string userSelection, int itemQuantity)
        {
            itemDict[userSelection].ItemQuantity -= itemQuantity;
            Balance -= itemDict[userSelection].ItemCost * itemQuantity;
            BeverageItem soda = new BeverageItem(itemDict[userSelection].ItemType, itemDict[userSelection].ItemCode, itemDict[userSelection].ItemName, itemDict[userSelection].ItemCost, itemQuantity);
            cart.Add(soda);
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
            itemDict[beverage.ItemCode] = beverage;
        }
    }
}
