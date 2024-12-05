using System;
using System.Collections.Generic;

class List
{
    public static List<int> DeleteAt(List<int> myList, int index)
    {
        // cas d'erreur : L'index est négatif ou supérieur au nombre d'éléments de la liste
        if (index < 0 || index >= myList.Count)
        {
            Console.WriteLine("Index is out of range");
            return myList;
        }
        
        for (int i = 0; i < myList.Count; i++)
        {
            if (i == index)
            {
                myList.Remove(myList[i]);
                i++;
            }
        }
        return myList;
    }
}
