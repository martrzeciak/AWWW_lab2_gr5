using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr5.Controllers
{
    public class TagController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TagController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Tag> objTagList = _db.Tags;
            return View(objTagList);
        }

        // GET
        public IActionResult AddNewTag()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent Cross-site request forgery
        public IActionResult AddNewTag(Tag obj)
        {
            _db.Tags.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
