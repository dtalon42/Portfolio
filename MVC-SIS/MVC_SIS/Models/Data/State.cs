using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class State : IValidatableObject
    {
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }
   
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if(string.IsNullOrEmpty(StateName))
            {
                errors.Add(new ValidationResult("Please enter the name of your state.", new[] { "StateName" }));
            }

            if (string.IsNullOrEmpty(StateAbbreviation))
            {
                errors.Add(new ValidationResult("Please enter the abbreviation for your state.", new[] { "StateAbbreviation" }));
            }
            else if (StateValidationRepository.Get(StateAbbreviation) == null)
            {
                errors.Add(new ValidationResult("The abbreviation entered for your state is incorrect. Please try again.", new[] { "StateAbbreviation" }));
            }
            else if(StateValidationRepository.Get(StateAbbreviation).StateName != StateName ) //needs to be 
            {
                errors.Add(new ValidationResult("The entered name does not match the entered abbreviation. Please try again", new[] { "StateName" }));
            }

            return errors;
        }
    
    
    
    }
}