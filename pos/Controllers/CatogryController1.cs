using Microsoft.AspNetCore.Mvc;
using pos.Data;
using pos.Models;

namespace pos.Controllers
{
    public class CatogryController1 : Controller
    {
        private readonly AppDbContext _db;
        public CatogryController1(AppDbContext db)
        {
            _db = db;
        }

        // GET: CatogryController1
        public ActionResult Index()
        {
            IEnumerable<Catogry> data = _db.Catogries.ToList();
            return View(data);
        }

        // GET: CatogryController1/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            } 
            var item = _db.Items.Find(id);
            if(item == null) return NotFound();
            return View(item);
        }

        // GET: CatogryController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatogryController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Catogry catogry)
        {
            if (ModelState.IsValid)
            {
             _db.Catogries.Add(catogry);
            _db.SaveChanges();  
            return Redirect("Index");
            }
            else
            {
                return View(catogry);
            }
           
        }

        // GET: CatogryController1/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cat = _db.Catogries.Find(id);
            if (cat == null) return NotFound();
            return View(cat);
            //var cat = _db.Catogries.FirstOrDefault(c => c.Id == id);

        }

        // POST: CatogryController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Catogry catogry)
        {
           
            //if (ModelState.IsValid)
            if (id == catogry.Id)
                {
                _db.Catogries.Update(catogry);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");

            }
        }

        // GET: CatogryController1/Delete/5
        public ActionResult Delete(int id, Catogry catogry)
        {
            _db.Catogries.Remove(catogry);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // POST: CatogryController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection, Catogry catogry)
        {
            _db.Catogries.Remove(catogry);
            _db.SaveChanges();
            return Redirect("Index");
        }
    }
}
