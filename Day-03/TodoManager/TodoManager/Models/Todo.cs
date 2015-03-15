using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoManager.Models
{
    public class Todo
    {
        public static IDictionary<string,string> Validate(Todo todo)
        {
            var errorMessages = new Dictionary<string, string>();
            //check the title
            if (string.IsNullOrEmpty(todo.Title))
            {
                errorMessages.Add("Title", "Title is mandatory");
            }

            //check the Target Date
            if (todo.TargetDate < DateTime.Now)
            {
                errorMessages.Add("TargetDate", "Invalid Target date");
            }
            return errorMessages;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}