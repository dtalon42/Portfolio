using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.QueryModels
{
    public class VehicleSearch
    {
        public string searchString { get; set; }
        public bool newOrUsed { get; set; }
        public decimal minPrice { get; set; }
        public decimal maxPrice { get; set; }
        public int minYear { get; set; }
        public int maxYear { get; set; }
    }
}
