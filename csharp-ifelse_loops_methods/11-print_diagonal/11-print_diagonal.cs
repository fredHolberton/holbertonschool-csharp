using System;

class Line
{
    public static void PrintDiagonal(int length)
    {
        for (int i = 1; i <= length ; i++)
        {
            for (int j = 1; j < i; j++)
            {
                Console.Write(" ");
            }
            Console.Write("{0}\n", "\\");
        }
        Console.Write("\n");
    }
}
