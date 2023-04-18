using AWWW_lab2_gr5.Data;
using AWWW_lab2_gr5.Models;
using AWWW_lab2_gr5.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
                var selectedPlayer = viewModel.Players
                    .Where(p => p.Id == id)
                    .Single();

                _context.Entry(selectedPlayer).Collection(p => p.Positions).Load();
                viewModel.Positions = selectedPlayer.Positions;
            }

            return View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new PlayerAssignedData();

            viewModel.TeamList = new SelectList(_context.Teams, "Id", "Name");
            viewModel.PositionList = new MultiSelectList(_context.Positions, "Id", "Name");

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Player player, int[] selectedPositions)
        {
            if (selectedPositions.Any())
            {
                var playerPostions = _context.Positions.Where(p => selectedPositions.Contains(p.Id)).ToList();
                player.Positions = playerPostions;
            }

            _context.Players.Add(player);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new PlayerAssignedData();

            viewModel.Player = _context.Players
                .Include(p => p.Positions)
                .First(p => p.Id == id);

            if (viewModel.Player == null)
            {
                return NotFound();
            }

            GetPlayerAssignedData(viewModel, viewModel.Player);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PlayerAssignedData viewModel, int[] selectedPositions)
        {
            var playerToUpdate = _context.Players.Include(p => p.Positions).Where(p => p.Id == viewModel.Player.Id).Single();

            if (playerToUpdate == null)
            {
                return NotFound();
            }

            playerToUpdate.FirstName = viewModel.Player.FirstName;
            playerToUpdate.LastName = viewModel.Player.LastName;
            playerToUpdate.Country = viewModel.Player.Country;
            playerToUpdate.BirthDate = viewModel.Player.BirthDate;
            playerToUpdate.TeamId = viewModel.Player.TeamId;

            playerToUpdate.Positions.Clear();

            if (selectedPositions.Any())
            {
                var playerPostions = _context.Positions.Where(p => selectedPositions.Contains(p.Id)).ToList();
                playerToUpdate.Positions = playerPostions;
            }

            _context.Update(playerToUpdate);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new PlayerAssignedData();
            viewModel.Player = _context.Players
                .Include(p => p.Team)
                .Include(p => p.Positions)
                .First(p => p.Id == id);

            GetPlayerAssignedData(viewModel, viewModel.Player);

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selectedPlayer = _context.Players.First(p => p.Id == id);

            _context.Players.Remove(selectedPlayer);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private void GetPlayerAssignedData(PlayerAssignedData viewModel, Player player)
        {
            viewModel.TeamList = new SelectList(_context.Teams, "Id", "Name", player.TeamId);

            var selectedPositons = _context.Positions
                .Where(p => player.Positions.Contains(p))
                .Select(p => p.Id)
                .ToList();

            viewModel.PositionList = new MultiSelectList(_context.Positions, "Id", "Name", selectedPositons);
        }
    }
}
