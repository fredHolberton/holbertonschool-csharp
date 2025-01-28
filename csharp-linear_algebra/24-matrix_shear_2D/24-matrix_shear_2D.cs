using System;

/// <summary>
/// Public class MatrixMath for manipulating matrix.
/// </summary>
public class MatrixMath
{
    /// <summary>
    ///  shears a square 2D matrix by a given shear factor and returns the resulting matrix.
    /// </summary>
    public static double[,] Shear2D(double[,] matrix, char direction, double factor)
    {
         if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
            return new double[,] { {-1} };

        if (direction != 'x' && direction != 'y')
            return new double[,] { {-1} };

        double[,] result = new double[,] { {0, 0}, {0, 0} };

        for (int i = 0; i < 2; i++)
        {
            if (direction == 'x')
            {
                result[i, 0] = matrix[i, 0] + (matrix[i, 1] * factor);
                result[i, 1] = matrix[i, 1];
            }                  
            else
            {
                result[i, 0] = matrix[i, 0];
                result[i, 1] = matrix[i, 1] + (matrix[i, 0] * factor);
            }
        }

        return result;
    }
}
