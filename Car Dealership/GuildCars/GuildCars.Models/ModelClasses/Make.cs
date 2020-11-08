using System;
using System.ComponentModel.DataAnnotations;

namespace GuildCars.Models
{
   public class Make
    {
        public int make_ID { get; set; }
        
        [Required]
        [StringLength(25)]
        public string make { get; set; }
        [Required]
        public DateTime dateAdded { get; set; }
        [Required]
        [StringLength(254)]
        public string addedBy { get; set; }
    }
}