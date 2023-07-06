using Microsoft.AspNetCore.Mvc;
using MVC_APP.Models;
using MVC_APP.ViewModels;

namespace MVC_APP.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Random()
        {
            var movie = new Movies()
            {
                Name = "Shrek!",
            };

            //var customers = new List<Customer>
            //{
            //    new Customer { Name = "Customer 1" },
            //    new Customer { Name = "Customer 2" },
            //};

            //var viewModel = new RandomMovieViewModel
            //{
            //    Movie = movie,
            //    Customers = customers
            //};

            return View(movie);
        }

        [Route("movies/released/{year}/{month}")]
        public IActionResult MoviesByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
