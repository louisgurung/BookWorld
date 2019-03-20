using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using MVC1_BookWorld.Models;
using MVC1_BookWorld.ViewModel;
using System.Data.Entity;

namespace MVC1_BookWorld.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        private ApplicationDbContext _context;
        public BooksController() {

                _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        public ActionResult Index()
        {
            //var books = new List<Book> {
            //    new Book{ ID= 1, Name = "Twilight" },
            //    new Book{ ID= 2, Name = "Palpasa Cafe"}
            //};
            var books = _context.Books.ToList();
            if (books == null)
                return HttpNotFound();

            return View(books);

            
        }

        public ActionResult Random()          //BEST--make obj and pass through view and use the model at top
        {
            var book = new Book(){Name = "Twilight"};   //creating obj,prop
            var customers = new List<Customer>
            {
                new Customer {Name = "Louis Gurung"},
                new Customer {Name = "abccccccc"}
            };
            var viewModel = new RandomBookViewModel
            {
                Book = book,
                Customers = customers
            };


          //  return Content("hey");
           // ViewData["RandomBook"] = book;     //ViewData(objway),ViewBag(Propway),magic..
           // ViewBag.Book = book;
          //  return View(book);//Howworks new viewresult.ViewData.Model       //View is helper method from base controller..can return new ViewResult but Action results any type
            return View(viewModel);
            // return HttpNotFound();         
          //  return new EmptyResult();
            //return RedirectToAction("Index","Home",new{page=1,sortBy="name"});

        }

        [Route("books/released/{year}/{month:regex(\\d{4}):range(1,12)}")]

        public ActionResult ByReleaseDate(int year,int month)
        {
          //  return View();
            return Content(year + "/" + month);

        }

        public ActionResult Details(int id) {
            var book = _context.Books.SingleOrDefault(c=>c.ID ==id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        
    }
}