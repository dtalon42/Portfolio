using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.QueryModels
{
    public class SalesReportQuery
    {
        public string email { get; set; }
        public System.DateTime fromDate { get; set; }
        public System.DateTime toDate { get; set; }
    }
}
