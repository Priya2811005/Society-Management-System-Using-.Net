using Microsoft.AspNetCore.Mvc;
using Society_Management_System.Models;   
using System;
using System.Collections.Generic;

namespace Society_Management_System.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        // ---------------- Complaint ----------------

        public IActionResult AddComplain()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComplain(string subject, string description)
        {
            ViewBag.Message = "Complaint Submitted Successfully!";
            return View();
        }

        public IActionResult ComplaintList()
        {
            return View();
        }

        // ---------------- Notice ----------------

        public IActionResult Notice()
        {
            
            return View();
        }


        // ---------------- AddVisitor ----------------

        public IActionResult AddVisitor()
        {

            return View();
        }




        // ---------------- VisitorList----------------

        public IActionResult VisitorList()
        {

            return View();
        }


        // ---------------- HallBooking----------------

        public ActionResult HallBooking()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveHallBooking(string HallType, DateTime Date, string StartTime, string EndTime, string Purpose)
        {
            // Save to database here

            ViewBag.Message = "Booking Submitted Successfully!";
            return RedirectToAction("MyBookings");
        }


        // ---------------- MyBookings----------------

        public IActionResult MyBookings()
        {
            return View();
        }










        // ---------------- Profile----------------


        public IActionResult Profile()
        {
            ViewBag.Name = "Trushali";
            ViewBag.Email = "test@gmail.com";
            ViewBag.Contact = "9876543210";
            ViewBag.Flat = "101";
            ViewBag.Wing = "A";

            return View();
        }



    }

}