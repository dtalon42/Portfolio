using System;
using System.ComponentModel.DataAnnotations;

namespace GuildCars.Models
{
    public class Model
    {
        public int model_ID { get; set; }
        
        [Required]
        [StringLength(17)]
        public string model { get; set; }

        [Required]
        public DateTime dateAdded { get; set; }

        [Required]
        [StringLength(254)]
        public string addedBy { get; set; }

        public int make_ID { get; set; }
    }
}