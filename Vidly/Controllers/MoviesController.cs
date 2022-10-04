using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            { new Customer {Id = 1, Name = "Customer 1"},
              new Customer {Id = 2, Name = "Customer 2"}
            };

            var ViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            
            return View(ViewModel);
            //return Content("Hello World");
            //return HttpNotFound();
        }

        public ActionResult Edit(int id)
        {
            return Content("Id = " + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            var movies = GetMovies();
            return View(movies);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            { new Movie{ Id = 1, Name = "Shrek"},
              new Movie{ Id = 2, Name = "Wall-e"},
              new Movie{ Id = 3, Name = "Inception"}
            };

        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year +"/"+ month);

        }
    }
}