using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Forms.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthClassLibrary;
using NorthClassLibrary.Classes;
using SortLibrary;
using UtilityTestProject.Classes;

namespace UtilityTestProject
{
    [TestClass]
    public class UnitTest1 : BaseClass
    {
        /// <summary>
        /// Modify five records using UpdateRange.
        /// Add a 1 to the end of each customer name,
        /// assert update succeeded, remove the 1.
        ///
        /// If a DbUpdateConcurrencyException (concurrency conflicts) is thrown
        /// in this case each entry is reloaded from the database.
        /// </summary>
        /// <returns>N/A</returns>
        [TestMethod,
         TestTraits(Trait.ModifyingRecords)]
        public async Task UpdateRange()
        {
            var topFiveCustomers = await CustomerOperations.SelectTopFiveCustomersAsync();

            for (int index = 0; index < topFiveCustomers.Count; index++)
            {
                topFiveCustomers[index].CompanyName += "1";
            }

            var success = await CustomerOperations.UpdateWithConcurrency(topFiveCustomers); 

            Assert.IsTrue(success);

            for (int index = 0; index < topFiveCustomers.Count; index++)
            {
                var name = topFiveCustomers[index].CompanyName;
                topFiveCustomers[index].CompanyName = name.Remove(name.Length - 1,1);
            }

            await CustomerOperations.UpdateWithConcurrency(topFiveCustomers);

        }

        [TestMethod,
         TestTraits(Trait.ApplicationConfiguration)]
        public void EntityExistsTest() 
        {

        }

        /// <summary>
        /// Valid non-existing keys can be known
        /// </summary>
        [TestMethod, 
         TestTraits(Trait.ApplicationConfiguration)]
        public void KeyExistsAppConfiguration()
        {
            // key exists
            Assert.IsTrue(AssemblyHelpers.KeyExists("SortDirection"));
            // key does not exists
            Assert.IsFalse(AssemblyHelpers.KeyExists("SortDire"));
        }
        /// <summary>
        /// Validate manipulation of configuration settings works
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.ApplicationConfiguration)]
        public void ChangeSortDirectionAppConfiguration()
        {
            Assert.IsTrue(AssemblyHelpers.GetSortDirection() == "Descending");
            AssemblyHelpers.SetSortDirection("Ascending");
            Assert.IsTrue(AssemblyHelpers.GetSortDirection() == "Ascending");
            AssemblyHelpers.SetSortDirection("Descending");
            Console.WriteLine("Done");
        }

        [TestMethod]
        [TestTraits(Trait.DynamicSortByPropertyName)]
        public async Task SortCustomerByCompanyNameDescending()
        {
            var customerItems = await CustomerOperations.CustomerSort(
                "CompanyName", SortDirection.Descending);

            Assert.AreEqual(customerItems.FirstOrDefault()?.CompanyName, 
                "Wolski  Zajazd",
                $"{TestContextInstance.TestName} failed");

        }
        [TestMethod]
        [TestTraits(Trait.DynamicSortByPropertyName)]
        public async Task SortCustomerByCompanyNameAscending()
        {
            var customerItems = await CustomerOperations.CustomerSort(
                "CompanyName");

            Assert.AreEqual(customerItems.FirstOrDefault()?.CompanyName, 
                "Alfreds Futterkiste", 
                $"{TestContextInstance.TestName} failed");

        }
        [TestMethod]
        [TestTraits(Trait.DynamicSortByPropertyName)]
        public async Task SortCustomerByCountryNameAscending()
        {
            var customerItems = await CustomerOperations.CustomerSort(
                "CountryName");

            Assert.AreEqual(customerItems.FirstOrDefault()?.CountryName, 
                "Argentina",
                $"{TestContextInstance.TestName} failed");

        }
    }
}
