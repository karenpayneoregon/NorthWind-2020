using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeUnitTest.Classes
{
    public class BaseClass
    {

        [TestInitialize]
        public void SetupTestBase()
        {

        }

        [TestCleanup]
        public void TeardownTestBase()
        {

        }  
        protected TestContext TestContextInstance;
        public TestContext TestContext
        {
            get => TestContextInstance;
            set => TestContextInstance = value;
        }

    }
}