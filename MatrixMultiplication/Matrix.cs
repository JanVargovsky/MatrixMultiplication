using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplication
{
    public sealed class Matrix
    {
        #region Private variables and fields
        public int Rows
        {
            get
            {
                return values.GetLength(0);
            }
        }
        public int Columns
        {
            get
            {
                return values.GetLength(1);
            }
        }

        private double[,] values;
        public double this[int row, int col]
        {
            get
            {
                return values[row, col];
            }
            set
            {
                values[row, col] = value;
            }
        }
        #endregion

        #region Constructors
        public Matrix(int m, int n)
        {
            if (m <= 0)
                throw new ArgumentOutOfRangeException("m is less than or equal to zero.");
            if (n <= 0)
                throw new ArgumentOutOfRangeException("n is less than or equal to zero.");

            values = new double[m, n];
        }

        public Matrix(int m) : this(m, m) { }

        public Matrix(double[,] values)
        {
            if (values == null)
                throw new ArgumentNullException("values == null.");

            this.values = values;
        }
        #endregion

        public override bool Equals(object obj)
        {
            Matrix m1 = this, m2 = (Matrix)obj;

            if (m2 == null)
                return false;
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                return false;

            for (int row = 0; row < m1.Rows; row++)
                for (int col = 0; col < m1.Columns; col++)
                    if (m1[row, col] != m2[row, col]) return false;

            return true;
        }

        public static Matrix NormalMultiply(Matrix m1, Matrix m2)
        {
            if (m1.Columns != m2.Rows)
                throw new ArgumentException("Number of rows of the m1 doesnt equal to number of columns of the m2.");

            Matrix result = new Matrix(m1.Rows, m2.Columns);

            for (int row = 0; row < m1.Rows; row++)
            {
                for (int col = 0; col < m2.Columns; col++)
                {
                    double tmp = 0;

                    for (int i = 0; i < m1.Columns; i++) // or i < m2.Rows, it's equal
                        tmp += m1[row, i] * m2[i, col];

                    result[row, col] = tmp;
                }
            }

            return result;
        }
    }
}
