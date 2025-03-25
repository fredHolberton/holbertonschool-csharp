using System;

/// <summary>
/// This class is abstract and can't be instanciated.
/// </summary>
abstract class Base
{
    /// <summary>String name property.</summary>
    public string name;

    /// <summary>Overrides Base method ToString to print information about name.</summary>
    public override string ToString()
    {
        return name + " is a string";
    }
}
