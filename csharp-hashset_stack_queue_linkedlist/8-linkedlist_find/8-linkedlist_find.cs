using System;
using System.Collections.Generic;

class LList
{
   public static int FindNode(LinkedList<int> myLList, int value)
   {
        int foundItem = -1;
        int i = -1;
        foreach (int item in myLList)
        {
            i++;
            if (item == value)
            {
                foundItem = i;
                break;
            }           
        }
              
        return foundItem;
   } 
}
