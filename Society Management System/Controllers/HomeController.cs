using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Society_Management_System.Models;

namespace Society_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Login Page
        public IActionResult Login()
        {
            return View();
        }

        // Home Page
        public IActionResult Index()
        {
            return View();
        }

        // About Page
        public IActionResult About()
        {
            return View();
        }

        // Why Choose Us Page
        public IActionResult WhyChooseUs()
        {
            return View();
        }

        // Apartments Page
        public IActionResult Apartments()
        {
            return View();
        }

        // Contact Us Page
        public IActionResult ContactUs()
        {
            return View();
        }

        // Handle Contact Form Submission
        [HttpPost]
        public IActionResult SendMessage(string Name, string Email, string Message)
        {
            // You can add database save logic here if needed

            // Set success message
            TempData["SuccessMessage"] = "Message Sent Successfully!";

            // Redirect to ContactUs page (important for popup)
            return RedirectToAction("ContactUs");
        }

        // Services Page
        public IActionResult Services()
        {
            return View();
        }

        // Privacy Page
        public IActionResult Privacy()
        {
            return View();
        }

        // Error Page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}