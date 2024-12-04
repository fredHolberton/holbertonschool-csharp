using System;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 99; i++)
        {
            Console.Write("{0} = 0x{1}\n", i, i.ToString("x"));
        }
    }
}