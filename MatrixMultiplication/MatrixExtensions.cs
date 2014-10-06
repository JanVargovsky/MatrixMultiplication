using System.IO;

namespace MatrixMultiplication
{
    public static class MatrixExtensions
    {
        public static void Write(this Matrix m, TextWriter output, int elemSize = 3, bool showPlus = true)
        {
            for (int row = 0; row < m.Rows; row++)
            {
                for (int col = 0; col < m.Columns; col++)
                {
                    output.Write(m[row, col].ToString().PadRight(elemSize));
                }
                output.WriteLine();
            }
            output.WriteLine();
        }
    }
}
