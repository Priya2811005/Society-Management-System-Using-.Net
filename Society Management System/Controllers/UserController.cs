using Microsoft.AspNetCore.Mvc;

namespace Society_Management_System.Controllers
{
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {
            // Sample data (later you can fetch from DB)
            var users = new List<UserModel>()
            {
                new UserModel { Name="Anuj Patel", FlatNo="101", Wing="A" },
                new UserModel { Name="Maya Desai", FlatNo="104", Wing="G" },
                new UserModel { Name="Priya Desai", FlatNo="701", Wing="H" },
                new UserModel { Name="Dev Bhut", FlatNo="201", Wing="B" },
                new UserModel { Name="Shruti Shah", FlatNo="402", Wing="C" },
                new UserModel { Name="Nisha Verma", FlatNo="503", Wing="E" }
            };

            return View(users);
        }
        // Simple Model
        public class UserModel
        {
            public string Name { get; set; }
            public string FlatNo { get; set; }
            public string Wing { get; set; }
        }
    }
}