using System.ComponentModel.DataAnnotations;

namespace GuildCars.Models
{
    public class CarType
    {
        public int type_ID { get; set; }
        [Required]
        [StringLength(20)]
        public string carType { get; set; }
    }
}