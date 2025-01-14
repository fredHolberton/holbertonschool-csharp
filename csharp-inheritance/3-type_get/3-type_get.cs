using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

/// <summary>This is an public class Obj.</summary>
public class Obj
{
    /// <summary>Prints the names of the available properties
    /// and methods of an object.
    /// </summary>
    public static void Print(object myObj)
    {
        Type myType = myObj.GetType();

        // Properties
        Console.WriteLine("{0} Properties:", myType.Name);
        MethodInfo[] myArrayMethodInfo = myType.GetMethods();
        for(int i = 0; i < myArrayMethodInfo.Length; i++)
        {
            MethodInfo myMethodInfo = (MethodInfo)myArrayMethodInfo[i];
            Console.WriteLine("{0}", myMethodInfo.Name);
        }
        // Methods
        Console.WriteLine("{0} Methods:", myType.Name);
        PropertyInfo[] myPropertyInfo = myType.GetProperties();
        foreach (var propInfo in myPropertyInfo) 
        {
            Console.WriteLine("{0}", propInfo.Name);
        }
    }
}
