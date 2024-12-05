using System;
using System.Collections.Generic;

class List
{
    public static int MaxInteger(List<int> myList)
    {
        // Cas d'erreur : Si la liste est vide
        if (myList.Count == 0)
        {
            Console.WriteLine("List is empty");
            return -1;
        }
        // cas standard : la liste n'est pas vide. 
        int maxInt = myList[0];
        for (int i = 1; i < myList.Count; i++)
        {
            if (myList[i] > maxInt)
                maxInt = myList[i];
        }
        return maxInt;
    }
}
