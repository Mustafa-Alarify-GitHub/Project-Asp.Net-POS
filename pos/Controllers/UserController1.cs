using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using pos.Data;
using pos.Models;

namespace pos.Controllers
{
    public class UserController1 : Controller
    {
        private readonly AppDbContext _db;
        public UserController1(AppDbContext db)
        {
            _db = db;
        }
        // GET: UserController1
        public ActionResult Index()
        {
          
            return View();
        }
        public ActionResult Get_All_Users()
        {
            IEnumerable<User> data = _db.Users.ToList();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {

            var user_login = _db.Users.
                    FirstOrDefault(i =>
                    i.Email == user.Email && i.Password == user.Password);

            if (user_login != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Password", "This Account not Found!");
            return View("Index");
            }
        }

        // GET: UserController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return Redirect("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: UserController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController1/Delete/5
        public ActionResult Delete(int id ,User user)
        {
            if (id == user.Id)

            {
                _db.Users.Remove(user);
                _db.SaveChanges();
                return RedirectToAction("Get_All_Users");
            }

            return NotFound();
        }

        // POST: UserController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
