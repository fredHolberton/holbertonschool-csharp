﻿using System;

class Program
{
    static void Main(string[] args)
    {
        string alphabet = string.Empty;
        for (int i = 0; i < 26; i++)
        {
            if (Convert.ToChar(i + 97) != 'q' && Convert.ToChar(i + 97) != 'e')
            {
                alphabet = String.Concat(alphabet, Convert.ToChar(i + 97));
            }
        }
        Console.Write(alphabet);
    }
}