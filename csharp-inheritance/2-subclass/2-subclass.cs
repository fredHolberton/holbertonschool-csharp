using System;

/// <summary>This is an public class Obj.</summary>
public class Obj
{
    /// <summary>Returns True if the object is an instance of a class that inherits from the specified class,
    /// otherwise return False.
    /// </summary>
    public static bool IsOnlyASubclass(Type derivedType, Type baseType)
    {
        return baseType.IsAssignableFrom(derivedType) && derivedType != baseType;
    }
}
