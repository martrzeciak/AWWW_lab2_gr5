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
            IEnumerable<EventType> eventTypeList = _context.EventTypes;
            return View(eventTypeList);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EventType obj)
        {
            _context.EventTypes.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventType = _context.EventTypes.FirstOrDefault(e => e.Id == id);

            if (eventType == null)
            {
                return NotFound();
            }

            return View(eventType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EventType eventType)
        {
            if (eventType == null)
            {
                return NotFound();
            }

            _context.EventTypes.Update(eventType);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var eventType = _context.EventTypes.FirstOrDefault(e => e.Id == id);

            if (eventType == null)
            {
                return NotFound();
            }

            _context.EventTypes.Remove(eventType);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
