using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Exercises.Models.Attributes;

namespace Exercises.Models.Data
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Please enter a street address.")]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required(ErrorMessage = "Please enter a city.")]
        public string City { get; set; }
        public State State { get; set; }
        [MustBe5DigitsAttribute(ErrorMessage = "Post codes are 5 digits")]
        public string PostalCode { get; set; }
    }
}