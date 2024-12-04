using System;

class Line
{
    public static void PrintLine(int length)
    {
        for (int i = 1; i <= length; i++)
        {
            Console.Write("_");
        }
        Console.Write("\n");
    }
}