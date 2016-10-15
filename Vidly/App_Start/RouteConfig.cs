using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // first, route attributes must be enabled
            routes.MapMvcAttributeRoutes();

            /*
             * Deleting this way of routing as this was the old way.
             * The new way is by route attributes.
             * 
            // custom route: from more specific, to more generic
            routes.MapRoute(
                "MoviesByReleaseDate"
                , "movies/released/{year}/{month}"
                , new { controller = "Movies", action = "ByReleaseDate" }
                , new { year = @"2015|2016", month = @"\d{2}" });
            //, new { year = @"\d{4}", month = @"\d{2}" });
            */

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
