using Microsoft.AspNetCore.Mvc;
using Society_Management_System.Models;   
using System;
using System.Collections.Generic;

namespace Society_Management_System.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        // ---------------- Complaint ----------------

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

        public IActionResult ComplaintList()
        {
            return View();
        }

        // ---------------- Notice ----------------

        public IActionResult Notice()
        {
            
            return View();
        }
    }
}