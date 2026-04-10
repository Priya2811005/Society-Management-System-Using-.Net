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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComplaint(DateTime ComplaintDate, string Description)
        {
            if (string.IsNullOrEmpty(Description))
            {
                ViewBag.Message = "Please fill all fields!";
                return View("AddComplain");
            }

            var complaint = new Complaint {
                Subject = "User Created", // Default since the UI form lacks a subject field
                Description = Description,
                CreatedAt = ComplaintDate != default ? ComplaintDate : DateTime.Now
            };

            _context.Complaints.Add(complaint);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Complaint submitted successfully!";
            return RedirectToAction(nameof(ComplaintList));
        }

        public IActionResult ComplaintList()
        {
            var records = _context.Complaints.Select(c => new {
                Id = c.Id,
                ComplaintDate = c.CreatedAt,
                Description = c.Description,
                ImagePath = ""
            }).ToList();

            var safeList = new RazorViewList<dynamic>(records.Cast<dynamic>());
            return View(safeList);
        }

        // ---------------- Notice ----------------
        public IActionResult Notice()
        {
            return View();
        }

        // ---------------- Visitor ----------------
        
        [HttpGet]
        public IActionResult AddVisitor()
        {
            return View();
        }

        public IActionResult VisitorList()
        {
            var records = _context.Visitors.Select(v => new {
                Id = v.Id,
                VisitorName = v.Name,
                Purpose = v.Purpose,
                ContactNumber = v.Contact,
                VisitDate = v.VisitDate
            }).ToList();

            var safeList = new RazorViewList<dynamic>(records.Cast<dynamic>());
            return View(safeList);
        }

        // ---------------- Hall Booking ----------------
        
        [HttpGet]
        public IActionResult HallBooking()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveHallBooking(string HallType, DateTime Date, string StartTime, string EndTime, string Purpose)
        {
            if (string.IsNullOrEmpty(HallType) || string.IsNullOrEmpty(Purpose))
            {
                TempData["ErrorMessage"] = "Please fill all required fields!";
                return RedirectToAction(nameof(HallBooking));
            }

            var booking = new HallBooking {
                HallType = HallType,
                BookingDate = Date != default ? Date : DateTime.Now,
                StartTime = StartTime ?? "TBD",
                EndTime = EndTime ?? "TBD",
                Purpose = Purpose
            };

            _context.HallBookings.Add(booking);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Booking submitted successfully!";
            return RedirectToAction(nameof(MyBookings));
        }

        public IActionResult MyBookings()
        {
            var records = _context.HallBookings.Select(h => new {
                Id = h.Id,
                HallType = h.HallType,
                Date = h.BookingDate,
                StartTime = h.StartTime,
                EndTime = h.EndTime,
                Purpose = h.Purpose
            }).ToList();

            var safeList = new RazorViewList<dynamic>(records.Cast<dynamic>());
            return View(safeList);
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