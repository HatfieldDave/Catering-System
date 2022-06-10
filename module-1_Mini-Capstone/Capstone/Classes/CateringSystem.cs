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
        public decimal Total  // Loops through the list of completed orders and sums up the total cost
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

        public decimal Balance { get; set; } = 0;  // Stores the current users amount of money


        /// <summary>
        /// Adds money to the users account
        /// </summary>
        /// <param name="amount">Amount of money to add to balance</param>
        public void AddMoney(int amount)
        {
            Balance += amount;
        }


        /// <summary>
        /// Removes money from the users account
        /// </summary>
        /// <param name="amount">Amount to remove</param>
        public void RemoveMoney(int amount)
        {
            Balance -= amount;
        }


        /// <summary>
        /// Clears out the users cart and the balamnce
        /// </summary>
        public void ClearCartAndBalance()
        {
            Balance = 0;
            cart = new List<CateringItem>();
        }


        /// <summary>
        /// Checks to see if the given item code matches an item in inverntory
        /// </summary>
        /// <param name="userSelection">ItemCode to be found</param>
        /// <returns></returns>
        public bool ContainsItem(string userSelection)
        {
            if (itemDict.ContainsKey(userSelection))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the given item is in stock or sold out
        /// </summary>
        /// <param name="userSelection">ItemCode to be checked</param>
        /// <returns></returns>
        public bool InStock(string userSelection)
        {
            if(itemDict[userSelection].ItemQuantity != 0)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Cehcks to see if there are enough items in inventory to meet the users request
        /// </summary>
        /// <param name="userSelection">ItemCode requested</param>
        /// <param name="itemQuantity">Amount requested</param>
        /// <returns></returns>
        public bool SufficientStock(string userSelection, int itemQuantity)
        {
            if(itemDict[userSelection].ItemQuantity >= itemQuantity) 
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks the users balance to see if they have enough funds to make the desired purchase
        /// </summary>
        /// <param name="userSelection">ItemCode requested</param>
        /// <param name="itemQuantity">Amount requested</param>
        /// <returns></returns>
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

        /// <summary>
        /// Reduces the ItemQuantity of the CateringItem requested by the user.  Reduces the balance by the total cost of the items.  Returns a new CateringItem representing the purchase
        /// </summary>
        /// <param name="userSelection">ItemCode requested</param>
        /// <param name="itemQuantity">Amount requested</param>
        /// <returns>Receipt</returns>
        public CateringItem DoOrder(string userSelection, int itemQuantity)
        {
            itemDict[userSelection].ItemQuantity -= itemQuantity;  // Reduces ItemQuantity of the requested item in inventory
            string itemType = itemDict[userSelection].ItemType;  // Sets a variable equal to the ItemCode for ease of use
            Balance -= itemDict[userSelection].ItemCost * itemQuantity; // Reduces the balance by the total cost of the requested items
            // Creates a new CateringItem of the appropriate subclass
            if (itemType.Equals("A"))
            {
                AppetizerItem item = new AppetizerItem(itemDict[userSelection].ItemType, itemDict[userSelection].ItemCode, itemDict[userSelection].ItemName, itemDict[userSelection].ItemCost, itemQuantity);
                cart.Add(item);
                return item;
            }
            if (itemType.Equals("B"))
            {
                BeverageItem item = new BeverageItem(itemDict[userSelection].ItemType, itemDict[userSelection].ItemCode, itemDict[userSelection].ItemName, itemDict[userSelection].ItemCost, itemQuantity);
                cart.Add(item);
                return item;
            }
            if (itemType.Equals("D"))
            {
                DessertItem item = new DessertItem(itemDict[userSelection].ItemType, itemDict[userSelection].ItemCode, itemDict[userSelection].ItemName, itemDict[userSelection].ItemCost, itemQuantity);
                cart.Add(item);
                return item;
            }
            if (itemType.Equals("E"))
            {
                EntreeItem item = new EntreeItem(itemDict[userSelection].ItemType, itemDict[userSelection].ItemCode, itemDict[userSelection].ItemName, itemDict[userSelection].ItemCost, itemQuantity);
                cart.Add(item);
                return item;
            }
            return null;
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
        

        public void ItemSaver(CateringItem cateringItem)
        {
            itemDict[cateringItem.ItemCode] = cateringItem;
        }

        public List<CateringItem> GiveReceipt()
        {
            return cart;
        }
        public int ChangeGetter(Decimal denomination)
        {
            int count = 0;

            while(Balance >= denomination)
            {
                count += 1;
                Balance -= denomination;
            }

            return count;
        }
    }
}
