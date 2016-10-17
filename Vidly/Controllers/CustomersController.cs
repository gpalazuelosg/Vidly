using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;


        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Create(NewCustomerViewModel viewModel)
        {
            return View();
        }


        // GET: Customer/Index
        public ActionResult Index()
        {

            /*
             using this approach:
                var customers = _context.Customers;
             the query IS NOT INMEDIATEALY executed; instead, it will happen during an iteration step (like in the forach in the View)


            using this approach:
                var customers = _context.Customers.ToList();
            the query is INMEDIATELY executed!
             */

            var customers = _context.Customers.Include(c => c.MembershipType);
            

            var viewModel = new CustomerViewModel
            {
                Customers = customers
            };

            return View(viewModel); // this is better approach

        }


        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerDetailViewModel ();

            viewModel.Customer = customer;
            
            return View(viewModel); // this is better approach
        }
    }
}