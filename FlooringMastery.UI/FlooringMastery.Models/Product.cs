using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class Product
    {
        public string productType { get; set; }
        public decimal costPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
    }
}
