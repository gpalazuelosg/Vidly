using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/Index
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer { Id= 1, Name = "John Smith" },
                new Customer { Id= 2, Name = "Mary Williams" }
            };

            var viewModel = new CustomerViewModel
            {
                Customers = customers
            };

            return View(viewModel); // this is better approach

        }


        public ActionResult Details(int Id)
        {
            var name = "";

            if (Id != 1 && Id != 2)
            {
                return HttpNotFound();
            }

            name = Id == 1 ? "John Smith" : "Mary Williams";

            var customer = new Customer() { Id = Id, Name = name };


            var viewModel = new CustomerDetailViewModel ();

            viewModel.Customer = customer;
            
            return View(viewModel); // this is better approach
        }
    }
}