using System;
using System.Collections.Generic;

class MyQueue
{
    public static Queue<string> Info(Queue<string> aQueue, string newItem, string search)
    {
        int numberOfItems = aQueue.Count;
        Console.WriteLine("Number of items: {0}", numberOfItems);
        if (numberOfItems > 0)
            Console.WriteLine("First item: {0}", aQueue.Peek());
        else
            Console.WriteLine("Queue is empty");

        aQueue.Enqueue(newItem);

        Console.WriteLine("Queue contains \"{0}\": {1}", search, aQueue.Contains(search));

        while (aQueue.Contains(search))
                aQueue.Dequeue();
        
        return aQueue;

    }
}
