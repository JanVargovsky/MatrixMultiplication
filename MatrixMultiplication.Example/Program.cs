using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MatrixMultiplication.Example
{
    class Result
    {
        public String TestName { get; set; }
        public IList<double> Times1 { get; set; }
        public IList<double> Times2 { get; set; }
        public Result(String name)
        {
            TestName = name;
            Times1 = new List<double>();
            Times2 = new List<double>();
        }
    }

    class Program
    {
        static Matrix CreateMatrix(double[,] v)
        {
            Matrix m = new Matrix(v.GetLength(0), v.GetLength(1));
            for (int row = 0; row < m.Rows; row++)
                for (int col = 0; col < m.Columns; col++)
                    m[row, col] = v[row, col];
            return m;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter maximum size of matrix to multiply");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter count of reiteration");
            int numberOfTests = int.Parse(Console.ReadLine());
            var results = new List<Result>();

            for (int i = 1; i <= N; i *= 2)
            {
                Result r = new Result(i.ToString());
                for (int n = 0; n < numberOfTests; n++)
                {
                    Console.Clear();
                    Console.WriteLine("Testing {0} for {1}/{2} times.", i, n, numberOfTests);
                    var a = MatrixGenerator.Generate(i);
                    var b = MatrixGenerator.Generate(i);

                    Stopwatch t1 = Stopwatch.StartNew();
                    var normal = Matrix.NormalMultiply(a, b);
                    t1.Stop();

                    Stopwatch t2 = Stopwatch.StartNew();
                    var strassen = Matrix.StrassenMultiply(a, b);
                    t2.Stop();

                    r.Times1.Add(t1.Elapsed.TotalMilliseconds);
                    r.Times2.Add(t2.Elapsed.TotalMilliseconds);
                }
                results.Add(r);
            }
            Console.Clear();

            string consoleFormat = "{0} \t {1:N4}ms \t {2:N4}ms";
            WriteResults(Console.Out, results, consoleFormat, "Size \t Normal \t Straussen");

            string fileFormat = "{0};{1};{2}";
            SaveResultsToCSV(results, fileFormat, "Size of matrix;Normal multiply;Straussen multiply", "results.txt");
            Console.ReadKey();
        }

        static void WriteResults(TextWriter output, IEnumerable<Result> results, string format, string header = null)
        {
            if (header != null)
                output.WriteLine(header);

            foreach (var r in results)
            {
                var avg1 = r.Times1.Average();
                var avg2 = r.Times2.Average();
                output.WriteLine(format, r.TestName, avg1, avg2);
            }
        }

        static void SaveResultsToCSV(IEnumerable<Result> results, string format, string header, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
                WriteResults(sw, results, format, header);
        }
    }
}


