using Microsoft.AspNet.Identity;
using RVASProject.Data;
using RVASProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace RVASProject.Controllers
{
    public class RentController : Controller
    {
        private readonly RentACarContext _context;

        public RentController()
        {
            _context = new RentACarContext();
        }

        public ActionResult Index(int carId)
        {
            ViewBag.CarId = carId;
            var car = _context.Cars.FirstOrDefault(x=>x.Id == carId);
            var userName = User.Identity.Name;
            var customer = _context.Customers.FirstOrDefault(x => x.FirstName == userName);
            var RentalModel = new Rental { Car = car, Customer = customer };

            return View(RentalModel);

        }
        
        public ActionResult Create(int carId)
        {
            ViewBag.CarId = carId;
            return View("Index");
        }

        
        [HttpPost]
        public ActionResult Create(Rental rental)
        {
            if (ModelState.IsValid)
            {
                var existingCar = _context.Cars.FirstOrDefault(c => c.Id == rental.CarId);
                if (existingCar != null)
                {

                    rental.CarId = existingCar.Id;
                }
                else
                {
                    return View("Error", "Rental");
                    
                }


                var userName = User.Identity.Name;
                var customer = _context.Customers.FirstOrDefault(x => x.FirstName == userName);
                if (customer == null)
                {
                    
                    customer = new Customer { FirstName = userName }; 

                    _context.Customers.Add(customer);
                    _context.SaveChanges(); 
                }

                var id = customer.Id;
                rental.CustomerId = id;
               
                _context.Rentals.Add(rental);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            
            ViewBag.CustomerId = new SelectList(_context.Customers, "CustomerId", "Name", rental.CustomerId);
            return View(rental);
        }
      
        public ActionResult Delete(int? carId, int? customerId)
        {
            var rental = _context.Rentals.FirstOrDefault(x => x.CarId == carId || x.CustomerId == customerId);
            if (rental == null)
            {
                return HttpNotFound();
            }

            return View(rental);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var rental = _context.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }

            _context.Rentals.Remove(rental);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult ShowAll()
        {
            var rentals = _context.Rentals.Include("Car").Include("Customer").ToList();

            return View(rentals); 
        }

    }
}