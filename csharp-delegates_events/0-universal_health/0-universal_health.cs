using System;

/// <summary>
/// public class Player
/// </summary>
public class Player
{
    /* String name property. */
    private string name;

    /* float maxHp property. */
    private float maxHp;

    /* float hp property */
    private float hp;

    /// <summary>constructor to initialize properties.</summary>
    public Player(string name = "Player", float maxHp = 100f)
    {
        this.name = name;
        this.maxHp = maxHp;
        if (this.maxHp <= 0)
        {
            this.maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }
        this.hp = this.maxHp;
    }

    /// <summary>Method to print health of player.</summary>
    public void PrintHealth()
    {
        Console.WriteLine("{0} has {1} / {2} health", this.name, this.hp, this.maxHp);
    }
}
