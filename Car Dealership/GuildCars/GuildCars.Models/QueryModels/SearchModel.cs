using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.QueryModels
{
    public class SearchModel
    {
        public int vehicle_ID { get; set; }
        public int year { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string carType { get; set; }
        public string bodyStyle { get; set; }
        public string transmission { get; set; }
        public string outerColor { get; set; }
        public string interior { get; set; }
        public int mileage { get; set; }
        public string vin { get; set; }
        public decimal salePrice { get; set; }
        public decimal msrp { get; set; }
        public string picture { get; set; }
        public string description { get; set; }
        public int? saleID { get; set; }
    }
}
