using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreetingMVCApp.Controllers
{
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
    public class GreetingController : Controller
    {
        private readonly ITimeService _timeService;
        //
        // GET: /Greeting/

       
        public GreetingController()
        {
            //Poor man's dependency Injection
            _timeService = new TimeService();
        }

        public GreetingController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpGet]
        public ActionResult Greet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Greet(string name)
        {
            
            if (_timeService.GetCurrentTime().Hour < 12)
            {
                this.ViewBag.msg = string.Format("Hi {0}, Good Morning", name);
                return View("MorningGreet");
            }
            this.ViewBag.msg = string.Format("Hi {0}, Good Evening", name);
            return View("EveningGreet");

        }

    }
}
