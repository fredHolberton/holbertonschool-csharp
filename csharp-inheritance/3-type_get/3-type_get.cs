using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

/// <summary>This is an public class Obj.</summary>
public class Obj
{
    /// <summary>Prints the names of the available properties and methods of an object.</summary>
    public static void Print(object myObj)
    {
        TypeInfo t = myObj.GetType().GetTypeInfo();
        IEnumerable<PropertyInfo> pList = t.DeclaredProperties;
        IEnumerable<MethodInfo> mList = t.DeclaredMethods;

        Console.WriteLine("{0} Properties:", myObj.GetType().Name);
        foreach (PropertyInfo p in pList)
        {
            Console.WriteLine("{0}", p.Name);
        }

        Console.WriteLine("{0} Methods:", myObj.GetType().Name);
        foreach (MethodInfo m in mList)
        {
            Console.WriteLine("{0}", m.Name);
        }
    }
}
