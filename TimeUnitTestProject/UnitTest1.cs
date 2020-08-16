using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLibraryCore.Context;
using TimeUnitTestProject.Classes;

namespace TimeUnitTestProject
{
    [TestClass]
    public class UnitTest1 : BaseClass
    {
        [TestMethod]
        [TestTraits(Trait.ConnectionTest)]
        public void MovieConnectionTest()
        {
            using (var context = new DateTimeContext())
            {
                var movies = context.Movies.ToList();
                Assert.IsTrue(movies.Count >0 && movies.FirstOrDefault().Title == "Aliens extended");
            }
        }

        [TestMethod]
        [TestTraits(Trait.TimeSpanTest)]
        public void GetFirstMovieValidateHoursMinutes()
        {
            using (var context = new DateTimeContext())
            {
                var firstMovie = context.Movies.FirstOrDefault();
                var movieTitle = firstMovie.Title;
                var duration = firstMovie.Duration.Value;
                var hours = duration.Hours;
                var minutes = duration.Minutes;

                Assert.AreEqual(hours, 3);
                Assert.AreEqual(minutes, 30);

                Console.WriteLine($"{movieTitle} is {hours} hours {minutes} minutes long");
            }
        }
    }
}
