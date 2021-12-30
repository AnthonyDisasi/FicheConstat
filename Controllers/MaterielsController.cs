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
    public class MaterielsController : Controller
    {
        private readonly AppContextDb _context;

        public MaterielsController(AppContextDb context)
        {
            _context = context;
        }

        // GET: Materiels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materiels.ToListAsync());
        }

        // GET: Materiels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiel = await _context.Materiels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (materiel == null)
            {
                return NotFound();
            }

            return View(materiel);
        }

        // GET: Materiels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materiels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nom")] Materiel materiel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materiel);
        }

        // GET: Materiels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiel = await _context.Materiels.FindAsync(id);
            if (materiel == null)
            {
                return NotFound();
            }
            return View(materiel);
        }

        // POST: Materiels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Nom")] Materiel materiel)
        {
            if (id != materiel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterielExists(materiel.ID))
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
            return View(materiel);
        }

        // GET: Materiels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiel = await _context.Materiels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (materiel == null)
            {
                return NotFound();
            }

            return View(materiel);
        }

        // POST: Materiels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var materiel = await _context.Materiels.FindAsync(id);
            _context.Materiels.Remove(materiel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterielExists(string id)
        {
            return _context.Materiels.Any(e => e.ID == id);
        }
    }
}
