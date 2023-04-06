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
        
        // GET
        public IActionResult Create() 
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent Cross-site request forgery
        public IActionResult Create(League obj)
        {
            _context.Leagues.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
