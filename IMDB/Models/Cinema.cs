using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Cinema
    {
        public int CinemaId { get; set; }

        [Required]
        [StringLength(100)]
        public string CinemaName { get; set; }
        public string ImageURL { get; set; }
        public DateTime FoundingDate { get; set; }
        public double NetWorth { get; set; }

        [StringLength(100)]
        public string CEO { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }

        public virtual  ICollection<Movie> Movies{ get; set; }

    }
}