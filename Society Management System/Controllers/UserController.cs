using Microsoft.AspNetCore.Mvc;
using Society_Management_System.Data;
using Society_Management_System.Models;
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

            if (imageFile != null && imageFile.Length > 0)
            {
                string folder = Path.Combine(_environment.WebRootPath ?? string.Empty, "complaints");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string safeFileName = Path.GetFileName(imageFile.FileName);
                string fileName = Guid.NewGuid() + "_" + safeFileName;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVisitor(string VisitorName, string Purpose, string ContactNumber, string VisitDetails)
        {
            if (string.IsNullOrEmpty(VisitorName) || string.IsNullOrEmpty(Purpose) || string.IsNullOrEmpty(ContactNumber) || string.IsNullOrEmpty(VisitDetails))
            {
                ViewBag.Message = "All fields are required!";
                return View();
            }

            var visitor = new Visitor
            {
                VisitorName = VisitorName,
                Purpose = Purpose,
                ContactNumber = ContactNumber,
                VisitDetails = VisitDetails,
                UserId = 1,
                RequestDate = DateTime.Now
            };

            _context.Visitors.Add(visitor);
            await _context.SaveChangesAsync();

            return RedirectToAction("VisitorList");
        }

        public IActionResult VisitorList()
        {
            var data = _context.Visitors.ToList();
            return View(data);
        }

        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var visitor = await _context.Visitors.FindAsync(id);
            if (visitor != null)
            {
                _context.Visitors.Remove(visitor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("VisitorList");
        }

        // ---------------- Hall Booking ----------------
        public IActionResult HallBooking()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveHallBooking(string hallType, DateTime date, TimeSpan startTime, TimeSpan endTime, string purpose)
        {
            if (string.IsNullOrEmpty(hallType) || string.IsNullOrEmpty(purpose))
            {
                ViewBag.Message = "Please fill all required fields!";
                return View("HallBooking");
            }

            var booking = new HallBooking
            {
                HallType = hallType,
                Date = date,
                StartTime = startTime,
                EndTime = endTime,
                Purpose = purpose,
                UserId = 1,
                CreatedAt = DateTime.Now
            };

            _context.HallBookings.Add(booking);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyBookings");
        }

        public IActionResult MyBookings()
        {
            var data = _context.HallBookings.ToList();
            return View(data);
        }

        // ---------------- Profile ----------------
        public IActionResult Profile()
        {
            return View();
        }
    }
}