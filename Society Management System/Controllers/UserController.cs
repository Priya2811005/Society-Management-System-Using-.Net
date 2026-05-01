using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Society_Management_System.Data;
using Society_Management_System.Models;

namespace Society_Management_System.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        // Single constructor with both dependencies
        public UserController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        // GET: User/AddComplaint
        public IActionResult AddComplaint()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AddComplaint(Complaint model, IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Image Upload
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        string folder = Path.Combine(_env.WebRootPath, "uploads");

                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);

                        string fileName = Guid.NewGuid() + "_" + ImageFile.FileName;
                        string path = Path.Combine(folder, fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(stream);
                        }

                        model.ImagePath = "/uploads/" + fileName;
                    }

                    model.Status = "Pending";
                    model.UserId = 1;

                    _context.Complaints.Add(model);
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Saved Successfully";
                    return RedirectToAction("AddComplaint");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                    TempData["Success"] = "Complaint submitted successfully!";
                }
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

        // GET PAGE
        public IActionResult AddVisitor()
        {
            return View();
        }

        // POST METHOD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVisitor(Visitor model)
        {
            // 🔥 REMOVE unwanted validation
            ModelState.Remove("UserId");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                TempData["Error"] = string.Join(", ", errors);
                return View(model);
            }

            try
            {
                model.UserId = 1; // TEMP
                model.RequestDate = DateTime.Now;

                _context.Visitors.Add(model);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Visitor Request Submitted Successfully!";
                return RedirectToAction("AddVisitor");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Database error: " + (ex.InnerException?.Message ?? ex.Message);
                return View(model);
            }
        }

        // ---------------- HALL BOOKING ----------------

        // GET
        public IActionResult HallBooking()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveHallBooking(HallBooking model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.UserId = 1; // Replace later with logged-in user
                    model.CreatedAt = DateTime.Now;

                    _context.HallBookings.Add(model);
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Hall booked successfully!";
                    return RedirectToAction("HallBooking");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                }
            }

            return View("HallBooking", model);
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