using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MVC1_BookWorld.Models;
using MVC1_BookWorld.ViewModel;
using System.Runtime.Caching;     //only after performance profiling
using System.Collections.Generic;

//async improves scalability not performance..threads dont wait for response..mongo db
//sql server is single instance and mongo, raven, azure
namespace MVC1_BookWorld.Controllers
{
    public class CustomersController : Controller       
    {
        // GET: Customers        if authorize placed here ..works for all methods...if kept globally works for all controller
        private ApplicationDbContext _context;
        public CustomersController()          //ctor+tab 
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)     //dbcontext is disposable
        {
            base.Dispose(disposing);
        }

        [Authorize(Roles=RoleNames.CanManageCustomers)]
        public ActionResult New() {      //this is for disposable form, to create new customer
            var membershipTypes = _context.MembershipTypes.ToList();      //created table of membership 
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),   //???!!!!!!!!!!!..use?
                MembershipTypes = membershipTypes
            };                                                          //sending viewModel as an object to store value of new customer
            return View("CustomerForm",viewModel);   //we r sending customerform because the view name is diff~~
        }

        [HttpPost]     //mvc framework automatically maps request data with model..This is Model Binding
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)   //changed New>>Update 
            //validation is checked here coz customer type is the argument 

        {     //UpdateCustomerDto instead of Customer type as arg enables only selective prop ..security issues

            if (!ModelState.IsValid)
            {

                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,

                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.ID == 0)            //need id, demand from view
              _context.Customers.Add(customer);
             else
            {
                var customerInDb = _context.Customers.Single(c => c.ID == customer.ID);   
                //single used instead of single or default..throws exception when the customer is not found and we handle exception
                //  TryUpdateModel(customerInDb);     //security holes, **updates all//also can send string of properties to change but magic string
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                //manually enter all...better approach
                //can use AutoMapper
                //Mapper.Map(customer,customerInDb);
            }
            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        [Authorize]    //doesnt allow access if not logged in
        public ActionResult Index()
        {
            //var customer = new List<Customer>
            //{
            //   new Customer{ Name ="Louis "},
            //   new Customer{ Name="Subash"}
            //};
            //  var customer = GetCustomers().ToList();       //Eagerloading--using table of Obj Datatype       //?!!!!! why used context.Customers     =>coz Dbset variable
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();             //this is not querying DB    only after tolist

            //return View(customers);

             //var customers = _context.Customers.ToList();
             //if (User.IsInRole(RoleNames.CanManageCustomers))
             //  return View("AdminList");
             //  return View("ReadOnlyList");

             if (MemoryCache.Default["Genres"] == null)
             {
                 MemoryCache.Default["Genres"] = _context.Genre.ToList();
             }

             var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

             return View();

        }

       // [Route("Customers/Details/(id==UrlParameter.Optional)")]
        public ActionResult Details(int id) {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.ID == id);
         //   var customer = _context.Customers.SingleOrDefault(c => c.ID == id);//object reference not set to an instance of an object

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id) {              //displays editing form
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id); //~~~~~!!!!

            if (customer == null) 
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
            
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