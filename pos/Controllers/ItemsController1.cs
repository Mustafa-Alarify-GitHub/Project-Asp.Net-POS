using Microsoft.AspNetCore.Mvc;
using pos.Data;
using pos.Models;

namespace pos.Controllers
{
    public class ItemsController1 : Controller
    {
        private readonly AppDbContext _db;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _host;

        public ItemsController1(AppDbContext db, Microsoft.AspNetCore.Hosting.IHostingEnvironment host)
        {
            _db = db;
            _host = host;
        }

        // GET: ItemsController1
        public ActionResult Index()
        {
            IEnumerable<Items> data = _db.Items.ToList();
            return View(data);
        }

        // GET: ItemsController1/Details/5
        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.Find(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // GET: ItemsController1/Create
        public ActionResult Create()
        {
            IEnumerable<Catogry> data = _db.Catogries.ToList();
            return View(data);
        }

        // POST: ItemsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Items items)
        {
            if (ModelState.IsValid)
            {
                string imgUpload = Path.Combine(_host.WebRootPath, "Image");
                string imgPath = items.formFile.FileName;

                string fulPath =Path.Combine(imgUpload, imgPath);
                items.formFile.CopyTo(new FileStream(fulPath,FileMode.Create));
                items.Img = imgPath;

                _db.Items.Add(items);
                _db.SaveChanges();
                return Redirect("Index");
            }
            else
            {
                return View(items);
            }
        }

        // GET: ItemsController1/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var items = _db.Items.Find(id);
            if (items == null) return NotFound();
            return View(items);
        }

        // POST: ItemsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Items item)
        {
            //if (ModelState.IsValid)

            if (id == item.Id)

            {
                //var i = _db.Items.Find(id);

                //item.Img = i.Img;
                _db.Items.Update(item);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");

            }
        }

        // GET: ItemsController1/Delete/5
        public ActionResult Delete(int id)
        {
            var item = _db.Items.Find(id);
            _db.Items.Remove(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: ItemsController1/Delete/5
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
