using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using Microsoft.AspNetCore.Mvc;
namespace AWWW_lab2_gr5.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var objAuthorList = _context.Authors.ToList();
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
            _context.Authors.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var authorFromDb = _context.Authors.FirstOrDefault(a => a.Id == id);

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
            _context.Authors.Update(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var authorFromDb = _context.Authors.FirstOrDefault(a => a.Id == id);

            if (authorFromDb == null)
            {
                return NotFound();
            }
            return View(authorFromDb);
        }

        // POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var authorFromDb = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (authorFromDb == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(authorFromDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
