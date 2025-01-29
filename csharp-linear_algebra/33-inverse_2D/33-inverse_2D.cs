using System;

/// <summary>
/// Public class MatrixMath for manipulating matrix.
/// </summary>
public class MatrixMath
{
    /// <summary>
    ///  calculates the inverse of a 2D matrix and returns the resulting matrix.
    /// </summary>
    public static double[,] Inverse2D(double[,] matrix)
    {
         if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
            return new double[,] { {-1} };

        double[,] result = new double[,] { {0, 0}, {0, 0} };
        double determinant = (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);

        if (determinant == 0)
            return new double[,] { {-1} };
        
        result[0, 0] = Math.Round(matrix[1, 1] / determinant, 2);
        result[1, 1] = Math.Round(matrix[0, 0] / determinant, 2);
        result[0, 1] = Math.Round(matrix[0, 1] / determinant * (-1), 2);
        result[1, 0] = Math.Round(matrix[1, 0] / determinant * (-1), 2);

        return result;
    }
}

