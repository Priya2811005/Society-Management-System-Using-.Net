//using Microsoft.AspNetCore.Mvc;
//using Society_Management_System.Data;
//using Society_Management_System.Models;

//namespace Society_Management_System.Controllers
//{
//    public class UserController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public UserController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Dashboard()
//        {
//            return View();
//        }

//        // Complaint
//        [HttpGet]
//        public IActionResult AddComplaint()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult AddComplaint(Complaint model)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Complaints.Add(model);
//                _context.SaveChanges();
//                return RedirectToAction("Dashboard");
//            }
//            return View(model);
//        }

//        public IActionResult Notice()
//        {
//            return View();
//        }

//        public IActionResult Maintenance()
//        {
//            return View();
//        }

//        public IActionResult AddVisitor()
//        {
//            return View();
//        }

//        public IActionResult HallBooking()
//        {
//            return View();
//        }

//        public IActionResult Profile()
//        {
//            ViewBag.Name = "Trushali Sorathiya";
//            ViewBag.Email = "trushali@gmail.com";
//            ViewBag.Contact = "9876543210";
//            ViewBag.Flat = "101";
//            ViewBag.Wing = "A";

//            return View();
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using Society_Management_System.Data;
using Society_Management_System.Models;

namespace Society_Management_System.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public UserController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        // GET
        public IActionResult AddComplaint()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult AddComplaint(Complaint model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Image Upload
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                        string path = Path.Combine(folder, fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            ImageFile.CopyTo(stream);
                        }

                        model.ImagePath = "/uploads/" + fileName;
                    }

                    model.Status = "Pending";
                    model.UserId = 1;

                    _context.Complaints.Add(model);
                    int result = _context.SaveChanges();

                    // DEBUG
                    Console.WriteLine("Saved Rows: " + result);

                    TempData["Success"] = "Complaint saved successfully";

                    return RedirectToAction("AddComplaint");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("ModelState Invalid");
            }

            return View(model);
        }
    }
}