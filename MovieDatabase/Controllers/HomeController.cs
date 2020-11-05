using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    public class HomeController : Controller
    {
        MovieContext db = new MovieContext();

        public ActionResult Index(string sortOrder)
        {
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.RatingSortParm = sortOrder == "Rating" ? "rating_desc" : "Rating";
            var movies = from m in db.Movies
                            select m;
            switch (sortOrder)
            {
                case "title_desc":
                    movies = movies.OrderByDescending(m => m.Title);
                    break;
                case "Date":
                    movies = movies.OrderBy(m => m.Date);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(m => m.Date);
                    break;
                case "Rating":
                    movies = movies.OrderBy(m => m.Rating);
                    break;
                case "rating_desc":
                    movies = movies.OrderByDescending(m => m.Rating);
                    break;
                default:
                    movies = movies.OrderBy(m => m.Title);
                    break;
            }
            return View(movies.ToList());
            //return View(db.Movies.ToList());
        }

        public ActionResult MovieDetails(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        // проголосовать за фильм
        [HttpGet]
        public ActionResult VoteMovie(int id)
        {
            bool IsAuth = HttpContext.User.Identity.IsAuthenticated; // аутентифицирован ли пользователь
            if (!IsAuth)
            {
                return new HttpUnauthorizedResult();
            }
            ViewBag.MovieId = id;
            return View();
        }
        [HttpPost]
        public ActionResult VoteMovie(Movie movie)
        {
            int id = movie.Id;
            movie = db.Movies.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            movie.Rating++;
            TryUpdateModel(movie);
            if (ModelState.IsValid)
            {
                db.SaveChanges();
            }

            return Redirect("/Home/MovieDetails/" + movie.Id);
        }



        // Вывести список актеров
        public ActionResult ActorsList(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.RatingActorsSortParm = sortOrder == "Rating" ? "rating_desc" : "Rating";
            var actors = from a in db.Actors
                            select a;
            switch (sortOrder)
            {
                case "name_desc":
                    actors = actors.OrderByDescending(a => a.Name);
                    break;
                case "Rating":
                    actors = actors.OrderBy(a => a.Rating);
                    break;
                case "rating_desc":
                    actors = actors.OrderByDescending(a => a.Rating);
                    break;
                default:
                    actors = actors.OrderBy(a => a.Name);
                    break;
            }
            return View(actors.ToList());
        }

        // Вывести подробности о конкретном актере
        public ActionResult ActorDetails(int id = 0)
        {
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // проголосовать за актера
        [HttpGet]
        public ActionResult VoteActor(int id)
        {
            ViewBag.ActorId = id;
            return View();
        }
        [HttpPost]
        public ActionResult VoteActor(Actor actor)
        {
            int id = actor.Id;
            actor = db.Actors.Find(id);

            if (actor == null)
            {
                return HttpNotFound();
            }

            actor.Rating++;
            TryUpdateModel(actor);
            if (ModelState.IsValid)
            {
                db.SaveChanges();
            }

            return Redirect("/Home/ActorDetails/" + actor.Id);
        }
    }
}