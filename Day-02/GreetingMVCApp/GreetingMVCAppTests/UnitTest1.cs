using System;
using System.Web.Mvc;
using GreetingMVCApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreetingMVCAppTests
{
    [TestClass]
    public class GreetingControllerTests
    {
        [TestMethod]
        public void ReturningMornigViewBefore12()
        {
            var controller = new GreetingController(new FakeTimeServiceForMorning());

            var result = (ViewResult) controller.Greet("Magesh");

            Assert.AreEqual(result.ViewName, "MorningGreet");
        }

        [TestMethod]
        public void ReturningEveningViewAfter12()
        {
            var controller = new GreetingController(new FakeTimeServiceForEvening());

            var result = (ViewResult)controller.Greet("Magesh");

            Assert.AreEqual(result.ViewName, "EveningGreet");
        }
    }

    public class FakeTimeServiceForEvening : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2015, 3, 14, 15, 0, 0);
        }
    }

    public class FakeTimeServiceForMorning : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2014,3,14,9,0,0);
        }
    }
}
