using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr5.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EventTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<EventType> objEventTypeList = _db.EventTypes;
            return View(objEventTypeList);
        }

        // GET
        public IActionResult Create() 
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent Cross-site request forgery
        public IActionResult Create(EventType obj)
        {
            _db.EventTypes.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
