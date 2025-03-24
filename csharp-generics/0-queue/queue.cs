using System;
using System.Collections.Generic;

/// <summary>This class should not inherit from other classes or interfaces.</summary>
public class Queue<T>
{

    /// <summary>
    /// Returns the Queue’s type.
    /// </summary>
    public Type CheckType()
    {
        return  typeof(T);
    }
}