using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        [StringLength(100)]
        public string MovieTitle { get; set; }

        public string ImageURL { get; set; }
        public int DirectorId { get; set; }

        public int Runtime { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        public double Budget { get; set; }

        public DateTime ReleaseDate  { get; set; }

        public int CompanyId { get; set; }

        public int CinemaId { get; set; }



        public virtual Director Director { get; set; }
        public virtual Company Company { get; set; }
        public virtual Cinema Cinema { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}