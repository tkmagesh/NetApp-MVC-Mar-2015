using System;
using GreetingConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreetingConsoleAppTest
{


    public class TimeServiceForMorning : ITimeService
    {

        public DateTime GetCurrentTime()
        {
            return new DateTime(2015, 3, 14, 9, 0, 0);
        }
    }

    public class TimeServiceForEvening : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2015, 3, 14, 15, 0, 0);
        }
    }

    
    [TestClass]
    public class GreeterTests
    {
        [TestMethod]
        public void Greets_Good_Morning_before_12()
        {
            //Arrange
            var morningTimeServce = new TimeServiceForMorning();
            var greeter = new Greeter(morningTimeServce);
            var name = "Magesh";
            var expectedResult = "Hi Magesh, Good Morning!";

            //Act
            var greetMsg = greeter.Greet(name);

            //Assert
            Assert.AreEqual(expectedResult, greetMsg);
        }

        [TestMethod]
        public void Greets_Good_Evening_after_12()
        {
            //Arrange
            var eveningTimeService = new TimeServiceForEvening();
            var greeter = new Greeter(eveningTimeService);
            var name = "Magesh";
            var expectedResult = "Hi Magesh, Good Evening!";

            //Act
            var greetMsg = greeter.Greet(name);

            //Assert
            Assert.AreEqual(expectedResult, greetMsg);
        }
    }
}
