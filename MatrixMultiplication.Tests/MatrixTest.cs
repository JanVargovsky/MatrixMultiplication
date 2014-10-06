using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplication.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MatrixTest
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void NormalMultiplyWithMatrix()
        {
            Matrix m1 = new Matrix(new double[,]
                {
                    {1,2,0},
                    {-1,2,3},
                    {0,1,1}
                });
            Matrix m2 = new Matrix(new double[,]
                {
                    {1,2},
                    {0,1},
                    {-1,0}
                });
            Matrix expected = new Matrix(new double[,]
                {
                    {1,4},
                    {-4,0},
                    {-1,1}
                });
            Matrix actual = Matrix.NormalMultiply(m1, m2);

            Assert.AreEqual(expected, actual);
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void NormalMultiplyWithIdentityMatrix()
        {
            Matrix m1 = new Matrix(new double[,]
                {
                    {1,2,3},
                    {4,5,6},
                    {7,8,9}
                });
            Matrix m2 = MatrixGenerator.IdentityMatrix(3);
            Matrix expected = new Matrix(new double[,]
                {
                    {1,2,3},
                    {4,5,6},
                    {7,8,9}
                });
            Matrix actual = Matrix.NormalMultiply(m1, m2);

            Assert.AreEqual(expected, actual);
        }
    }
}
