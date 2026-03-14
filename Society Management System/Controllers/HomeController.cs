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
        public IActionResult Login()
        {
            return View();

        }

        public IActionResult Index()
        {
            return View();

        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(string Name, string Email, string Message)
        {
            ViewBag.Message = "Message Sent Successfully!";
            return View("ContactUs");
        }

        public IActionResult WhyChooseUs()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
