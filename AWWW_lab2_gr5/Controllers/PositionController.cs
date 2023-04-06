using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr5.Controllers
{
    public class PositionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PositionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Position> objPositionList = _context.Positions;
            return View(objPositionList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Position obj)
        {
            _context.Positions.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var positionFromDb = _context.Positions.FirstOrDefault(a => a.Id == id);

            if (positionFromDb == null)
            {
                return NotFound();
            }
            return View(positionFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Position obj)
        {
            _context.Positions.Update(obj);
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

            var positionFromDb = _context.Positions.FirstOrDefault(a => a.Id == id);

            if (positionFromDb == null)
            {
                return NotFound();
            }
            return View(positionFromDb);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var positionFromDb = _context.Positions.FirstOrDefault(x => x.Id == id);
            if (positionFromDb == null)
            {
                return NotFound();
            }

            _context.Positions.Remove(positionFromDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
