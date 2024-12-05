using System;
using System.Collections.Generic;

class Dictionary
{
    public static void PrintSorted(Dictionary<string, string> myDict)
    {
        List<string> sortedList = new List<string>();

        // créer une liste avec les key du dictionnaire
        foreach (KeyValuePair<string, string> kvp in myDict)
            sortedList.Add(kvp.Key);
        
        // trier la liste
        sortedList.Sort();

        foreach (string elt in sortedList)
            Console.WriteLine("{0}: {1}", elt, myDict[elt]);
    }
}
