using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeUnitTest.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthClassLibrary.Classes;

namespace EmployeeUnitTest
{
    [TestClass]
    public class UnitTest1 : BaseClass
    {
        /// <summary>
        /// Detect property changes in a single record where unlike DetectChangesEmployee1
        /// property name, current and original value are access via Item1, Item2, Item3
        /// while DetectChangesEmployee1 has English names.
        /// </summary>
        [TestMethod,
         TestTraits(Trait.DetectChanges)]
        public void DetectChangesEmployee()
        {
            var results = EmployeeOperations.GetChanges();

            string[] propertyNames = {"City", "CountryIdentifier"};

            var changedResults = results
                .Select(item => item.Item1).ToArray();

            Assert.IsTrue(propertyNames.SequenceEqual(changedResults));

        }
        /// <summary>
        /// Detect property changes in a single record where the returning type
        /// has English names unlike with DetectChangesEmployee.
        /// </summary>
        [TestMethod,
         TestTraits(Trait.DetectChanges)]
        public void DetectChangesEmployee1()
        {
            // var not used so it's apparent what is being returned
            List<(string PropertyName, object OriginalValue, object CurrentValue)> results = 
                EmployeeOperations.GetChanges1();

            string[] propertyNames = { "City", "CountryIdentifier" };

            var changedResults = results
                .Select(item => item.PropertyName).ToArray();

            Assert.IsTrue(propertyNames.SequenceEqual(changedResults));

        }
    }
}
