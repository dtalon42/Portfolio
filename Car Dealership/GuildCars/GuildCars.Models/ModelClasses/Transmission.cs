using System.ComponentModel.DataAnnotations;

namespace GuildCars.Models
{
    public class Transmission
    {
        public int transmission_ID { get; set; }
        [Required]
        [StringLength(25)]
        public string transmission { get; set; }
    }
}