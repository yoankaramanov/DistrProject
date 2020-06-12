using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class ProjectDbContext:DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<MovieActor> MovieActor { get; set; }

    }
}