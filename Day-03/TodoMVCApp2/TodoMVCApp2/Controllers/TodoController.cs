using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoMVCApp2.Models;

namespace TodoMVCApp2.Controllers
{

    public class TodoController : Controller
    {
        public static List<Todo> TodoList = new List<Todo>{
           new Todo{ Id=1, Title = "Watch a movie", Description = "Steam off the week's pressure", IsCompleted = false, TargetDate = new DateTime(2015,3,16)},
           new Todo{ Id=2, Title = "Fix a bug", Description = "Appraisal is nearing", IsCompleted = false, TargetDate = new DateTime(2015,3,17)},
           new Todo{ Id=3, Title = "Create a bug", Description = "I dont like the client", IsCompleted = true, TargetDate = new DateTime(2015,3,13)},
        };

        //
        // GET: /Todo/

        public ActionResult Index()
        {
            return View(TodoList);
        }

        //
        // GET: /Todo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Todo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Todo/Create

        [HttpPost]
        public ActionResult Create(Todo todo)
        {
            try
            {
                // TODO: Add insert logic here
                todo.Id = TodoList.Max(td => td.Id) + 1;
                TodoList.Add(todo);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_DisplayTodo", todo);
                }
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Todo/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Todo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Todo/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Todo/Delete/5

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteTodo(int id)
        {
            try
            {
                TodoList.Remove(TodoList.First(td => td.Id == id));
                if (Request.IsAjaxRequest())
                {
                    return Json(new {todoId = id, message = "Remove successfully"});
                }
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        public bool ValidateTargetDate(DateTime targetdate)
        {
            throw new NotImplementedException();
        }
    }
}
