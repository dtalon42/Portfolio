namespace MovieLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Movie
    {
        public int movieId { get; set; }

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
        public string description { get; set; }

        public int thumbsUp { get; set; }
        public int thumbsDown { get; set; }
    }
}
