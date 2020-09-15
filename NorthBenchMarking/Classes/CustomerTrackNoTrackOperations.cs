using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;
using NorthClassLibrary.Contexts;
using NorthClassLibrary.Models;

namespace NorthBenchMarking.Classes
{

    /// <summary>
    /// Test between with and without tracking.
    /// </summary>
    /// <remarks>
    /// For a better test there should be more than 1,000 records
    /// </remarks>
    [MediumRunJob]
    [KeepBenchmarkFiles]
    [HtmlExporter]
    public class CustomerTrackNoTrackOperations
    {
        [Benchmark]
        public List<Customers> GetCustomersWithNoTracking()
        {
            using (var context = new NorthwindContext())
            {
                return context
                    .Customers
                    .AsNoTracking()
                    .Include(customer => customer.ContactTypeIdentifierNavigation)
                    .ToList();
            }
        }
        [Benchmark]
        public List<Customers> GetCustomersWithTracking()
        {
            using (var context = new NorthwindContext())
            {
                return context
                    .Customers
                    .Include(customer => customer.ContactTypeIdentifierNavigation)
                    .ToList();
            }
        }
    }
}
