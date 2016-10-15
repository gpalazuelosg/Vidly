﻿using System;
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

        /*
         <Action Results>
         Type:                      Helper Method
            ViewResult              View()              +
            PartialViewResult       PartialView()
            ContentResult           Content()
            RedirectResult          Redirect()          +
            RedirectToRouteResult   RedirectToAction()
            JsonResult              Json()
            FileResult              File()
            HttpNotFoundResult      HttpNotFound()      +
            EmptyResult
             
             */


        // GET: Movies/Random
        public ActionResult Random() //public ViewResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel); // this is better approach


            //return View(movie); // this is better
            //return new ViewResult();

            // examples:
            //return Content("Hello world!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});
        }


        /// <summary>
        /// This shows that this method can be invoked as:
        ///     http://localhost:59539/movies/edit/1
        ///    or
        ///     http://localhost:59539/movies/edit?id=1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int Id)
        {
            return Content("id = " + Id);
        }


        // movies
        public ActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie { Id= 1, Name = "Shrek!" },
                new Movie { Id= 2, Name = "Wall-e" }
            };

            var viewModel = new MoviesViewModel
            {
                Movies = movies
            };

            return View(viewModel); // this is better approach

        }



        /*
         * ASP.NET MVC Attribute Route Constraints
         Other constraints that can be added to regex conditions are:
         min
         max
         minlength
         maxlength
         int
         float
         guid
        */

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {

            return Content( year + "/" + month);
        }


        public ActionResult Details(int Id)
        {
            var name = "";

            if (Id != 1 && Id != 2)
            {
                return HttpNotFound();
            }

            name = Id == 1 ? "Shrek!" : "Wall-e";

            var movie = new Movie() { Id = Id, Name = name };


            var viewModel = new MoviesDetailsViewModel();

            viewModel.Movie = movie;

            return View(viewModel); // this is better approach
        }


    }
}