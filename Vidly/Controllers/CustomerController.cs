using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;
using System.Web.Caching;
using System.Runtime;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        public ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        [Authorize]
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(a => a.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult New()
        {
            var membershipList = _context.Memberships.ToList();
            var viewModel = new NewCustomer
            {
                Customer = new Customer(),
                MembershipTypes = membershipList
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomer
                {
                    MembershipTypes = _context.Memberships.ToList(),
                    Customer = customer
                };

                return View("CustomerForm", viewModel);
            }
            if (customer.ID == 0)
            {
                customer.BirthDate = DateTime.Today;
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.ID == customer.ID);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershiptypeId = customer.MembershiptypeId;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Details(int? id)
        {
            var Customer = _context.Customers.SingleOrDefault(a => a.ID == id);
            if (Customer == null || id == null)
            {
                return HttpNotFound();
            }
            return View(Customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomer
            {
                Customer = customer,
                MembershipTypes = _context.Memberships.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer Customer)
        {
            _context.Customers.Add(Customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        //public ActionResult Index()
        //{
        //    if (MemoryCache.Default["Genres"] == null)
        //    {

        //        MemoryCache.Default["Genres"] = _context.Genres.ToList();
        //    }
        //    var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;
        //    return View();
        //}

    }
}