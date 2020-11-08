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
    public class Vehicle
    {
        public int vehicle_ID { get; set; }
        public int make_ID { get; set; }
        public int model_ID { get; set; }
        public int type_ID { get; set; }
        public int body_ID { get; set; }
        public int transmission_ID { get; set; }
        public int color_ID{ get; set; }
        public int interior_ID { get; set; }
        
        [Required]
        public int year { get; set; }

        [Required]
        public int mileage { get; set; }
        
        [Required]
        [StringLength(17)]
        public string vinNumber { get; set; }

        [Required]
        public decimal msrp { get; set; }

        [Required]
        public decimal salePrice { get; set; }

        [Required]
        [StringLength(500)]
        public string description { get; set; }

        
        [StringLength(260)]
        public string picture { get; set; }
        [Required]
        public bool featured { get; set; } = false;
        public int? sale_ID { get; set; }

    }
}