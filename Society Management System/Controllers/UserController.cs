using Microsoft.AspNetCore.Mvc;

namespace Society_Management_System.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AddComplaint()
        {
            return View();
        }

        public IActionResult Notice()
        {
            return View();
        }
    }
}