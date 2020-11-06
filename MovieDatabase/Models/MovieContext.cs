using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieDatabase.Models
{
    // Контекст данных
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public MovieContext() : base("DefaultConnection")
        { }

        // Добавление в бд связи "многие-ко-многим" (актеры и фильмы)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasMany(m => m.Movies)
                .WithMany(a => a.Actors)
                .Map(t => t.MapLeftKey("ActorId")
                .MapRightKey("MovieId")
                .ToTable("ActorMovie"));
        }
    }
}