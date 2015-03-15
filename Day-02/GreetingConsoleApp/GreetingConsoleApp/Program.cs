using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreetingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name:");
            var name = Console.ReadLine();
            var greeter = new Greeter(new TimeService());
            var greetMsg = greeter.Greet(name);
            Console.WriteLine(greetMsg);
            Console.ReadLine();
        }
    }

    public interface ITimeService
    {
        DateTime GetCurrentTime();
    }

    public class TimeService : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }

    public class Greeter
    {
        private readonly ITimeService _timeService;

        public Greeter(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public string Greet(string name)
        {
            var greetMsg = string.Empty;
            if (_timeService.GetCurrentTime().Hour < 12)
            {
                greetMsg = string.Format("Hi {0}, Good Morning!", name);
            }
            else
            {
                greetMsg = string.Format("Hi {0}, Good Evening!", name);
            }
            return greetMsg;
        }
    }
}
