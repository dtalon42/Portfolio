using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.QueryModels
{
    public class SalesReportData
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public decimal totalSales { get; set; }
        public int vehiclesSold { get; set; }
    }
}
