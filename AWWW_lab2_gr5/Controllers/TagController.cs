using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr5.Controllers
{
    public class TagController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TagController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Tag> objTagList = _context.Tags;
            return View(objTagList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent Cross-site request forgery
        public IActionResult Create(Tag obj)
        {
            _context.Tags.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = _context.Tags.FirstOrDefault(t => t.Id == id);

            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tag tag)
        {
            _context.Update(tag);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = _context.Tags.FirstOrDefault(t => t.Id == id);

            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var tag = _context.Tags.FirstOrDefault(t => t.Id == id);

            if (tag == null)
            {
                return NotFound();
            }

            _context.Remove(tag);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
