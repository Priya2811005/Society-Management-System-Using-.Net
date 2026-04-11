using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Society_Management_System.Data;
using Society_Management_System.Models;

namespace Society_Management_System.Controllers
{
    // Custom list wrapper to safely resolve .Any() calls from dynamic Razor Models
    public class RazorViewList<T> : List<T>
    {
        public RazorViewList(IEnumerable<T> collection) : base(collection) { }
        public bool Any() => this.Count > 0;
    }

    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ---------------- Dashboard ----------------
        public IActionResult Dashboard()
        {
            return View();
        }

        // ---------------- Complaint ----------------

        [HttpGet]
        public IActionResult AddComplaint()
        {
            return View("AddComplain");
        }

       
       

        // ---------------- Notice ----------------
        public IActionResult Notice()
        {
            return View();
        }


        // ---------------- Maintenance ----------------

        public ActionResult Maintenance()
        {
            
            return View();
        }

        // ---------------- Visitor ----------------

        [HttpGet]
        public IActionResult AddVisitor()
        {
            return View();
        }

       

        // ---------------- Hall Booking ----------------
        
        [HttpGet]
        public IActionResult HallBooking()
        {
            return View();
        }

       

        // ---------------- Profile ----------------
        public IActionResult Profile()
        {
            ViewBag.Name = "Trushali Sorathiya";
            ViewBag.Email = "trushali@gmail.com";
            ViewBag.Contact = "9876543210";
            ViewBag.Flat = "101";
            ViewBag.Wing = "A";

            return View();
        }
    }
}