using System;
using System.Collections.Generic;
using System.IO;
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
        /// <remarks>
        /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.updaterange?view=efcore-3.1
        /// </remarks>
        [TestMethod,
         TestTraits(Trait.ModifyingRecords)]
        public async Task UpdateRangeTask()
        {
            var topFiveCustomers = await CustomerOperations.SelectTopFiveCustomersAsync();

            for (int index = 0; index < topFiveCustomers.Count; index++)
            {
                topFiveCustomers[index].CompanyName += "1";
            }

            var success = await CustomerOperations.UpdateRange(topFiveCustomers); 

            Assert.IsTrue(success);

            for (int index = 0; index < topFiveCustomers.Count; index++)
            {
                var name = topFiveCustomers[index].CompanyName;
                topFiveCustomers[index].CompanyName = name.Remove(name.Length - 1,1);
            }

            await CustomerOperations.UpdateRange(topFiveCustomers);

        }

        [TestMethod,
         TestTraits(Trait.Find)]
        public async Task FindSimpleTask()
        {
            var customer = await CustomerOperations.FindCustomersAsync(new object[] { 3 });
            Assert.AreEqual(customer.CompanyName, "Antonio Moreno Taquería");
        }

        /// <summary>
        /// Find with navigation(s) and without navigation properties
        /// </summary>
        /// <returns></returns>
        [TestMethod,
         TestTraits(Trait.Find)]
        public async Task FindWithIncludesTask()
        {
            // specify which navigation properties to include
            var customer = await CustomerOperations.Get(3, new[]
            {
                "CountryIdentifierNavigation",
                "ContactTypeIdentifierNavigation"
            });

            Assert.IsTrue(
                customer.CountryIdentifierNavigation != null && 
                customer.ContactTypeIdentifierNavigation != null);

            // get customer w/o any navigation properties
            customer = await CustomerOperations.Get(3);
            Assert.AreEqual(customer.CompanyName, "Antonio Moreno Taquería");

            // get customer with all navigation properties
            customer = await CustomerOperations.GetWithAllNavigationProperties(3);
            Assert.IsTrue(
                customer.CountryIdentifierNavigation != null &&
                customer.ContactTypeIdentifierNavigation != null & 
                customer.Orders != null && 
                customer.Contact != null);


        }
        /// <summary>
        /// Test generic FindAsync for Customers
        /// </summary>
        /// <returns></returns>
        [TestMethod,
         TestTraits(Trait.Find)]
        public async Task GenericCustomersFindTask()
        {
            var customer = await CustomerOperations.GenericRepositoryFindAsync();
            Assert.AreEqual(customer.CompanyName, "Antonio Moreno Taquería");
        }
        /// <summary>
        /// Test generic FindAsync for Employee
        /// </summary>
        /// <returns></returns>
        [TestMethod,
         TestTraits(Trait.Find)]
        public async Task GenericEmployeesFindTask()
        {
            var employee = await EmployeeOperations.GenericRepositoryFindAsync(new[]
            {
                "CountryIdentifierNavigation",
                "ContactTypeIdentifierNavigation"
            });

            Assert.IsTrue(
                employee.ContactTypeIdentifierNavigation != null && 
                employee.CountryIdentifierNavigation != null);

        }

        [TestMethod,
         TestTraits(Trait.JsonSerializing)]
        public async Task SerializeProducts()
        {
            var products = await ProductOperations.GetProductsByCategory(3, false);
            var json = ProductOperations.Serialize(products);
            Assert.IsNotNull(json);
            File.WriteAllText("SerializedProducts.json", json);

        }

        /// <summary>
        /// Shows attaching a range of customers that have been modified when attached
        /// their state is UnChanged
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.attachrange?view=efcore-3.1
        /// </remarks>
        [TestMethod,
         TestTraits(Trait.ModifyingRecords)]
        public async Task AttachRangeTask()
        {
            var topFiveCustomers = await CustomerOperations.SelectTopFiveCustomersAsync();

            for (int index = 0; index < topFiveCustomers.Count; index++)
            {
                topFiveCustomers[index].CompanyName += "1";
            }

            var success = CustomerOperations.AttachCustomersRange(topFiveCustomers);
            Assert.IsTrue(success);

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
        public async Task SortCustomerByCompanyNameDescendingTask()
        {
            var customerItems = await CustomerOperations.CustomerSort(
                "CompanyName", SortDirection.Descending);

            Assert.AreEqual(customerItems.FirstOrDefault()?.CompanyName, 
                "Wolski  Zajazd",
                $"{TestContextInstance.TestName} failed");

        }
        [TestMethod]
        [TestTraits(Trait.DynamicSortByPropertyName)]
        public async Task SortCustomerByCompanyNameAscendingTask()
        {
            var customerItems = await CustomerOperations.CustomerSort(
                "CompanyName");

            Assert.AreEqual(customerItems.FirstOrDefault()?.CompanyName, 
                "Alfreds Futterkiste", 
                $"{TestContextInstance.TestName} failed");

        }
        [TestMethod]
        [TestTraits(Trait.DynamicSortByPropertyName)]
        public async Task SortCustomerByCountryNameAscendingTask()
        {
            var customerItems = await CustomerOperations.CustomerSort(
                "CountryName");

            Assert.AreEqual(customerItems.FirstOrDefault()?.CountryName, 
                "Argentina",
                $"{TestContextInstance.TestName} failed");

        }
    }
}
