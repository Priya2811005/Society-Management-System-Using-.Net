using Microsoft.AspNetCore.Mvc;
using Society_Management_System.Data;
using Society_Management_System.Models;
using System.Linq;

namespace Society_Management_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Visitors()
        {
            var data = _context.Visitors.ToList();
            return View(data);
        }

        public IActionResult Complaints()
        {
            var data = _context.Complaints.ToList();
            return View(data);
        }

        public IActionResult HallBookings()
        {
            var data = _context.HallBookings.ToList();
            return View(data);
        }
    }
}
