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
    public class GameScreenshotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameScreenshotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GameScreenshots
        public async Task<IActionResult> Index()
        {
            return View(await _context.GameScreenshots.ToListAsync());
        }

        // GET: GameScreenshots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameScreenshot = await _context.GameScreenshots
                .FirstOrDefaultAsync(m => m.GameScreenshotId == id);
            if (gameScreenshot == null)
            {
                return NotFound();
            }

            return View(gameScreenshot);
        }

        // GET: GameScreenshots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameScreenshots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameScreenshotId,GameScreenshotUrl,GameScreenshotDescription")] GameScreenshot gameScreenshot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameScreenshot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameScreenshot);
        }

        // GET: GameScreenshots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameScreenshot = await _context.GameScreenshots.FindAsync(id);
            if (gameScreenshot == null)
            {
                return NotFound();
            }
            return View(gameScreenshot);
        }

        // POST: GameScreenshots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameScreenshotId,GameScreenshotUrl,GameScreenshotDescription")] GameScreenshot gameScreenshot)
        {
            if (id != gameScreenshot.GameScreenshotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameScreenshot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameScreenshotExists(gameScreenshot.GameScreenshotId))
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
            return View(gameScreenshot);
        }

        // GET: GameScreenshots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameScreenshot = await _context.GameScreenshots
                .FirstOrDefaultAsync(m => m.GameScreenshotId == id);
            if (gameScreenshot == null)
            {
                return NotFound();
            }

            return View(gameScreenshot);
        }

        // POST: GameScreenshots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameScreenshot = await _context.GameScreenshots.FindAsync(id);
            if (gameScreenshot != null)
            {
                _context.GameScreenshots.Remove(gameScreenshot);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameScreenshotExists(int id)
        {
            return _context.GameScreenshots.Any(e => e.GameScreenshotId == id);
        }
    }
}
