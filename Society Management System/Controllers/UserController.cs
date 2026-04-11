using Microsoft.AspNetCore.Mvc;
using Society_Management_System.Data;
using Society_Management_System.Models;

namespace Society_Management_System.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        // Complaint
        [HttpGet]
        public IActionResult AddComplaint()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComplaint(Complaint model)
        {
            if (ModelState.IsValid)
            {
                _context.Complaints.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(model);
        }

        public IActionResult Notice()
        {
            return View();
        }

        public IActionResult Maintenance()
        {
            return View();
        }

        public IActionResult AddVisitor()
        {
            return View();
        }

        public IActionResult HallBooking()
        {
            return View();
        }

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