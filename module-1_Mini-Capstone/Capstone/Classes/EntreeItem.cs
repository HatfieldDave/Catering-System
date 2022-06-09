using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class EntreeItem : CateringItem
    {
        public EntreeItem(string itemType, string itemCode, string itemName, decimal itemCost, int itemQuantity)
            : base(itemType, itemCode, itemName, itemCost, itemQuantity)
        {

        }
    }
}
