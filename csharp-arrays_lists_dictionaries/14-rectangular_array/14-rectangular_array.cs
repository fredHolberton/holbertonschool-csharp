using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[,] array = new int[5,5];

        // initialize array
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == 2 && j == 2)
                    array[i,j] = 1;
                else
                    array[i,j] = 0;
            }
       }

        // print array
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (j < 4)
                    Console.Write("{0} ", array[i, j]);
                else
                    Console.Write("{0}", array[i, j]);
            }
             Console.Write("\n");
        }
    }
}
