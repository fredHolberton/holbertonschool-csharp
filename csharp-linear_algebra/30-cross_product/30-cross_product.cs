using System;

/// <summary>
/// Public class VectorMath for manipulating vectors.
/// </summary>
public class VectorMath
{
    /// <summary>
    /// calculates the cross product of two 3D vectors and returns the resulting vector.
    /// </summary>
    public static double[] CrossProduct(double[] vector1, double[] vector2)
    {
        if ((vector1.Length != 3 || vector2.Length != 3))
            return -1;

        double[] result = new double[3]{0, 0, 0}; 
        
        result[0] = vector1[1] * vector2[2] - vector1[2] * vector2[1];
        result[1] = vector1[2] * vector2[0] - vector1[0] * vector2[2];
        result[2] = vector1[0] * vector2[1] - vector1[1] * vector2[0];

        return result;
    }
}
