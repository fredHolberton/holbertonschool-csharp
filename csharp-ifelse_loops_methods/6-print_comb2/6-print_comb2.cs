﻿using System;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = i + 1; j < 10; j++)
            {
                if (i < 8)
                {
                    Console.Write("{0}{1}, ", i, j);
                }
                else
                {
                    Console.Write("{0}{1}\n", i, j);
                }        
            }
        }
    }
}