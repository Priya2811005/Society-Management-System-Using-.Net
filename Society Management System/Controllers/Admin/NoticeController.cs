using Microsoft.AspNetCore.Mvc;

namespace Society_Management_System.Controllers.Admin
{
    [Route("Admin/[controller]/[action]")]
    public class NoticeController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/Notice/Index.cshtml");
        }
    }
}
