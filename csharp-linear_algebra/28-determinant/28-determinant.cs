using System;

/// <summary>
/// Public class MatrixMath for manipulating matrix.
/// </summary>
public class MatrixMath
{
    /// <summary>
    ///  calculates the determinant of a matrix 2x2 or 3x3.
    /// </summary>
    public static double Determinant(double[,] matrix)
    {
         if (matrix.GetLength(0) < 2 || matrix.GetLength(0) > 3 ||matrix.GetLength(1) < 2 || matrix.GetLength(1) > 3 || matrix.GetLength(0) != matrix.GetLength(1))
            return -1;

        double result;
        if (matrix.GetLength(0) == 2)
            result = (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
        else
        {
            result = matrix[0, 0] * matrix[1, 1] * matrix[2, 2];
            result = result + (matrix[1, 0] * matrix[2, 1] * matrix[0, 2]);
            result = result + (matrix[0, 1] * matrix[1, 2] * matrix[2, 0]);
            result = result - (matrix[2, 0] * matrix[1, 1] * matrix[0, 2]);
            result = result - (matrix[1, 0] * matrix[0, 1] * matrix[2, 2]);
            result = result - (matrix [0, 0] * matrix[2, 1] * matrix[1, 2]);
        }

        return result;
    }
}
