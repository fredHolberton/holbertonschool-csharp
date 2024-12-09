using System;
using System.Collections.Generic;

class MyStack
{
    public static Stack<string> Info(Stack<string> aStack, string newItem, string search)
    {
        int numberOfItems = aStack.Count;
        Console.WriteLine("Number of items: {0}", numberOfItems);
        if (aStack.Count > 0)
            Console.WriteLine("Top item: {0}", aStack.Peek());
        else
            Console.WriteLine("Stack is empty");

        Console.WriteLine("Stack contains \"{0}\": {1}", search, aStack.Contains(search));

        if (aStack.Contains(search))
        {
            while (aStack.Contains(search))
                aStack.Pop();
        }

        aStack.Push(newItem);
        return aStack;

    }
}
