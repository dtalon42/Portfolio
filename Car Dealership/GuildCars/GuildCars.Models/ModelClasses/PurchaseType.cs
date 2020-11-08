using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models
{
    public class PurchaseType
    {
        [Required]
        public int purchaseType_ID { get; set; }
        [Required]
        [StringLength(20)]
        public string purchaseType { get; set; }

    }
}
