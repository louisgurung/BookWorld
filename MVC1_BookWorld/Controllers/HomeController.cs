using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1_BookWorld.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //[OutputCache(Duration = 5,Location= System.Web.UI.OutputCacheLocation.Server, VaryByParam="*")]       //Premature optimization dont do
        [OutputCache(Duration = 0,VaryByParam = "*",NoStore = true)]       //Premature optimization dont do

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}