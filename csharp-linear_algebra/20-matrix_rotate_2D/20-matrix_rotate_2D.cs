using System;

/// <summary>
/// Public class MatrixMath for manipulating matrix.
/// </summary>
public class MatrixMath
{
    /// <summary>
    /// rotates a square 2D matrix by a given angle in radians 
    /// and returns the resulting matrix.
    /// </summary>
    public static double[,] Rotate2D(double[,] matrix, double angle)
    {
        if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
            return new double[,] { {-1} };

        double[,] rotateMatrix = new double[,] { {Math.Cos(angle), -1 * Math.Sin(angle) }, { Math.Sin(angle), Math.Cos(angle) } };
        double[,] result = Multiply(rotateMatrix, matrix);
        result[0, 0] = Math.Round(result[0, 0], 2);
        result[0, 1] = Math.Round(result[0, 1], 2);
        result[1, 0] = Math.Round(result[1, 0], 2);
        result[1, 1] = Math.Round(result[1, 1], 2);

        return result;
    }

    /// <summary>
    /// multiplies two matrices and returns the resulting matrix.
    /// </summary>
    public static double[,] Multiply(double[,] matrix1, double[,] matrix2)
    {
        if (matrix1.GetLength(1) != matrix2.GetLength(0))
            return new double[,] { {-1} };

        double[,] result = new double[matrix1.GetLength(0), matrix2.GetLength(1)];

        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(1); j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < matrix1.GetLength(1); k++)
                {
                    result[i, j] = result[i, j] + (matrix1[i, k] * matrix2[k, j]);
                }
            }
        }

        return result;
    }


}
