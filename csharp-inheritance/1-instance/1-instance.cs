using System;

/// <summary>This is an public class Obj.</summary>
public class Obj
{
    /// <summary>Returns True if the object is an instance of, or if the object is an instance of a class that inherited from, Array,
    /// otherwise return False.
    /// </summary>
    public static bool IsInstanceOfArray(object obj)
    {
        return typeof(Array).IsInstanceOfType(obj);
    }
}
