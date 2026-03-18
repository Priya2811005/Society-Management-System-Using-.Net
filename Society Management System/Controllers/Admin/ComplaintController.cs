using Microsoft.AspNetCore.Mvc;

namespace Society_Management_System.Controllers.Admin
{
    [Route("Admin/[controller]/[action]")]
    public class ComplaintController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/Complaint/Index.cshtml");
        }
    }
}
