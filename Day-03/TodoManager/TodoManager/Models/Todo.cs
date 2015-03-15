using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TodoManager.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        [CustomValidation(typeof(TargetDateValidator),"ValidateData", ErrorMessage = "Invalid Target Date")]
        public DateTime TargetDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}