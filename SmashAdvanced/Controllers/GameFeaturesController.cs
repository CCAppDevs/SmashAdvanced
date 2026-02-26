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
    public class GameFeaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameFeaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GameFeatures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Features.ToListAsync());
        }

        // GET: GameFeatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameFeature = await _context.Features
                .FirstOrDefaultAsync(m => m.GameFeatureId == id);
            if (gameFeature == null)
            {
                return NotFound();
            }

            return View(gameFeature);
        }

        // GET: GameFeatures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameFeatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameFeatureId,GameFeatureText")] GameFeature gameFeature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameFeature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameFeature);
        }

        // GET: GameFeatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameFeature = await _context.Features.FindAsync(id);
            if (gameFeature == null)
            {
                return NotFound();
            }
            return View(gameFeature);
        }

        // POST: GameFeatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameFeatureId,GameFeatureText")] GameFeature gameFeature)
        {
            if (id != gameFeature.GameFeatureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameFeature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameFeatureExists(gameFeature.GameFeatureId))
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
            return View(gameFeature);
        }

        // GET: GameFeatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameFeature = await _context.Features
                .FirstOrDefaultAsync(m => m.GameFeatureId == id);
            if (gameFeature == null)
            {
                return NotFound();
            }

            return View(gameFeature);
        }

        // POST: GameFeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameFeature = await _context.Features.FindAsync(id);
            if (gameFeature != null)
            {
                _context.Features.Remove(gameFeature);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameFeatureExists(int id)
        {
            return _context.Features.Any(e => e.GameFeatureId == id);
        }
    }
}
