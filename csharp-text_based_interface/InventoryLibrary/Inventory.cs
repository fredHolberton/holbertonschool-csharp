using System;
using InventoryLibrary;

namespace InventoryLibrary
{
    /// <summary>Public class that inherits from BaseClass to manage Inventory.</summary>
    public class Inventory : BaseClass
    {
        /// <summary>Gets or sets the User of the Inventory. Required.</summary>
        public string user_id { get; set; }
        
        /// <summary>Gets or sets the Item of the Inventory. Required.</summary>
        public string item_id { get; set; }
        
        /// <summary>Gets or sets the quantity of items in the Inventory. Required.</summary>
        public int quantity { get; set; }

        /// <summary>Constructor of an Inventory to value properties.</summary> 
        public Inventory(string user_id, string item_id, int quantity = 1)
        {
            this.user_id = user_id;
            this.item_id = item_id;
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity can not be negative");
            }
            this.quantity = quantity;
        }
    }
}
