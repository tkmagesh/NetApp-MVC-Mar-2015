using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoMVCApp2.Models
{
    public class TargetDateValidator : ValidationAttribute
    {

        public static ValidationResult ValidateData(object value)
        {
            var v = Convert.ToDateTime(value);
            if (v < DateTime.Now)
            {
                return new ValidationResult("Invalid Target Date");
            }
            return new ValidationResult(string.Empty);
        }
    }
}