using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmashAdvanced.Data;
using SmashAdvanced.Models;

namespace SmashAdvanced.Controllers
{
    public class GamePlatformsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamePlatformsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GamePlatforms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GamePlatforms.Include(g => g.Game).Include(g => g.Platform);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GamePlatforms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamePlatform = await _context.GamePlatforms
                .Include(g => g.Game)
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(m => m.GamePlatformId == id);
            if (gamePlatform == null)
            {
                return NotFound();
            }

            return View(gamePlatform);
        }

        // GET: GamePlatforms/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId");
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "PlatformId");
            return View();
        }

        // POST: GamePlatforms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GamePlatformId,GameId,PlatformId")] GamePlatform gamePlatform)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamePlatform);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", gamePlatform.GameId);
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "PlatformId", gamePlatform.PlatformId);
            return View(gamePlatform);
        }

        // GET: GamePlatforms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamePlatform = await _context.GamePlatforms.FindAsync(id);
            if (gamePlatform == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", gamePlatform.GameId);
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "PlatformId", gamePlatform.PlatformId);
            return View(gamePlatform);
        }

        // POST: GamePlatforms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GamePlatformId,GameId,PlatformId")] GamePlatform gamePlatform)
        {
            if (id != gamePlatform.GamePlatformId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamePlatform);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamePlatformExists(gamePlatform.GamePlatformId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", gamePlatform.GameId);
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "PlatformId", gamePlatform.PlatformId);
            return View(gamePlatform);
        }

        // GET: GamePlatforms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamePlatform = await _context.GamePlatforms
                .Include(g => g.Game)
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(m => m.GamePlatformId == id);
            if (gamePlatform == null)
            {
                return NotFound();
            }

            return View(gamePlatform);
        }

        // POST: GamePlatforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gamePlatform = await _context.GamePlatforms.FindAsync(id);
            if (gamePlatform != null)
            {
                _context.GamePlatforms.Remove(gamePlatform);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamePlatformExists(int id)
        {
            return _context.GamePlatforms.Any(e => e.GamePlatformId == id);
        }
    }
}
