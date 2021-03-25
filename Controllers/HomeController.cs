using DateMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DateMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IMovieRepository _repository;

        private MovieDbContext _context;
        //I had to bring in the context and repository here
        public HomeController(ILogger<HomeController> logger, IMovieRepository repository, MovieDbContext context)
        {
            _logger = logger;
            _repository = repository;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EnterMovie()
        {

            return View();
        }


        [HttpPost]
        public IActionResult EnterMovie(EnterMovieModel movieEntered)
        {
            //Here is where we need to create the object with the model
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movieEntered);
                _context.SaveChanges();

                return RedirectToAction("ViewMovies");
            }
            else
            {

                return View("EnterMovie");
            }
        }

        public IActionResult ViewMovies()
        {
            return View(_repository.Movies);
            //TempStorage.Movies.Where(r => r.title != "Independence Day")
        }

        //this action just takes the correct movie int from a hidden form, and then sends it to the action with the correct object for it to populate the form
        public IActionResult Edit(int movieid)
        {
            EnterMovieModel movie = (EnterMovieModel)_context.Movies.Where(r => r.movieId == movieid).FirstOrDefault();
            return View("Update", movie);
            //_context.Update(movie);
        }
        //checks if its valid, then updates the movie, saves, and sends you to a confirmation page
        public IActionResult Update(EnterMovieModel movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return View("Confirmation");
            }
            else
            {
                return View("Update", movie);
            }
        }
        //just finds the right object in the database based on the movieid, and then deletes from the database
        public IActionResult Delete(int movieId)
        {
            EnterMovieModel movie = (EnterMovieModel)_context.Movies.Where(r => r.movieId == movieId).FirstOrDefault();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return View("Confirmation");
        }
        public IActionResult Podcast()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
