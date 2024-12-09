using System;
using System.Collections.Generic;

class LList
{
   public static void Delete(LinkedList<int> myLList, int index)
   {
        
        int searchedItem = 0;
        int i = -1;
        foreach (int item in myLList)
        {
            i++;
            if (i == index)
            {
                myLList.Remove(item);
                break;
            }           
        } 
   } 
}
