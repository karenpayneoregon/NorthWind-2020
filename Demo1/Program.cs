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
            await CustomersDuplicateFinder.GetCustomerEntities();
            var customers = await CustomersDuplicateFinder.GetDuplicates();

            if (customers.Count >0)
            {
#if DEBUG
                var originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"There are {customers.Count} duplicates");
                Console.ForegroundColor = originalColor;

                foreach (var customerEntity in customers)
                {
                    Console.WriteLine($"{customerEntity.CustomerIdentifier,3}, {customerEntity.CompanyName}");
                }
#endif


            }
            else
            {
                Console.WriteLine("No duplicates");
            }

            Console.ReadLine();
        }
    }
}
