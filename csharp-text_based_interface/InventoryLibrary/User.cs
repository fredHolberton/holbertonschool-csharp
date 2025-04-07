using System;
using InventoryLibrary;

namespace InventoryLibrary
{
    /// <summary>Public class that inherits from BaseClass to manage Users.</summary>
    public class User : BaseClass
    {
        /// <summary>Gets or sets the name of a User. Required.</summary>
        public string name { get; set; }

        /// <summary>Constructor of a User to value property.</summary>
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));

            this.name = name;           
        }
    }
}
