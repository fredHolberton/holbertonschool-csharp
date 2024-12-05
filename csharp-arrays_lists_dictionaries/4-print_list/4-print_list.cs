using System;
using System.Collections.Generic;

class List
{
    public static List<int> CreatePrint(int size)
    {
        // Cas d'erreur : Si size est négatif
        if (size < 0)
        {
            Console.WriteLine("Size cannot be negative");
            return null;
        }
        // cas standard : size est positif. 
        // Si size est = à 0, on ne rentre pas dans la boucle for
        List<int> newList = new List<int>();
        for (int i = 0; i < size; i++)
        {
            newList.Add(i);
            if (i < size - 1)
                Console.Write("{0} ", i);
            else
                Console.Write("{0}", i);
        }
        Console.Write("\n");
        return newList;
    }
}
