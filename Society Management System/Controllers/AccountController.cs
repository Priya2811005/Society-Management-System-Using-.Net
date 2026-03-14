using Microsoft.AspNetCore.Mvc;

namespace Society_Management_System.Controllers
{
    public class AccountController : Controller
    {
        // Login Page
        public IActionResult Login()
        {
            return View();
        }

        // Forgot Password Page (GET)
        public IActionResult Forget()
        {
            return View();
        }

        // Forgot Password Form Submit (POST)
        [HttpPost]
        public IActionResult Forget(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                ViewBag.Error = "Please enter your email.";
                return View();
            }

            // Example logic (you can connect to database here)
            ViewBag.Message = "Password reset link sent to your email.";

            return View();
        }
    }
}