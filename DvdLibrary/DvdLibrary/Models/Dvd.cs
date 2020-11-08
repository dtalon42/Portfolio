namespace DvdLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dvd")]
    public partial class Dvd
    {
        public int dvdId { get; set; }

        [Required]
        [StringLength(20)]
        public string title { get; set; }

        [Required]
        [StringLength(4)]
        public string releaseYear { get; set; }

        [Required]
        [StringLength(30)]
        public string director { get; set; }

        [Required]
        [StringLength(5)]
        public string rating { get; set; }

        [StringLength(30)]
        public string notes { get; set; }
    }
}
