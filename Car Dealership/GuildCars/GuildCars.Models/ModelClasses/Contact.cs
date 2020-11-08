using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models
{
    public class Contact
    {
        public int contact_ID { get; set; }
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        
        [StringLength(254)]
        public string email { get; set; }
        
        [StringLength(12)]
        public string phoneNumber { get; set; }
        [Required]
        [StringLength(250)]
        public string description { get; set; }
    }
}
