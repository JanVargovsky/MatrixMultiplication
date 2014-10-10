using System.IO;

namespace MatrixMultiplication
{
    public static class MatrixExtensions
    {
        public static void Write(this Matrix matrix, TextWriter output, int elemSize = 3, bool showPlus = true)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Columns; col++)
                {
                    output.Write(matrix[row, col].ToString().PadRight(elemSize));
                }
                output.WriteLine();
            }
        }
    }
}
