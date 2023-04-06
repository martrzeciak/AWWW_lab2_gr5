using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr5.Controllers
{
    public class PositionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PositionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Position> objPositionList = _db.Positions;
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
            _db.Positions.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var positionFromDb = _db.Positions.FirstOrDefault(a => a.Id == id);

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
            _db.Positions.Update(obj);
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

            var positionFromDb = _db.Positions.FirstOrDefault(a => a.Id == id);

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
            var positionFromDb = _db.Positions.FirstOrDefault(x => x.Id == id);
            if (positionFromDb == null)
            {
                return NotFound();
            }

            _db.Positions.Remove(positionFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
