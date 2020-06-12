using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Director
    {
        public int DirectorId { get; set; }

        [Required]
        [StringLength(100)]
        public string DirectorName { get; set; }
        public string ImageURL { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double NetWorth { get; set; }

        [StringLength(100)]
        public string Nationality { get; set; }

        [StringLength(100)]
        public string Education { get; set; }



        public virtual ICollection<Movie> Movies { get; set; }
    }
}