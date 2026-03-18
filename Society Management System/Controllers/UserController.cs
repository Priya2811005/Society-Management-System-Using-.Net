using Microsoft.AspNetCore.Mvc;

namespace Society_Management_System.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


       
            public IActionResult AddComplaint()
            {
                return View();
            }
        
    }
}
