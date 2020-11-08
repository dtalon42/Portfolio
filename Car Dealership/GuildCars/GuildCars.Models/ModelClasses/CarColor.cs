using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildCars.Models
{
    public class CarColor
    {
        public int color_ID { get; set; }
        [Required]
        [StringLength(15)]
        public string color { get; set; }
    }
}