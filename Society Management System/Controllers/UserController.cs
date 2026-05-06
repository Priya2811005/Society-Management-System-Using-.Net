using Microsoft.AspNetCore.Mvc;
using Society_Management_System.Models;
using Society_Management_System.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;


namespace Society_Management_System.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public UserController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // ---------------- Dashboard ----------------
        public IActionResult Dashboard()
        {
            return View();
        }

        // ---------------- Complaint ----------------

        // GET
        public IActionResult AddComplain()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComplain(string title, string description, IFormFile imageFile)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                ViewBag.Message = "Fill all fields!";
                return View();
            }

            var complaint = new Complaint
            {
                Title = title,
                Description = description,
                Status = "Pending",
                UserId = 1,
                CreatedDate = DateTime.Now
            };

            if (imageFile != null)
            {
                string folder = Path.Combine(_environment.WebRootPath, "complaints");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string fileName = Guid.NewGuid() + "_" + imageFile.FileName;
                string path = Path.Combine(folder, fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                complaint.ImagePath = "/complaints/" + fileName;
            }

            _context.Complaints.Add(complaint);
            await _context.SaveChangesAsync();

            return RedirectToAction("ComplaintList");
        }

        public IActionResult ComplaintList()
        {
            var data = _context.Complaints.ToList();
            return View(data);
        }

        // ---------------- Notice ----------------
        public IActionResult Notice()
        {
            return View();
        }
        public IActionResult Maintenance()
        {
            // Dummy maintenance data
            ViewBag.Month = "May 2026";
            ViewBag.Amount = "1500.00";
            ViewBag.DueDate = "May 10, 2026";
            ViewBag.Status = "Unpaid";

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
            if (string.IsNullOrEmpty(hallType) || string.IsNullOrEmpty(purpose) || string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(endTime) || date == default)
            {
                TempData["ErrorMessage"] = "Please fill all required fields correctly!";
                return RedirectToAction(nameof(HallBooking));
            }

            try
            {
                var booking = new HallBooking
                {
                    HallType = hallType,
                    Date = date,
                    StartTime = TimeSpan.Parse(startTime),
                    EndTime = TimeSpan.Parse(endTime),
                    Purpose = purpose,
                    UserId = 1,
                    CreatedAt = DateTime.Now
                };

                _context.HallBookings.Add(booking);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Booking submitted successfully!";
                return RedirectToAction(nameof(MyBookings));
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Invalid time format or server error!";
                return RedirectToAction(nameof(HallBooking));
            }
        }

        // My Bookings
        public IActionResult MyBookings()
        {
            var data = _context.HallBookings.ToList();
            return View(data);
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