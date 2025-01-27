using System;

/// <summary>Public class VectorMath for manipulating vectors.</summary>
public class VectorMath
{
    /// <summary>calculates and returns the length of a given vector.
    /// </summary>
    public static double Magnitude(double[] vector)
    {
        double result = 0;
        foreach (double v in vector)
        {
            result += v * 2;
        }
        return Math.Sqrt(result);
    }
}
