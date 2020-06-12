using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }
        public string ImageURL { get; set; }
        public double NetWorth { get; set; }
        public DateTime FoundingDate { get; set; }

        [StringLength(100)]
        public string Country { get; set; }
        public double AnnualIncome { get; set; }


        public virtual ICollection<Movie> Movies{ get; set; }
    }
}