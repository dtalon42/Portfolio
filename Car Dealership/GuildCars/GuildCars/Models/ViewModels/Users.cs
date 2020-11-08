using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.Models.ViewModels
{
    public class Users
    {
        public string userId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        public string Role { get; set; }
       
        [Display(Name = "Password")]
        public string password { get; set; }
        
        [Display(Name = "Confirm Password")]
        public string confPassword { get; set; }
    }
}