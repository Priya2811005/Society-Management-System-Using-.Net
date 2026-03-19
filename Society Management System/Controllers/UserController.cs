using Microsoft.AspNetCore.Mvc;

namespace Society_Management_System.Controllers
{
    [Route("User/[controller]/[action]")]
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
            return Content("Notice page working");
        }
    }
}
