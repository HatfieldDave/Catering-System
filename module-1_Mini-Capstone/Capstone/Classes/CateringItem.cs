using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This represents a single catering item in your system
    /// </summary>
    /// <remarks>
    /// This class MUST be abstract
    /// This class MUST be inherited by at least 2 other classes
    /// Those other classes MUST be used in your program.
    /// </remarks>
    public abstract class CateringItem
    {
        public string ItemType { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal ItemCost { get; set; }
        public int ItemQuantity { get; set; }

        public CateringItem(string itemType, string itemCode, string itemName, decimal itemCost, int itemQuantity)
        {
            this.ItemCode = itemCode;
            this.ItemType = itemType;
            this.ItemName = itemName;
            this.ItemCost = itemCost;
            this.ItemQuantity = itemQuantity;
        }

        public override string ToString()
        {
            string displayString = $"{ItemCode} {ItemName.PadRight(25)} {ItemCost.ToString().PadRight(10)} {ItemQuantity.ToString()}";
            return displayString;
        }
    }
}
