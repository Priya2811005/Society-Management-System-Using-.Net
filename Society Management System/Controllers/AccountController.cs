using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Society_Management_System.Data;
using Society_Management_System.Models;
using System.Linq;
using System;

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

        // LOGIN POST
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ViewBag.Error = "Please enter email and password";
                return View();
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);

            if (user != null)
            {
                // Set Session
                HttpContext.Session.SetString("UserId", user.UserId.ToString());
                HttpContext.Session.SetString("Name", user.Name);
                HttpContext.Session.SetString("Role", user.Role);

                // Redirect based on role
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    return RedirectToAction("Dashboard", "User");
                }
            }

            ViewBag.Error = "Invalid Email or Password";
            return View();
        }

        // REGISTER PAGE
        public IActionResult Register()
        {
            return View();
        }

        // REGISTER POST
        [HttpPost]
        public IActionResult Register(string FullName, string Email, string Password, string ConfirmPassword)
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

            // Check if email exists
            if (_context.Users.Any(u => u.Email == Email))
            {
                ViewBag.Error = "Email already registered";
                return View();
            }

            var newUser = new User
            {
                Name = FullName,
                Email = Email,
                Password = Password,
                Role = "User",
                CreatedDate = DateTime.Now
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

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
            HttpContext.Session.SetString("ResetEmail", email);

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

            string email = HttpContext.Session.GetString("ResetEmail");
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                user.Password = password;
                _context.SaveChanges();
            }

            return RedirectToAction("ResetPasswordSuccess");
        }

        // PASSWORD RESET SUCCESS PAGE
        public IActionResult ResetPasswordSuccess()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}