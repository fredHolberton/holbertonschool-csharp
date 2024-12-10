using System;
using System.Collections.Generic;

class LList
{
   public static void Delete(LinkedList<int> myLList, int index)
   {
        int i = 0;

        if (myLList.First != null)
        {
            LinkedListNode<int> current = myLList.First;
            if (i == index)
            {
                myLList.Remove(current);
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                    i++;
                    if (i == index)
                    {
                        myLList.Remove(current);
                        break;
                    }
                }
            }
            
        }
   } 
}
