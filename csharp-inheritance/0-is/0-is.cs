using System;

/// <summary>This is an public class Obj.</summary>
public class Obj
{
    /// <summary>Returns True if the object is an int, otherwise return False.</summary>
    public static bool IsOfTypeInt(object obj)
    {
        return obj is int;
    }
}