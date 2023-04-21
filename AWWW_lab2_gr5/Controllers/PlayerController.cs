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

        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new PlayerPositionData();
            viewModel.Players = await _context.Players
                .Include(p => p.Team)
                .ToListAsync();

            if (id != null)
            {
                var selectedPlayer = viewModel.Players
                    .Where(p => p.Id == id)
                    .Single();

                await _context.Entry(selectedPlayer).Collection(p => p.Positions).LoadAsync();
                viewModel.Positions = selectedPlayer.Positions;
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new PlayerAssignedData();

            viewModel.TeamList = new SelectList(await _context.Teams.ToListAsync(), "Id", "Name");
            viewModel.PositionList = new MultiSelectList(await _context.Positions.ToListAsync(), "Id", "Name");

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Player player, int[] selectedPositions)
        {
            if (selectedPositions.Any())
            {
                var playerPostions = await _context.Positions.Where(p => selectedPositions.Contains(p.Id)).ToListAsync();
                player.Positions = playerPostions;
            }

            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new PlayerAssignedData();

            viewModel.Player = await _context.Players
                .Include(p => p.Positions)
                .FirstAsync(p => p.Id == id);

            if (viewModel.Player == null)
            {
                return NotFound();
            }

            await GetPlayerAssignedData(viewModel, viewModel.Player);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PlayerAssignedData viewModel, int[] selectedPositions)
        {
            var playerToUpdate = await _context.Players
                .Include(p => p.Positions)
                .Where(p => p.Id == viewModel.Player.Id)
                .SingleOrDefaultAsync();

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
                var playerPostions = await _context.Positions.Where(p => selectedPositions.Contains(p.Id)).ToListAsync();
                playerToUpdate.Positions = playerPostions;
            }

            _context.Update(playerToUpdate);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new PlayerAssignedData();
            viewModel.Player = await _context.Players
                //.Include(p => p.Team)
                //.Include(p => p.Positions)
                .FirstAsync(p => p.Id == id);

            await GetPlayerAssignedData(viewModel, viewModel.Player);

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selectedPlayer = await _context.Players.FirstAsync(p => p.Id == id);

            _context.Players.Remove(selectedPlayer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task GetPlayerAssignedData(PlayerAssignedData viewModel, Player player)
        {
            viewModel.TeamList = new SelectList(await _context.Teams.ToListAsync(), "Id", "Name", player.TeamId);

            var selectedPositons = _context.Positions
                .Where(p => player.Positions.Contains(p))
                .Select(p => p.Id)
                .ToList();

            viewModel.PositionList = new MultiSelectList(await _context.Positions.ToListAsync(), "Id", "Name", selectedPositons);
        }
    }
}
