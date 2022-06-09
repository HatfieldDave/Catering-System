using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class BeverageItem : CateringItem
    {
        public BeverageItem(string itemType, string itemCode, string itemName, decimal itemCost, int itemQuantity)
            : base(itemType, itemCode, itemName, itemCost, itemQuantity)
        {

        }
    }
}
