using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.QueryModels
{
    public class featuredVehicle
    {
        public int year { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public decimal price { get; set; }
        public string picture { get; set; }
    }
}
