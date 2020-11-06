using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    // Модель фильма
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } // название

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy'/'MM'/'dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } // Дата выхода в прокат
        public int Rating { get; set; } // Рейтинг (кол-во лайков)
        public string AboutMovie { get; set; } // Информация о фильме

        // Список актеров, игравших в фильме
        public virtual ICollection<Actor> Actors { get; set; } 
        public Movie()
        {
            Actors = new List<Actor>();
        }
    }
}