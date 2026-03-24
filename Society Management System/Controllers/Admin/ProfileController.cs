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
        public IActionResult Logout()
        {
            // Clear session (optional but recommended)
            HttpContext.Session.Clear();

            // Redirect to Account/Login (outside Admin)
            return RedirectToAction("Login", "Account", new { area = "" });
        }
    }
}
