using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UtilityTestProject.Classes
{
    public class BaseClass
    {

        [TestInitialize]
        public void SetupTestBase()
        {
            if (TestContextInstance.TestName == "SerializeProducts")
            {
                if (File.Exists("SerializedProducts.json"))
                {
                    File.Delete("SerializedProducts.json");
                }
            }
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