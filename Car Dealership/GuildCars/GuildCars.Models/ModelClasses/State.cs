using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models
{
    public class State
    {
        [Required]
        public int state_ID { get; set; }
        [Required]
        [StringLength(2)]
        public string state { get; set; }
    }
}
