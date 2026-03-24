using Microsoft.AspNetCore.Mvc;

namespace Society_Management_System.Controllers.Admin
{
    [Route("Admin/[controller]/[action]")]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/Profile/Index.cshtml");
        }
    }
}
