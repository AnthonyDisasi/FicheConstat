#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FicheConstat.Data;
using FicheConstat.Models;

namespace FicheConstat.Controllers
{
    public class PrioritesController : Controller
    {
        private readonly AppContextDb _context;

        public PrioritesController(AppContextDb context)
        {
            _context = context;
        }

        // GET: Priorites
        public async Task<IActionResult> Index()
        {
            return View(await _context.Priorites.ToListAsync());
        }

        // GET: Priorites/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priorite = await _context.Priorites
                .FirstOrDefaultAsync(m => m.ID == id);
            if (priorite == null)
            {
                return NotFound();
            }

            return View(priorite);
        }

        // GET: Priorites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Priorites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nom")] Priorite priorite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(priorite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(priorite);
        }

        // GET: Priorites/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priorite = await _context.Priorites.FindAsync(id);
            if (priorite == null)
            {
                return NotFound();
            }
            return View(priorite);
        }

        // POST: Priorites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Nom")] Priorite priorite)
        {
            if (id != priorite.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priorite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrioriteExists(priorite.ID))
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
            return View(priorite);
        }

        // GET: Priorites/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priorite = await _context.Priorites
                .FirstOrDefaultAsync(m => m.ID == id);
            if (priorite == null)
            {
                return NotFound();
            }

            return View(priorite);
        }

        // POST: Priorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var priorite = await _context.Priorites.FindAsync(id);
            _context.Priorites.Remove(priorite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrioriteExists(string id)
        {
            return _context.Priorites.Any(e => e.ID == id);
        }
    }
}
