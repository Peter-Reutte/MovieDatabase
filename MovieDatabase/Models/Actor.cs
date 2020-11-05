using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AboutActor { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public Actor()
        {
            Movies = new List<Movie>();
        }
    }
}