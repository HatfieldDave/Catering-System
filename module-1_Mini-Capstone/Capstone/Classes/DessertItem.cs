using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    class DessertItem : CateringItem
    {
        public DessertItem(string itemType, string itemCode, string itemName, decimal itemCost, int itemQuantity)
            : base(itemType, itemCode, itemName, itemCost, itemQuantity)
        {

        }
    }
}
