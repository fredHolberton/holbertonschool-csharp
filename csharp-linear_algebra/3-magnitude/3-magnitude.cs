using System;

/// <summary>Public class VectorMath for manipulating vectors.</summary>
public class VectorMath
{
    /// <summary>calculates and returns the length of a given vector.
    /// </summary>
    public static double Magnitude(double[] vector)
    {
        if ((vector == NULL) || (vector.Length == 0))
            return -1;
        if (vector.Length < 2 || vector.Length > 3)
            return -1;
            
        double result = 0;
        foreach (double v in vector)
        {
            result += v * v;
        }
        result = Math.Sqrt(result);
        return Math.Round(result, 2);
    }
}
