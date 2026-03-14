using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Society_Management_System.Controllers
{
    public class AccountController : Controller
    {

        // LOGIN PAGE
        public IActionResult Login()
        {
            return View();
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
        public IActionResult ResetPassword(string password)
        {
            ViewBag.Message = "Password Reset Successfully";
            return View();
        }
    }
}