using Microsoft.AspNetCore.Mvc;
using Society_Management_System.Data;
using Society_Management_System.Models;
using BCrypt.Net;

namespace Society_Management_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string fullName, string email, string password, string role)
        {
            if (ModelState.IsValid)
            {
                // Create the Admin object
                var admin = new Society_Management_System.Models.Admin
                {
                    FullName = fullName,
                    Email = email,
                    // Hashing the password using BCrypt
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                    Role = role,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };

                _context.Admins.Add(admin);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // Example Login method
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Email == email && a.IsActive);
            
            if (admin != null && BCrypt.Net.BCrypt.Verify(password, admin.PasswordHash))
            {
                // Success: Implement session or cookie authentication here
                return RedirectToAction("Dashboard");
            }

            ModelState.AddModelError("", "Invalid email or password.");
            return View();
        }
    }
}
