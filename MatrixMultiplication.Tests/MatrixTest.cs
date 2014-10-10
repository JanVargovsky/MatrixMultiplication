using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixMultiplication.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MatrixTest
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void NormalMultiplyWithMatrix()
        {
            Matrix a = new Matrix(new double[,]
                {
                    {1,2,0},
                    {-1,2,3},
                    {0,1,1}
                });
            Matrix b = new Matrix(new double[,]
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
            Matrix actual = Matrix.NormalMultiply(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void NormalMultiplyWithIdentityMatrix()
        {
            Matrix a = new Matrix(new double[,]
                {
                    {1,2,3},
                    {4,5,6},
                    {7,8,9}
                });
            Matrix b = MatrixGenerator.IdentityMatrix(3);
            Matrix expected = new Matrix(new double[,]
                {
                    {1,2,3},
                    {4,5,6},
                    {7,8,9}
                });
            Matrix actual = Matrix.NormalMultiply(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void StrassenMultiplyWithMatrix1()
        {
            Matrix a = new Matrix(new double[,]
                {
                    {1,2},
                    {1,2}
                });
            Matrix b = new Matrix(new double[,]
                {
                    {1,2},
                    {1,2}
                });
            Matrix expected = new Matrix(new double[,]
                {
                    {3,6},
                    {3,6}
                });
            Matrix actual = Matrix.StrassenMultiply(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void StrassenMultiplyWithMatrix2()
        {
            Matrix a = new Matrix(new double[,]
                {
                    {1,2,3,4},
                    {1,2,3,4},
                    {1,2,3,4},
                    {1,2,3,4}
                });
            Matrix b = new Matrix(new double[,]
                {
                    {1,2,3,4},
                    {1,2,3,4},
                    {1,2,3,4},
                    {1,2,3,4}
                });
            Matrix expected = new Matrix(new double[,]
                {
                    {10,20,30,40},
                    {10,20,30,40},
                    {10,20,30,40},
                    {10,20,30,40}
                });
            Matrix actual = Matrix.StrassenMultiply(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}
