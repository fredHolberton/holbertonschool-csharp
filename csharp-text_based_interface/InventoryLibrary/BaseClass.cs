using System;

namespace InventoryLibrary
{
    /// <summary>This is an public class that all other classes will inherit from.</summary>
    public class BaseClass
    {
        /// <summary>Gets or sets the id of the object.</summary>
        public string id { get; set; };

        /// <summary>Gets or sets the created date of the object.</summary>
        public DateTime date_created { get; set; };

        /// <summary>Gets or sets the updated date of the object.</summary>
        public dateTime date_updated { get; set; };

    }
}
