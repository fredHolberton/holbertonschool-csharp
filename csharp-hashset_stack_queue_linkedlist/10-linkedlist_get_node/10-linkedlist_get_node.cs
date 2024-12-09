using System;
using System.Collections.Generic;

class LList
{
   public static int GetNode(LinkedList<int> myLList, int n)
   {
        
        int searchedItem = 0;
        int i = -1;
        foreach (int item in myLList)
        {
            i++;
            if (i == n)
            {
                searchedItem = item;
                break;
            }           
        }
              
        return searchedItem;
   } 
}
