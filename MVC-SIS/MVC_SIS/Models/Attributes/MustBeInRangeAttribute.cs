using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models.Attributes
{
    public class MustBeInRangeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is decimal)
            {
                decimal checkGPA = (decimal)value;
                if (checkGPA >= (decimal)0.0 && checkGPA <= (decimal)4.0)
                    return true;
                else
                    return false;
            }

            return false;
        }
    }
}