using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy'/'MM'/'dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string AboutMovie { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public Movie()
        {
            Actors = new List<Actor>();
        }
    }
}