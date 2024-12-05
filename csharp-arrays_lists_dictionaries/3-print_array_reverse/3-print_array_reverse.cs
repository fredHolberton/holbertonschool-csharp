using System;

class Array
{
    public static void Reverse(int[] array)
    {
        if (array == null)
        {
            Console.WriteLine("");
        }
        else if (array.Length == 0)
        {
            Console.WriteLine("");
        }
        else
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (i > 0)
                    Console.Write("{0} ", array[i]);
                else
                    Console.Write("{0}\n", array[i]);
            }
        }
    }
}