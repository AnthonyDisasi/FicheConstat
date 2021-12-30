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
    public class ConstatsController : Controller
    {
        private readonly AppContextDb _context;

        public ConstatsController(AppContextDb context)
        {
            _context = context;
        }

        // GET: Constats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Constats.ToListAsync());
        }

        // GET: Constats/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constat = await _context.Constats
                .FirstOrDefaultAsync(m => m.ID == id);
            if (constat == null)
            {
                return NotFound();
            }

            return View(constat);
        }

        // GET: Constats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Constats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nom")] Constat constat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(constat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(constat);
        }

        // GET: Constats/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constat = await _context.Constats.FindAsync(id);
            if (constat == null)
            {
                return NotFound();
            }
            return View(constat);
        }

        // POST: Constats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Nom")] Constat constat)
        {
            if (id != constat.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(constat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConstatExists(constat.ID))
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
            return View(constat);
        }

        // GET: Constats/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constat = await _context.Constats
                .FirstOrDefaultAsync(m => m.ID == id);
            if (constat == null)
            {
                return NotFound();
            }

            return View(constat);
        }

        // POST: Constats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var constat = await _context.Constats.FindAsync(id);
            _context.Constats.Remove(constat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConstatExists(string id)
        {
            return _context.Constats.Any(e => e.ID == id);
        }
    }
}
