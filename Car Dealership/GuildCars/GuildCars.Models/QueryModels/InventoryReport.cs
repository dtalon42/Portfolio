using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.QueryModels
{
    public class InventoryReport
    {
        public int year { get; set; }
        public string make { get; set;}
        public string model { get; set; }
        public int inventoryCount { get; set; }
        public decimal stockValue { get; set; }
    }
}
