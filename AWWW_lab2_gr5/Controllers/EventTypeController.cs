using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr5.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var eventTypeList = await _context.EventTypes.ToListAsync();

            return View(eventTypeList);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventType obj)
        {
            _context.EventTypes.Add(obj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventType = await _context.EventTypes.FirstOrDefaultAsync(e => e.Id == id);

            if (eventType == null)
            {
                return NotFound();
            }

            return View(eventType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EventType eventType)
        {
            if (eventType == null)
            {
                return NotFound();
            }

            _context.EventTypes.Update(eventType);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventType = await _context.EventTypes.FirstOrDefaultAsync(e => e.Id == id);

            if (eventType == null)
            {
                return NotFound();
            }

            return View(eventType);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var eventType = await _context.EventTypes.FirstOrDefaultAsync(e => e.Id == id);

            if (eventType == null)
            {
                return NotFound();
            }

            _context.EventTypes.Remove(eventType);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
