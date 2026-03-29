using Microsoft.AspNetCore.Mvc;
using System;

namespace Society_Management_System.Controllers
{
    public class UserController : Controller
    {
        // ---------------- Dashboard ----------------
        public IActionResult Dashboard()
        {
            return View();
        }

        // ---------------- Complaint ----------------

        // GET: Add Complaint
        [HttpGet]
        public IActionResult AddComplain()
        {
            return View();
        }

        // POST: Add Complaint
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComplain(string subject, string description)
        {
            if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(description))
            {
                ViewBag.Message = "Please fill all fields!";
                return View();
            }

            // TODO: Save complaint to database

            TempData["SuccessMessage"] = "Complaint submitted successfully!";
            return RedirectToAction(nameof(ComplaintList));
        }

        // Complaint List
        public IActionResult ComplaintList()
        {
            return View();
        }

        // ---------------- Notice ----------------
        public IActionResult Notice()
        {
            return View();
        }

        // ---------------- Visitor ----------------

        // Add Visitor
        public IActionResult AddVisitor()
        {
            return View();
        }

        // Visitor List
        public IActionResult VisitorList()
        {
            return View();
        }

        // ---------------- Hall Booking ----------------

        // GET: Hall Booking
        [HttpGet]
        public IActionResult HallBooking()
        {
            return View();
        }

        // POST: Save Hall Booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveHallBooking(string hallType, DateTime date, string startTime, string endTime, string purpose)
        {
            if (string.IsNullOrEmpty(hallType) || string.IsNullOrEmpty(purpose))
            {
                TempData["ErrorMessage"] = "Please fill all required fields!";
                return RedirectToAction(nameof(HallBooking));
            }

            // TODO: Save booking to database

            TempData["SuccessMessage"] = "Booking submitted successfully!";
            return RedirectToAction(nameof(MyBookings));
        }

        // My Bookings
        public IActionResult MyBookings()
        {
            return View();
        }

        // ---------------- Profile ----------------
        public IActionResult Profile()
        {
            // Temporary user data (replace with DB/session later)
            ViewBag.Name = "Trushali Sorathiya";
            ViewBag.Email = "trushali@gmail.com";
            ViewBag.Contact = "9876543210";
            ViewBag.Flat = "101";
            ViewBag.Wing = "A";

            return View();
        }
    }
}