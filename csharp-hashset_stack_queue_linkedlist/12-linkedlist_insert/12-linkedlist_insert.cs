using System;
using System.Collections.Generic;

class LList
{
   public static LinkedListNode<int> Insert(LinkedList<int> myLList, int n)
   {
        LinkedListNode<int> current;
        LinkedListNode<int> newNode = new LinkedListNode<int>(n);
        
        if (myLList.First != null)
        {          
            current = myLList.First;

            while (current != null)
            {
                if (current.Value >= n)
                {
                    newNode = myLList.AddBefore(current, n);
                    break;
                }
                if (current.Next != null)
                    current = current.Next;
                
            }
            
            if (current == null)
                newNode = myLList.AddLast(n);
        }
        else
            newNode = myLList.AddLast(n);

        return newNode;

   } 
}
