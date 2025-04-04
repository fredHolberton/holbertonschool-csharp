using System;
using InventoryLibrary;

namespace InventoryLibrary
{
    /// <summary>Public class that inherits from BaseClass to manage items.</summary>
    public class Item : BaseClass
    {
        /// <summary>Gets or sets the name of an Item. Required.</summary>
        public required string name { get; set; };

        /// <summary>Gets or sets the description of an Item. Optional.</summary>
        public string description { get; set; };
        
        /// <summary>Gets or sets the price of an Item. Optional.</summary>
        public float price { get; set; }

        /// <summary>Gets or sets a list of tags of an Item. Optional.</summary>
        public list<string> tags { get; set; };

        /// <summary>Constructor of an Item to value properties.</summary>
        [SetsRequiredMembers]
        public Item(string name = "My Item"; string description = string.Empty, float price = 0f, list<string> tags = new list<string>())
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.tags = tags;
        }
    }
}