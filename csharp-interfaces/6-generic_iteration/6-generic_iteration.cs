using System;
using System.Collections.Generic;

/// <summary>
/// Interface to interact.
/// </summary>
public interface IInteractive
{
    /// <summary>Interact method to be implemented.</summary>
    void Interact();
}

/// <summary>
/// Interface to break.
/// </summary>
public interface IBreakable
{
    /// <summary>Durability property to be implemented.</summary>
    int durability {get; set;}

    /// <summary>Break method to be implemented.</summary>
    void Break();
}

/// <summary>
/// Interface to Collect.
/// </summary>
public interface ICollectable
{
    /// <summary>Boolean property isCollected to be implemented.</summary>
    bool isCollected {get; set;}

    /// <summary>Collect method to be implemented.</summary>
    void Collect();
}

/// <summary>
/// This class is abstract and can't be instanciated.
/// </summary>
public abstract class Base
{
    /// <summary>String name property.</summary>
    public string name {get; set;}

    /// <summary>
    /// Overrides Base method ToString to print information about name.
    /// </summary>
    public override string ToString()
    {
        return name + " is a " + this.GetType();
    }
}

/// <summary>
/// Door class that inherits Base and implements IInteractive.
/// </summary>
public class Door : Base, IInteractive
{
    /// <summary>Constructor that sets the value of name</summary>
    public Door(string name = "Door")
    {
        this.name = name;
    }

    /// <summary>Implementation of Interact method of IInteractive</summary>
    public void Interact()
    {
        Console.WriteLine("You try to open the {0}. It's locked.", this.name);
    }

}

/// <summary>
/// Decoration class that inherits Base and implements IInteractive and IBreakable.
/// </summary>
public class Decoration : Base, IInteractive, IBreakable
{
    /// <summary>isQuestItem property</summary>
    public bool isQuestItem {get; set;}
    
    /// <summary>
    /// Implementation of durability property of IBreakable.
    /// </summary>
    public int durability { get; set; }

    /// <summary>Constructor that sets the properties</summary>
    public Decoration(string name = "Decoration", int durability = 1, bool isQuestItem = false)
    {
        this.name = name;
        this.durability = durability;
        this.isQuestItem = isQuestItem;

        if (durability <= 0)
        {
            throw new ArgumentException("Durability must be greater than 0");
        }
    }
    
    /// <summary>Implementation of Interact method of IInteractive</summary>
    public void Interact()
    {
        if (this.durability <= 0)
            Console.WriteLine("The {0} has been broken.", this.name);
        else
        {
            if (this.isQuestItem)
            {
                Console.WriteLine("You look at the {0}. There's a key inside.", this.name);
            }      
            else
            {
                Console.WriteLine("You look at the {0}. Not much to see here.", this.name);
            }    
        }     
    }

    /// <summary>Implementation of Break method of IBreakable</summary>
    public void Break()
    {
        this.durability--;
        if (this.durability > 0)
        {
            Console.WriteLine("You hit the {0}. It cracks.", this.name);
        }
        else if (this.durability == 0)
        {
            Console.WriteLine("You smash the {0}. What a mess.", this.name);
        }
        else
        {
            Console.WriteLine("The {0} is already broken.", this.name);
        }
    } 
}

/// <summary>
/// Key class that inherits Base and implements ICollectable.
/// </summary>
public class Key : Base, ICollectable
{
    /// <summary>
    /// Implementation of isCollected property of ICollectable.
    /// </summary>
    public bool isCollected { get; set; }

    /// <summary>Constructor that sets the properties</summary>
    public Key(string name = "Key", bool isCollected = false)
    {
        this.name = name;
        this.isCollected = isCollected;
    }

    /// <summary>Implementation of Collect method of ICollectable</summary>
    public void Collect()
    {
        string msg;
        if (this.isCollected == false)
        {
            this.isCollected = true;
            msg = "You pick up the " + this.name + ".";
        }
        else
        {
            msg = "You have already picked up the " + this.name + ".";
        }
        Console.WriteLine(msg);
    }
}

/// <summary>
/// Objs<T> class that creates a collection of type T objects 
/// that can be iterated through using foreach.
/// </summary>
public class Objs<T> : IEnumerable<T>
{
    /// Collection of type T objects 
    private List<T> items;

    /// <summary>
    /// Constructor to initialize the collection.
    /// </summary>
    public Objs()
    {
        items = new List<T>();
    }

    /// <summary>
    /// Adds an item to the collection.
    /// </summary>
    public void Add(T item)
    {
        items.Add(item);
    }

    /// <summary>
    /// Removes an item from the collection.
    /// </summary>
    public bool Remove(T item)
    {
        return items.Remove(item);
    }

    /// <summary>
    /// Returns the number of items in the collection.
    /// </summary>
    public int Count
    {
        get { return items.Count; }
    }
    
    
    /// <summary>
    /// Implementation of the GetEnumerator method to enable
    /// foreach iteration.
    /// </summary>
    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    /// <summary>
    /// Explicit non-generic IEnumerator implementation
    /// for non-generic collections.
    /// This is necessary for the IEnumerable interface.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

