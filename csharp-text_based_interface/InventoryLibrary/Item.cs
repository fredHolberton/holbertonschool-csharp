using System;
using System.Collections.Generic;

namespace InventoryLibrary
{
    /// <summary>Public class that inherits from BaseClass to manage items.</summary>
    public class Item : BaseClass
    {
        /// <summary>Gets or sets the name of an Item. Required.</summary>
        public string name { get; set; }

        /// <summary>Gets or sets the description of an Item. Optional.</summary>
        public string description { get; set; }
        
        /// <summary>Gets or sets the price of an Item. Optional.</summary>
        public float price { get; set; }

        /// <summary>Gets or sets a list of tags of an Item. Optional.</summary>
        public List<string> tags { get; set; } = new List<string>();

        /// <summary>Constructor of an Item to value properties.</summary>
        public Item(string name, string description = "", float price = 0f, List<string> tags = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));

            this.name = name;
            this.description = description;
            this.price = price;
            this.tags = tags;
        }
    }
}