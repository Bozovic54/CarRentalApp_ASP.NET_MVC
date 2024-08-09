using RVASProject.Data;
using RVASProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RVASProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly RentACarContext _context;

        public HomeController()
        {
            _context = new RentACarContext();
        }
        public ActionResult Index()
        {
            var cars = _context.Cars.ToList();
            return View(cars);
        }

        public ActionResult About()
        { 
            ViewBag.Message = "Description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }
    }
}