using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06.Models;

namespace Mission06.Controllers
{
    public class HomeController : Controller
    {

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
            ViewBag.Categories = MovieEntryContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult EnterMovie(MovieEntry me)
        {
            if (ModelState.IsValid)
            { 
                MovieEntryContext.Add(me);
                MovieEntryContext.SaveChanges();
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

            var movieEntry = MovieEntryContext.entries
                .Single(x => x.MovieId == movieid);

            return View("EnterMovie", movieEntry);
        }

        [HttpPost]
        public IActionResult Edit (MovieEntry me)
        {
            MovieEntryContext.Update(me);
            MovieEntryContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movieEntry = MovieEntryContext.entries
                .Single(x => x.MovieId == movieid);

            return View(movieEntry);
        }

        [HttpPost]
        public IActionResult Delete(MovieEntry me)
        {
            MovieEntryContext.entries.Remove(me);
            MovieEntryContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}

