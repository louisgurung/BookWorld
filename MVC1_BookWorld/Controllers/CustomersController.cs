using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC1_BookWorld.Models;
using MVC1_BookWorld.ViewModel;


namespace MVC1_BookWorld.Controllers
{
    public class CustomersController : Controller       
    {
        // GET: Customers
        private ApplicationDbContext _context;
        public CustomersController()          //ctor+tab 
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)     //dbcontext is disposable
        {
            base.Dispose(disposing);
        }


        public ActionResult New() {      //this is for disposable form
            var membershipTypes = _context.MembershipTypes.ToList();      //??now working

            return View();
        }

        

        public ActionResult Index()
        {
            //var customer = new List<Customer>
            //{
            //   new Customer{ Name ="Louis "},
            //   new Customer{ Name="Subash"}
            //};
            //  var customer = GetCustomers().ToList();                     //?!!!!! why used context.Customers     =>coz Dbset variable
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();             //this is not querying DB    only after tolist

            return View(customers);
        }

       // [Route("Customers/Details/(id==UrlParameter.Optional)")]
        public ActionResult Details(int id) {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.ID == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        //public IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer{ ID = 1 ,Name = "Louis Gurung"},
        //        new Customer{ ID = 2, Name = "Subash Ranabhat" }
        //    };

        //}
    }
}