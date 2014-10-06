using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplication.Example
{
    class Program
    {
        static Matrix CreateMatrix(double[,] v)
        {
            Matrix m = new Matrix(v.GetLength(0), v.GetLength(1));
            for (int row = 0; row < m.Rows; row++)
                for (int col = 0; col < m.Columns; col++)
                    m[row, col] = v[row,col];
            return m;
        }

        static void Main(string[] args)
        {
            double[,] values1 = new double[,]
            {
                {1,2,0},
                {-1,2,3},
                {0,1,1}
            };
            double[,] values2 = new double[,]
            {
                {1,2},
                {0,1},
                {-1,0 }
            };
            var m1 = CreateMatrix(values1);
            var m2 = CreateMatrix(values2);
            var m3 = MatrixGenerator.IdentityMatrix(3);
            
            //var m1 = MatrixGenerator.Generate(2);
            //var m2 = MatrixGenerator.Generate(1,2, 1, 2);

            var m1m2 = Matrix.NormalMultiply(m1, m2);
            Matrix.NormalMultiply(m3, m2).Write(Console.Out);


            //m1.Write(Console.Out);
            //m2.Write(Console.Out);
            //m1m2.Write(Console.Out);
        }
    }
}
