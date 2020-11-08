using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models.Attributes
{
    public class MustBe5DigitsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is string)
            {
                string checkPostCode = (string)value;

                if (!string.IsNullOrEmpty(checkPostCode) && checkPostCode.Length == 5)
                    return true;
                else
                    return false;
            }

            return false;
        }
    }
}