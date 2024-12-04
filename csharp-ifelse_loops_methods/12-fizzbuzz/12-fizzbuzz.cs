using System;

class ExecutePrintDiagonal
{
    static void Main(string[] args)
    {
        for (int i = 1; i <= 100; i++)
        {
            if ((i % 3 == 0) || (i % 5 == 0))
            {
                if (i % 3 ==0)
                    Console.Write("Fizz");
                if (i % 5 ==0)
                    Console.Write("Buzz");
            }
            else
            {
                Console.Write("{0}", i);
            }
            if (i < 100)
                Console.Write(" "); 
            else
                Console.Write("\n"); 
        }
    }
}