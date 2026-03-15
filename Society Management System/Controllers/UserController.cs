using Microsoft.AspNetCore.Mvc;

namespace Society_Management_System.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Complaint()
        {
            return View();
        }
    }
}
