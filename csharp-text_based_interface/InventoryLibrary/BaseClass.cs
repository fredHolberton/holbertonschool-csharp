﻿using System;

namespace InventoryLibrary
{
    /// <summary>This is an public class that all other classes will inherit from.</summary>
    public abstract class BaseClass
    {
        /// <summary>Gets or sets the id of the object.</summary>
        public string id { get; set; }

        /// <summary>Gets or sets the created date of the object.</summary>
        public DateTime date_created { get; set; }

        /// <summary>Gets or sets the updated date of the object.</summary>
        public DateTime date_updated { get; set; }

        /// <summary>Constructor to init the BaseClass properties.</summary>
        public BaseClass()
        {
            id = Guid.NewGuid().ToString();
            date_created = DateTime.UtcNow;
            date_updated = DateTime.UtcNow;
        }
    }
}
