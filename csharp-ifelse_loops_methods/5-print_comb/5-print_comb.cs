using System;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 100; i++)
        {
            if (i < 99)
            {
                Console.Write("{0}, ", i.ToString("00"));
            }
            else
            {
                Console.Write("{0}", i.ToString("00"));
            }
        }
    }
}
