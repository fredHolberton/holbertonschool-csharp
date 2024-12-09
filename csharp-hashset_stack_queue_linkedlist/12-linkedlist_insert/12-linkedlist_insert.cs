using System;
using System.Collections.Generic;

class LList
{
   public static LinkedListNode<int> Insert(LinkedList<int> myLList, int n)
   {
        LinkedListNode<int> current;
        
        if (myLList.First != null)
        {          
            current = myLList.First;

            while (current != null)
            {
                if (current.Value >= n)
                {
                    current = myLList.AddBefore(current, n);
                    break;
                }
                if (current.Next != null)
                    current = current.Next;
            }
            
            if (current == null)
            current = myLList.AddLast(n);
        }
        else
            current = myLList.AddLast(n);

        return current;

   } 
}
