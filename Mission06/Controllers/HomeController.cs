using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;
using Mission06.Models;

namespace Mission06.Controllers
{
    public class HomeController : Controller
    {
        // creates context to holds all the entries
        private MovieEntryContext MovieEntryContext { get; set; }

        public HomeController(MovieEntryContext movieEntry)
        {
            MovieEntryContext = movieEntry;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult MyPodcasts()
        {
            return View();
        }


        [HttpGet]
        public IActionResult EnterMovie()
        {
            // adds categories to viewbag so that it can be referenced in the Enter Movie page
            ViewBag.Categories = MovieEntryContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult EnterMovie(MovieEntry me)
        {
            if (ModelState.IsValid)
            {
                // adds packaged data to model
                MovieEntryContext.Add(me);
                // saves the packaged data
                MovieEntryContext.SaveChanges();
                // returns the confirmation page and sends the packaged data
                return View("Confirmation", me);
            }

            else //is not valid
            {
                ViewBag.Categories = MovieEntryContext.Categories.ToList();
                return View();
            }
        }


        [HttpGet]
        public IActionResult MovieList()
        {
            // Grabs the whiole category object with id and name
            // sorts the movie data in the table by title
            var movieList = MovieEntryContext.entries
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movieList);
        }


        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = MovieEntryContext.Categories.ToList();

            // creates a variable based on the movieid received and finds the one with the
            // associated ID and saves packages the values to send it back to the enter movie view with the data
            var movieEntry = MovieEntryContext.entries
                .Single(x => x.MovieId == movieid);

            return View("EnterMovie", movieEntry);
        }

        [HttpPost]
        public IActionResult Edit (MovieEntry me)
        {
            // updates current record
            MovieEntryContext.Update(me);
            // saves current record
            MovieEntryContext.SaveChanges();

            return RedirectToAction("MovieList");
        }


        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            //Creates a variable of movie information based on the ID and sends returns it to the view for the POST 
            var movieEntry = MovieEntryContext.entries
                .Single(x => x.MovieId == movieid);

            return View(movieEntry);
        }

       
        [HttpPost]
        public IActionResult Delete(MovieEntry me)
        {
            // Removes Entry
            MovieEntryContext.entries.Remove(me);
            //saves entry
            MovieEntryContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}

