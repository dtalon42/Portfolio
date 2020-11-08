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
    public class BodyStyle
    {
        public int body_ID { get; set; }
        [Required]
        [StringLength(10)]
        public string bodyStyle { get; set; }
    }
}