using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using AWWW_lab2_gr5.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace AWWW_lab2_gr5.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PlayerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int? id)
        {
            var viewModel = new PlayerPositionData();
            viewModel.Players = _db.Players
                .Include(p => p.Team)
                .Include(p => p.PlayerPosition)
                    .ThenInclude(p => p.Position)
                .ToList();

            if (id != null)
            {
                ViewData["PlayerId"] = id.Value;
                Player player = viewModel.Players
                    .Where(pl => pl.Id == id)
                    .Single();
                viewModel.Positions = player.PlayerPosition.Select(s => s.Position);
            }


            return View(viewModel);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Player obj)
        {
            _db.Players.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
