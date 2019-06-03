using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using MVC1_BookWorld.Models;
using MVC1_BookWorld.ViewModel;
using System.Data.Entity;
using System.Web.UI.WebControls;
using System.Data.Entity.Validation;

namespace MVC1_BookWorld.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        private ApplicationDbContext _context;

        public BooksController()
        {

            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            //var books = new List<Book> {                   //Hardcoding books
            //    new Book{ ID= 1, Name = "Twilight" },
            //    new Book{ ID= 2, Name = "Palpasa Cafe"}
            //};

            var books = _context.Books.Include(c => c.Genre).ToList();


            return View(books);

        }

        //public ActionResult Random()        //Hardcoding name of Customers  
        //    //BEST--make obj and pass through view and use the model at top
        //{
        //    var book = new Book(){Name = "Twilight"};   //creating obj,prop
        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Louis Gurung"},
        //        new Customer {Name = "abccccccc"}
        //    };
        //    var viewModel = new RandomBookViewModel
        //    {
        //        Book = book,
        //        Customers = customers
        //    };


        //  return Content("hey");
        // ViewData["RandomBook"] = book;     //ViewData(objway),ViewBag(Propway),magic..
        // ViewBag.Book = book;
        //  return View(book);//Howworks new viewresult.ViewData.Model       //View is helper method from base controller..can return new ViewResult but Action results any type
        //   return View(viewModel);
        // return HttpNotFound();         
        //  return new EmptyResult();
        //return RedirectToAction("Index","Home",new{page=1,sortBy="name"});



        [Route("books/released/{year}/{month:regex(\\d{4}):range(1,12)}")]

        public ActionResult ByReleaseDate(int year, int month)
        {
            //  return View();
            return Content(year + "/" + month);

        }

        public ActionResult New()
        {
            //this is a disposable form
            var genre = _context.Genre.ToList(); //listing genre for the form

            var viewModel = new NewBookViewModel()
            {
                Book = new Book(), //without this new book doesnot form from controller
                Genre = genre

            };

            return View("NewBookForm", viewModel);

        }



        public ActionResult Details(int id)
        {
            var book = _context.Books.Include(c => c.Genre).SingleOrDefault(c => c.ID == id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        [HttpPost] //this is to save the form
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book) //save and update 
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new NewBookViewModel()
                {
                    Book = book,
                    Genre = _context.Genre.ToList()
                };

                return View("NewBookForm",viewModel);
            }

            if (book.ID == 0)
            {
                _context.Books.Add(book);
            }
            else
            {

                var BookInDb = _context.Books.Single(c => c.ID == book.ID);

                BookInDb.Name = book.Name;
                BookInDb.DateAdded = book.DateAdded;
                BookInDb.GenreId = book.GenreId;
                BookInDb.NumberInStock = book.NumberInStock;
            }

            //try
            //{         //required entity can be set here too for no exception to occur
                _context.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    Console.WriteLine(e);           //break point f9
            //}

            return RedirectToAction("Index", "Books");

        } 
        //f5 debugger ..shift+f5 -->stop debugger

        public ActionResult Edit(int id) //this displays edit form
        {
            var book = _context.Books.SingleOrDefault(c => c.ID == id);

            if (book == null)
                return HttpNotFound();

            var viewModel = new NewBookViewModel   
            {
                Book = book,
                Genre = _context.Genre.ToList()
                    
            };
            return View("NewBookForm",viewModel); //return form with data from viewmodel

        }

        public ActionResult Delete(int id)
        {
            var book = _context.Books.Find(id); //we dont need info so find
            if (book == null)
            {
                return HttpNotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            return RedirectToAction("Index","Books");
        }


    }
}
