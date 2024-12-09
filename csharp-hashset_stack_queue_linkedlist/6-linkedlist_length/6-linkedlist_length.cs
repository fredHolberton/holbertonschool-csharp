using System;
using System.Collections.Generic;

class LList
{
   public static int Length(LinkedList<int> myLList)
   {
        int numberOfItem = 0;

        foreach (int item in myLList)
            numberOfItem++;  
        
        return numberOfItem;
   } 
}
