using System;

namespace Enemies
{
    /// <summary>This is an public class within Enemies namespace.</summary>
    public class Zombie
    {
        /// <summary>Public field for Zombie.health.</summary>
        public int health;

        /// <summary>Initializes a new instance of the <see cref="Zombie"/> class.</summary>
        public Zombie()
        {
            this.health = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Zombie"/> class.
        /// <param name="value">The value of the health of the Zombie.</param>
        /// </summary>
        public Zombie(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Health must be greater than or equal to 0");
            }
            this.health = value;
        }
    }
}
