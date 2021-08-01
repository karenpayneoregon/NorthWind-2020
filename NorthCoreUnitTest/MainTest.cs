using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthCoreUnitTest.Base;
using NorthWindCore.Classes.Helpers;
using NorthWindCore.Contexts;
using NorthWindCore.LanguageExtensions;

namespace NorthCoreUnitTest
{
    [TestClass]
    public partial class MainTest //: TestBase
    {
        [TestMethod]
        public void TestMethod1()
        {
            using var context = new NorthwindContext();
            var modelNames = context.GetModelNamesSorted();

            foreach (var name in modelNames)
            {
                Console.WriteLine(name);
                foreach (var column in context.GetEntityProperties(name))
                {
                    Console.WriteLine($"\t{column.Name} - {column.ClrType.CSharpName()} - {column.SqlType} ");
                }
            }
        }

    }
}
