using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Exercises.Models.Attributes;


namespace Exercises.Models.Data
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }
        [MustBeInRangeAttribute(ErrorMessage = "GPA must be between 0.0 and 4.0")]
        public decimal GPA { get; set; }
        public Address Address { get; set; }
        [Required(ErrorMessage = "Please select a major.")]
        public Major Major { get; set; }
        //[Required(ErrorMessage = "Please select at least one course.")]
        public List<Course> Courses { get; set; }
    }
}