using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Society_Management_System.Data;

namespace Society_Management_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LOGIN PAGE
        public IActionResult Login()
        {
            return View();
        }

        // REGISTER PAGE
        public IActionResult Register()
        {
            return View();
        }

        // REGISTER POST
        [HttpPost]
        public IActionResult Register(string FullName, string Email, string Phone, string Password, string ConfirmPassword)
        {
            if (string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ViewBag.Error = "All fields are required";
                return View();
            }

            if (Password != ConfirmPassword)
            {
                ViewBag.Error = "Passwords do not match";
                return View();
            }

            ViewBag.Message = "Registration Successful! Please Login.";
            return RedirectToAction("Login");
        }

        // FORGOT PASSWORD PAGE
        public IActionResult Forget()
        {
            return View();
        }

        // SEND OTP
        [HttpPost]
        public IActionResult SendOTP(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Error = "Please enter email";
                return View("Forget");
            }

            Random rand = new Random();
            int otp = rand.Next(100000, 999999);

            HttpContext.Session.SetString("OTP", otp.ToString());
            HttpContext.Session.SetString("Email", email);

            ViewBag.Message = "OTP Sent Successfully";

            return RedirectToAction("VerifyOTP");
        }

        // VERIFY OTP PAGE
        public IActionResult VerifyOTP()
        {
            return View();
        }

        // VERIFY OTP POST
        [HttpPost]
        public IActionResult VerifyOTP(string otp)
        {
            string sessionOTP = HttpContext.Session.GetString("OTP");

            if (otp == sessionOTP)
            {
                return RedirectToAction("ResetPassword");
            }

            ViewBag.Error = "Invalid OTP";
            return View();
        }

        // RESET PASSWORD PAGE
        public IActionResult ResetPassword()
        {
            return View();
        }

        // RESET PASSWORD POST
        [HttpPost]
        public IActionResult ResetPassword(string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                ViewBag.Error = "Please fill all fields";
                return View();
            }

            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match";
                return View();
            }

            // Here you would normally update password in database

            return RedirectToAction("ResetPasswordSuccess");
        }

        // PASSWORD RESET SUCCESS PAGE
        public IActionResult ResetPasswordSuccess()
        {
            return View();
        }

    }
}