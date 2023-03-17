using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<Author> objAuthorList = _db.Authors;
            return View(objAuthorList);
        }

        // GET
        public IActionResult AddNewAuthor()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent Cross-site request forgery
        public IActionResult AddNewAuthor(Author obj)
        {
            if (ModelState.IsValid)
            {
                _db.Authors.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(obj);   
        }
    }
}
