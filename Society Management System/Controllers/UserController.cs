using Microsoft.AspNetCore.Mvc;

namespace Society_Management_System.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AddComplain()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComplain(string subject, string description)
        {
            ViewBag.Message = "Complaint Submitted Successfully!";
            return View();
        }

        public IActionResult ComplaintList(string subject, string description)
        {
            ViewBag.Message = "Complaint Submitted Successfully!";
            return View();
        }

        public IActionResult Notice()
        {
            return View();
        }
    }
}