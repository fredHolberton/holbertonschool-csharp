using System;
using System.Collections.Generic;

class LList
{
   public static int Length(LinkedList<int> myLList)
   {
        int numberOfItem = 0;

        for (LinkedListNode<int> node = myLList.First; node != null; node=node.Next)
        {
            numberOfItem++;
        }
        
        return numberOfItem;
   } 
}
