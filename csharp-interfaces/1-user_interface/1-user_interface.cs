using System;

/// <summary>
/// Interface to interact.
/// </summary>
interface IInteractive
{
    /// <summary>Interact method to be implemented.</summary>
    void Interact();
}

/// <summary>
/// Interface to break.
/// </summary>
interface IBreakable
{
    /// <summary>Durability property to be implemented.</summary>
    int durability
    {
        get;
        set;
    }

    /// <summary>Break method to be implemented.</summary>
    void Break();
}

/// <summary>
/// Interface to Collect.
/// </summary>
interface ICollectable
{
    /// <summary>Boolean property isCollected to be implemented.</summary>
    bool isCollected
    {
        get;
        set;
    }

    /// <summary>Collect method to be implemented.</summary>
    void Collect();
}

/// <summary>
/// This class is abstract and can't be instanciated.
/// </summary>
abstract class Base
{
    /// <summary>String name property.</summary>
    public string name = String.Empty;

    /// <summary>Overrides Base method ToString to print information about name.</summary>
    public override string ToString()
    {
        return name + " is a " + this.GetType();
    }
}

class TestObject : Base, IInteractive, IBreakable, ICollectable
{
    /// <summary>Implementation of durability property of IBreakable</summary>
    private int IBreakable.durability;

    public int get_durability()
    {
        return this.durability;
    }
    public void set_durability(int value)
    {
        this.durability = value;
    }

    /// <summary>Implementation of isCollected property of ICollectable</summary>
    private bool ICollectable.isCollected;

    public bool get_isCollected()
    {
        return this.isCollected;
    }
    public void set_isCollected(bool value)
    {
        this.isCollected = value;
    }
    

    /// <summary>Implementation of Interact method of IInteractive</summary>
    public void Interact()
    {
        // Add here code of the implementation
    }

    /// <summary>Implementation of Break method of IBreakable</summary>
    public void Break()
    {
        // Add here code of the implementation
    }

    /// <summary>Implementation of Collect method of ICollectable</summary>
    public void Collect()
    {
        // Add here code of the implementation
    }

}
