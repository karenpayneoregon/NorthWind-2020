using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthEntityLibrary.Classes;

namespace Demo1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var customers = await CustomersDuplicateFinder.GetDuplicates();

            if (customers.Count >0)
            {
                Console.WriteLine($"There are {customers.Count} duplicates");
            }
            else
            {
                Console.WriteLine("No duplicates");
            }

            Console.ReadLine();
        }
    }
}
