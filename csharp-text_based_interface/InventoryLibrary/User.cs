using System;
using InventoryLibrary;

namespace InventoryLibrary
{
    /// <summary>Public class that inherits from BaseClass to manage Users.</summary>
    public class User : BaseClass
    {
        /// <summary>Gets or sets the name of a User. Required.</summary>
        public required string name { get; set; };

        /// <summary>Constructor of a User to value property.</summary>
        [SetsRequiredMembers]
        public User(string name = "John Do")
        {
            this.name = name;
        }
    }
}
