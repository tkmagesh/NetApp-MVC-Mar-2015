using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoManager.Models;

namespace TodoManager.Controllers
{
    public class TodosController : Controller
    {
        //
        // GET: /Todos/
        public static List<Todo> TodoList = new List<Todo>{
           new Todo{ Id=1, Title = "Watch a movie", Description = "Steam off the week's pressure", IsCompleted = false, TargetDate = new DateTime(2015,3,16)},
           new Todo{ Id=2, Title = "Fix a bug", Description = "Appraisal is nearing", IsCompleted = false, TargetDate = new DateTime(2015,3,17)},
           new Todo{ Id=3, Title = "Create a bug", Description = "I dont like the client", IsCompleted = true, TargetDate = new DateTime(2015,3,13)},
        };

        public ViewResult Index()
        {
            return View("Index", TodoList);
        }

        [HttpGet]
        public ViewResult Add()
        {

            return View(new Todo(){TargetDate = DateTime.Now.AddDays(1)});
        }

        [HttpPost]
        public ActionResult Add(Todo todo)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model: todo);   
            }
            todo.Id = TodoList.Max(td => td.Id) + 1;
            TodoList.Add(todo);
            return RedirectToAction("Index");
        }

    }
}
