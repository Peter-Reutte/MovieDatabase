using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    // Модель актера
    public class Actor
    {
        public int Id { get; set; } 
        public string Name { get; set; } // Имя актера
        public string AboutActor { get; set; } // Информация об актере
        public int Rating { get; set; } // Рейтинг актера (кол-во лайков)

        // Список фильмов, в которых играл актер
        public virtual ICollection<Movie> Movies { get; set; }
        public Actor()
        {
            Movies = new List<Movie>();
        }
    }
}