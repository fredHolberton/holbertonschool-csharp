using System;

class Array
{
    public static int[] CreatePrint(int size)
    {
        if (size < 0)
        {
            Console.WriteLine("Size cannot be negative");
            return null;
        }
        int[] newArray = new int[size];
        if (size == 0)
        {
            Console.Write("\n");
        }
        else
        {
            for (int i = 0; i < size; i++)
            {
                newArray[i] = i;
                if (i < size - 1)
                {
                    Console.Write("{0} ", i);
                }
                else
                {
                    Console.Write("{0}\n", i);
                }
            }
        }
        return newArray;
    }
}
