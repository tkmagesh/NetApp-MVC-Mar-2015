using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoManager.Controllers
{
    public class TodosController : Controller
    {
        //
        // GET: /Todos/
        public static List<string> TodoList = new List<string>{
            "Watch a Movie",
            "Fix a bug",
            "Create a bug"
        };

        public ViewResult Index()
        {
            return View("Index", TodoList);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string newToDo)
        {
            if (newToDo.Length > 20)
            {
                TodoList.Add(newToDo);
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Invalid Name";
            return View(model: newToDo);
        }

    }
}
