﻿using System;

class Program
{
    static void Main(string[] args)
    {
        int[][] jaggedArray = new int[3][];
        
        jaggedArray[0] = new int[] {0, 1, 2, 3};
        jaggedArray[1] = new int[] {0, 1, 2, 3, 4, 5, 6};
        jaggedArray[2] = new int[] {0, 1};
 
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write("{0}{1}", jaggedArray[i][j], j < (jaggedArray[i].Length - 1) ? " " : "");
            }
            Console.WriteLine();
        }
    }
}