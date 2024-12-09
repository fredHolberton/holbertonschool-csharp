using System;
using System.Collections.Generic;

class LList
{
   public static int Sum(LinkedList<int> myLList)
   {
        
        int sumItem = 0;
        foreach (int item in myLList)
        {
            sumItem+=item;         
        }
              
        return sumItem;
   } 
}
