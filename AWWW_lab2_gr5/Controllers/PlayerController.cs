using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using AWWW_lab2_gr5.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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


        // GET
        public IActionResult Edit(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var player = _context.Players
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            PopulateTeamsDropDownList(player.TeamId);

            return View(player);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Player obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            _context.Players.Update(obj);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        private void PopulateTeamsDropDownList(object selectedTeam = null)
        {
            var teamQuery = _context.Teams
                                .OrderBy(T => T.Name);

            ViewBag.TeamId = new SelectList(teamQuery, "Id", "Name", selectedTeam);
        }

    }
}
