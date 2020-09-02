using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Forms.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthClassLibrary;
using SortLibrary;
using UtilityTestProject.Classes;

namespace UtilityTestProject
{
    [TestClass]
    public class UnitTest1 : BaseClass
    {
        /// <summary>
        /// Valid non-existing keys can be known
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.ApplicationConfiguration)]
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
