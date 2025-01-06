using System;

namespace Enemies
{
    /// <summary>This is an public class within Enemies namespace.</summary>
    public class Zombie
    {
        /// Private field for Zombie.health.
        private int health;
        /// Private field for Zombie.name
        private string name = "(No name)";

        /// <summary>Initializes a new instance of the <see cref="Zombie"/> class.</summary>
        public Zombie()
        {
            this.health = 0;
        }

        /// <summary>Initializes a new instance of the <see cref="Zombie"/> class with initial value for health.</summary>
        public Zombie(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Health must be greater than or equal to 0");
            }
            this.health = value;
        }

        /// <summary>Gets or sets the name of the Zombie.</summary>
        public string Name 
        { 
            get
            {
                return name;
            } 
            set
            {
                if (value == string.Empty)
                {
                    this.name = "(No name)";
                }
                else
                {
                    name = value;
                }
                
            }
        }

        /// <summary>Function that Return health value.</summary>
        public int GetHealth()
        {
            return this.health;
        }
    }
}
