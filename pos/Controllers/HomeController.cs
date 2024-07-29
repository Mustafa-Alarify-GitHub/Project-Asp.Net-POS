using Microsoft.AspNetCore.Mvc;
using pos.Data;
using pos.Models;
using System.Diagnostics;

namespace pos.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
     


        public IActionResult Index()
        {
            int userCount = _db.Users.Count();
            int ItemsCount = _db.Items.Count();
            int catCount = _db.Catogries.Count();
            int[] count=new int[3] { userCount,ItemsCount,catCount};
            return View(count);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}