using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC1_BookWorld
{
    public class RouteConfig     //defines route
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(                          //custom route,defining constraint,this is fragile,magic..
            //    "BooksByReleaseDate",
            //    "books/released/{year}/{month}",
            //    new{controller="Books",action="ByReleaseDate"},
            //    new{year = @"1996|1997",month = @"\d{2}"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
