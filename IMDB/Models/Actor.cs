using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Actor
    {
        public int ActorId { get; set; }

        [Required]
        [StringLength(100)]
        public string ActorName { get; set; }

        public string ImageURL { get; set; }
        public DateTime DateOfBirth { get; set; }

        public double NetWorth { get; set; }

        [StringLength(100)]
        public string Nationality { get; set; }

        public int Height { get; set; }


        public ICollection<MovieActor> MovieActors { get; set; }
    }
}