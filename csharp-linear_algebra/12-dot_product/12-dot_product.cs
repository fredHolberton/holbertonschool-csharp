using System;

/// <summary>
/// Public class VectorMath for manipulating vectors.
/// </summary>
public class VectorMath
{
    /// <summary>
    /// calculates dot product of either two 2D or two 3D vectors.
    /// </summary>
    public static double DotProduct(double[] vector1, double[] vector2)
    {
        if ((vector1.Length < 2 || vector1.Length > 3 || vector2.Length < 2 || vector2.Length > 3) || (vector1.Length != vector2.Length))
            return -1;

        double result = 0;   

        for (int i = 0; i < vector1.Length; i++)
        {
            result = result + (vector1[i] * vector2[i]);
        }

        return result;
    }
}

