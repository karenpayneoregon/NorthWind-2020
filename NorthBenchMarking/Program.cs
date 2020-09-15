using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using NorthBenchMarking.Classes;

namespace NorthBenchMarking
{
    /// <summary>
    /// Note under pre-build events the folder BenchmarkDotNet.Artifacts
    /// is removed.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benching...");
            var summary = BenchmarkRunner.Run(typeof(CustomerTrackNoTrackOperations));
            if (summary.HasCriticalValidationErrors)
            {
                Console.WriteLine("has errors");
                Console.ReadLine();
            }
        }
    }
}
