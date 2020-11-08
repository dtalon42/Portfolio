using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;

namespace GuildCars.Models
{
    public class SalesData
    {
        public int vehicle_ID { get; set; }
        public int sale_ID { get; set; }
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        [Required]
        [StringLength(12)]
        public string phone { get; set; }
        [Required]
        [StringLength(254)]
        public string email { get; set; }
        [Required]
        [StringLength(95)]
        public string street_1 { get; set; }
        [StringLength(10)]
        public string street_2 { get; set; }
        [Required]
        [StringLength(17)]
        public string city { get; set; }
        [Required]
        public int state_ID { get; set; }
        [Required]
        [StringLength(5)]
        public string zipCode { get; set; }
        [Required]
        public decimal purchasePrice { get; set; }
        [Required]
        public int purchaseType_ID { get; set; }
        [Required]
        [StringLength(254)]
        public string userAdded { get; set; }


    }
}