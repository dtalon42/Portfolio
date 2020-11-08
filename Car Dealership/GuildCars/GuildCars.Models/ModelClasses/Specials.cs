using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models
{
    public class Specials
    {
        public int special_ID { get; set; }

        [Required]
        [StringLength(25)]
        public string name { get; set; }

        [Required]
        [StringLength(250)]
        public string description { get; set; }

    }
}
