using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthClassLibrary.Contexts;

namespace UtilityTestProject.Classes
{
    public class BaseClass
    {
        //protected NorthwindContext dbContext;

        //public NorthwindContext DbContext
        //{
        //    get => dbContext;
        //    set => dbContext = value;
        //}

        [TestInitialize]
        public void SetupTestBase()
        {
            //DbContext = new NorthwindContext();
        }

        [TestCleanup]
        public void TeardownTestBase()
        {
            //DbContext.Dispose();
        }  
        protected TestContext TestContextInstance;
        public TestContext TestContext
        {
            get => TestContextInstance;
            set => TestContextInstance = value;
        }

    }
}