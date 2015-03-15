using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoMVCApp2.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        

        public string Description { get; set; }

        [Required]
        [CustomValidation(typeof(TargetDateValidator), "ValidateData", ErrorMessage = "Invalid Target Date")]
        [Remote("ValidateTargetDate", "Todo")]
        public DateTime TargetDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}