using RVASProject.Data; // Dodajte namespace gde se nalazi vaš DbContext
using RVASProject.Models; // Dodajte namespace gde se nalazi vaš model
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RVASProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly RentACarContext _context;

        public CustomerController()
        {
            _context = new RentACarContext();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        // GET: Customer/Details
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(customer);
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Update(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(customer);
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var customer = _context.Customers.Find(id);
                if (customer == null)
                {
                    return HttpNotFound();
                }

                _context.Customers.Remove(customer);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
