using RVASProject.Data;
using RVASProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RVASProject.Controllers
{
    public class CarsController : Controller
    {
        private readonly RentACarContext _context;

        public CarsController()
        {
            _context = new RentACarContext();
        }
        public ActionResult Index()
        {
            var cars = _context.Cars.ToList();
            return View(cars);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Cars.Add(car);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(car);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = _context.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var car = _context.Cars.Find(id);
            if (car == null)
            {
                return View("Error", "Home");
            }

            _context.Cars.Remove(car);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Car car = _context.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }

            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(car).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(car);
        }


    }
}