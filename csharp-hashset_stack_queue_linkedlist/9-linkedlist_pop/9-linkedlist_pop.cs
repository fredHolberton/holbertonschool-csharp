using System;
using System.Collections.Generic;

class LList
{
   public static int Pop(LinkedList<int> myLList)
   {   
        int firstNodeValue = 0;
        LinkedListNode<int> firstNode;
        if (myLList.First != null)
        {
            firstNode = myLList.First;
            firstNodeValue = firstNode.Value;
            myLList.RemoveFirst();
        }
                             
        return firstNodeValue;
   } 
}
