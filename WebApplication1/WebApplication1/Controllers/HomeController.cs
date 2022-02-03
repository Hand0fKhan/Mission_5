using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1_A.Models;

namespace WebApplication1_A.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _movieContexts { get; set; }

        public HomeController(MovieContext movieCont)
        {
            _movieContexts = movieCont;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            ViewBag.Categories = _movieContexts.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult NewMovie(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                _movieContexts.Add(ar);
                _movieContexts.SaveChanges();
                return View("Confirmation", ar);
            }
            else
            {
                return View();
            }
        }

        public IActionResult MyPodcasts()
        {
            return View("MyPodcasts");
        }
        [HttpGet]
        public IActionResult Collection()
        {
            var collect = _movieContexts.Movies.Include(movie=> movie.Category).OrderBy(movie => movie.Title).ToList();
            return View(collect);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = _movieContexts.Categories.ToList();
            var movie = _movieContexts.Movies.Single(movie => movie.MovieID == movieid);
            return View("NewMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse movie)
        {
            _movieContexts.Update(movie);
            _movieContexts.SaveChanges();

            return RedirectToAction("Collection");
        }
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            _movieContexts.Movies.Remove(ar);
            _movieContexts.SaveChanges();
            return RedirectToAction("Collection");
        }
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = _movieContexts.Movies.Single(z => z.MovieID == movieid);
            return View(movie);
        }
    }
}
