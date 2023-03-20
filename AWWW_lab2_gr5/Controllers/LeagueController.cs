using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr5.Controllers
{
    public class LeagueController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LeagueController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<League> objLeagueList = _db.Leagues;
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
            _db.Leagues.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
