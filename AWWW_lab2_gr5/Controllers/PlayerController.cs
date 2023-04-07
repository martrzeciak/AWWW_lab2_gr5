using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using AWWW_lab2_gr5.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace AWWW_lab2_gr5.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            var viewModel = new PlayerPositionData();
            viewModel.Players = _context.Players
                .Include(p => p.Team)
                //.Include(p => p.PlayerPosition)
                //    .ThenInclude(p => p.Position)
                .ToList();

            if (id != null)
            {
                ViewData["PlayerId"] = id.Value;
                var selectedPlayer = viewModel.Players
                    .Where(pl => pl.Id == id)
                .Single();

                _context.Entry(selectedPlayer).Collection(p => p.PlayerPosition).Load();
                foreach (PlayerPosition pp in selectedPlayer.PlayerPosition)
                {
                    _context.Entry(pp).Reference(x => x.Position).Load();
                }
                viewModel.PlayerPositions = selectedPlayer.PlayerPosition;
               
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
            _context.Players.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
