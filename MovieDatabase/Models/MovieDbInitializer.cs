using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieDatabase.Models
{
    // Инициализируем базу данных начальными значениями при каждом запуске проекта
    public class MovieDbInitializer : DropCreateDatabaseAlways<MovieContext>
    {
        protected override void Seed(MovieContext context)
        {
            Movie m1 = new Movie
            {
                Id = 1,
                Title = "Чарли и шоколадная фабрика",
                Date = new DateTime(2005, 7, 10),
                Rating = 7,
                AboutMovie = "Какие чудеса ждут вас на фабрике Вилли Вонки? Только представьте: травяные луга из сладкого мятного сахара в Шоколадной Комнате..."
            };
            Movie m2 = new Movie
            {
                Id = 2,
                Title = "Мрачные тени",
                Date = new DateTime(2012, 5, 9),
                Rating = 5,
                AboutMovie = "Барнабас Коллинз, владелец поместья Коллинвуд, богат, властен и слывет неисправимым Казановой, пока не совершает роковую ошибку, разбив сердце Анжелики Бошар...."
            };
            Movie m3 = new Movie
            {
                Id = 3,
                Title = "Мордекай",
                Date = new DateTime(2015, 1, 21),
                Rating = 3,
                AboutMovie = "В центре сюжета – история Чарльза Мордекая, обходительного арт-дельца и жулика по совместительству, который путешествует по всему миру и с помощью своего неотразимого обаяния пытается раздобыть украденную картину..."
            };
            Movie m4 = new Movie
            {
                Id = 4,
                Title = "Крупная рыба",
                Date = new DateTime(2003, 12, 4),
                Rating = 6,
                AboutMovie = "В основу этой приключенческой ленты положен роман Дэниела Уоллеса «Большая рыба: роман мифических пропорций»..."
            };

            context.Movies.Add(m1);
            context.Movies.Add(m2);
            context.Movies.Add(m3);
            context.Movies.Add(m4);


            Actor a1 = new Actor
            {
                Id = 1,
                Name = "Юэн Макгрегор",
                Rating = 1,
                AboutActor = "Шотландский актёр. Лауреат премии «Золотой глобус» (2018), двукратный лауреат премии BAFTA (1997, 2004).",
                Movies = new List<Movie>() { m3, m4 }
            };
            Actor a2 = new Actor
            {
                Id = 2,
                Name = "Джонни Дэпп",
                Rating = 4,
                AboutActor = "Американский актёр, кинорежиссёр, музыкант, сценарист и продюсер. Наибольшую известность Джонни принесли роли в фильмах Тима Бёртона.",
                Movies = new List<Movie>() { m1, m2, m3 }
            };
            Actor a3 = new Actor
            {
                Id = 3,
                Name = "Хелена Бонем Картер",
                Rating = 2,
                AboutActor = "Британская актриса театра, кино, телевидения и озвучивания. Лауреат премии BAFTA (2011), восьмикратная номинантка на премию «Золотой глобус» (1994, 1998, 1999, 2003, 2008, 2011, 2014, 2020), двукратная номинантка на премию «Оскар» (1998, 2011).",
                Movies = new List<Movie>() { m1, m2 }
            };

            context.Actors.Add(a1);
            context.Actors.Add(a2);
            context.Actors.Add(a3);

            base.Seed(context);
        }
    }
}