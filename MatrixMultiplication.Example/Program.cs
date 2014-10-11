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
        static void Main(string[] args)
        {
            Console.WriteLine("Enter maximum size of matrix to multiply");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter count of reiteration");
            int numberOfTests = int.Parse(Console.ReadLine());

            var results = new List<Result>();
            var start = DateTime.Now;

            for (int i = 1; i <= N; i *= 2)
            {
                Result r = new Result(i.ToString());
                for (int n = 1; n <= numberOfTests; n++)
                {
                    Console.WriteLine("Testing {0} for {1}/{2} times.", i, n, numberOfTests);

                    var a = MatrixGenerator.Generate(i);
                    var b = MatrixGenerator.Generate(i);

                    Stopwatch t1 = Stopwatch.StartNew();
                    var normal = Matrix.NormalMultiply(a, b);
                    t1.Stop();

                    Stopwatch t2 = Stopwatch.StartNew();
                    var strassen = Matrix.StrassenMultiply(a, b);
                    t2.Stop();

                    r.Times1.Add(t1.Elapsed.TotalSeconds);
                    r.Times2.Add(t2.Elapsed.TotalSeconds);
                }
                results.Add(r);
            }

            string consoleFormat = "{0}\t{1:N6}s\t{2:N6}s";
            WriteResults(Console.Out, results, consoleFormat, "Size \t Normal \t Straussen");
            Console.WriteLine(Environment.NewLine + "Total time " + (DateTime.Now - start).ToString());
            string fileFormat = "{0};{1:N6};{2:N6}";
            string fileName = string.Format("results_{0}_{1}_{2}.csv", N, numberOfTests, DateTime.Now.ToFileTime());
            SaveResultsToCSV(results, fileFormat, "Size of matrix;Normal multiply;Straussen multiply", fileName);
            Console.ReadKey();
        }

        static void WriteResults(TextWriter output, IEnumerable<Result> results, string format, string header = null)
        {
            if (header != null)
                output.WriteLine(header);

            foreach (var r in results)
            {
                double avg1 = r.Times1.Average();
                double avg2 = r.Times2.Average();
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


