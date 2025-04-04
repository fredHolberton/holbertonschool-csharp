using System;
using InventoryLibrary;

namespace InventoryLibrary
{
    /// <summary>Public class that inherits from BaseClass to manage Inventory.</summary>
    public class Inventory : BaseClass
    {
        /// <summary>Gets or sets the User of the Inventory. Required.</summary>
        public required User user_id { get; set; };
        
        /// <summary>Gets or sets the Item of the Inventory. Required.</summary>
        public required Item item_id { get; set;};
        
        /// <summary>Gets or sets the quantity of items in the Inventory. Required.</summary>
        public required int quantity { get; set; };

        /// <summary>Constructor of an Inventory to value properties.</summary>
        [SetsRequiredMembers] 
        public Inventory(User user = new user("John Do"), Item item = new Item("My Item"), int quantity = 1)
        {
            this.user_id = user;
            this.item_id = item;
            this.quantity = quantity >= 0 ? quantity : 1;
        }
    }
}
