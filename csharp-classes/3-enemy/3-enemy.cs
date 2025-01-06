using System;

namespace Enemies
{
    /// <summary>This is an public class within Enemies namespace.</summary>
    public class Zombie
    {
        /// private field for Zombie.health.
        private int health;

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

        /// <summary>Function that Return health value.</summary>
        public int GetHealth()
        {
            return this.health;
        }
    }
}
