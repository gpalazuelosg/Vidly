using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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

            //return View(movie); // this is better
            //return new ViewResult();

            // examples:
            //return Content("Hello world!");
            //return HttpNotFound();
            //return new EmptyResult();
            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});
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
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}