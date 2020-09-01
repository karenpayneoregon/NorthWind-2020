using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtilityTestProject.Classes
{
    public class BaseClass
    {
        protected TestContext TestContextInstance;
        public TestContext TestContext
        {
            get => TestContextInstance;
            set => TestContextInstance = value;
        }
    }
}