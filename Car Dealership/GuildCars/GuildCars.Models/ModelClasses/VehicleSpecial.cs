using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models
{
    public class VehicleSpecial
    {
        [Required]
        public int vehicle_ID { get; set; }
        [Required]
        public int special_ID { get; set; }
    }
}
