using System;

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
/// Test class to inherite Base and implement Interfaces.
/// </summary>
public class TestObject : Base, IInteractive, IBreakable, ICollectable
{
    /// <summary>
    /// Implementation of durability property of IBreakable.
    /// </summary>
    public int durability { get; set; }

    /// <summary>
    /// Implementation of isCollected property of ICollectable.
    /// </summary>
    public bool isCollected { get; set; }

    /// <summary>Implementation of Interact method of IInteractive</summary>
    public void Interact()
    {
        /* Add here code of the implementation */
    }

    /// <summary>Implementation of Break method of IBreakable</summary>
    public void Break()
    {
        /* Add here code of the implementation */
    }

    /// <summary>Implementation of Collect method of ICollectable</summary>
    public void Collect()
    {
        /* Add here code of the implementation */
    }

}
