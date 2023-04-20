using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr5.Controllers
{
    public class LeagueController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeagueController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<League> objLeagueList = _context.Leagues;
            return View(objLeagueList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(League obj)
        {
            _context.Leagues.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = _context.Leagues.FirstOrDefault(l => l.Id == id);

            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(League league)
        {
            if (league == null)
            {
                return NotFound();
            }

            _context.Leagues.Update(league);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = _context.Leagues.FirstOrDefault(l => l.Id == id);

            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var league = _context.Leagues.FirstOrDefault(l => l.Id == id);

            if (league == null)
            {
                return NotFound();
            }

            _context.Leagues.Remove(league);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
