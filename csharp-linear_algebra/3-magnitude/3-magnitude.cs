using System;

/// <summary>
/// Public class VectorMath for manipulating vectors.
/// </summary>
public class VectorMath
{
    /// <summary>
    /// calculates and returns the length of a given vector.
    /// </summary>
    public static double Magnitude(double[] vector)
    {
        double result = 0;

        if (vector.Length < 2 || vector.Length > 3)
            return -1;

        if (vector.Length == 2)
            result = Math.Sqrt((vector[0] * vector[0]) + (vector[1] * vector[1]));
        else
            result = Math.Sqrt((vector[0] * vector[0]) + (vector[1] * vector[1]) + (vector[2] * vector[2]));
        
        return Math.Round(result, 2);
    }
}
