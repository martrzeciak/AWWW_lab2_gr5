using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr5.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var objAuthorList = _db.Authors.ToList();
            //IEnumerable<Author> objAuthorList = _db.Authors;
            return View(objAuthorList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent Cross-site request forgery
        public IActionResult Create(Author obj)
        {
                _db.Authors.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var authorFromDb = _db.Authors.FirstOrDefault(a => a.Id == id);

            if (authorFromDb == null) 
            {
                return NotFound();
            }
            return View(authorFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author obj)
        {
            _db.Authors.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var authorFromDb = _db.Authors.FirstOrDefault(a => a.Id == id);

            if (authorFromDb == null)
            {
                return NotFound();
            }
            return View(authorFromDb);
        }

        // POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var authorFromDb = _db.Authors.FirstOrDefault(x => x.Id == id);
            if (authorFromDb == null)
            {
                return NotFound();
            }

            _db.Authors.Remove(authorFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
