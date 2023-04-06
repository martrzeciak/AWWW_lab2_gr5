using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr5.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<EventType> objEventTypeList = _context.EventTypes;
            return View(objEventTypeList);
        }

        // GET
        public IActionResult Create() 
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EventType obj)
        {
            _context.EventTypes.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
