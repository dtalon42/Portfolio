using System.ComponentModel.DataAnnotations;

namespace GuildCars.Models
{
    public class Interior
    {
        public int interior_ID { get; set; }
        [Required]
        [StringLength(15)]
        public string interior { get; set; }
    }
}