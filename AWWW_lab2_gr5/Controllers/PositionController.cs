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
    }
}
