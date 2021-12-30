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
    public class RenseignementsController : Controller
    {
        private readonly AppContextDb _context;

        public RenseignementsController(AppContextDb context)
        {
            _context = context;
        }

        // GET: Renseignements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Renseignements.ToListAsync());
        }

        // GET: Renseignements/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renseignement = await _context.Renseignements
                .FirstOrDefaultAsync(m => m.ID == id);
            if (renseignement == null)
            {
                return NotFound();
            }

            return View(renseignement);
        }

        // GET: Renseignements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Renseignements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,NumeroInventaire,NumeroSerie,NumTicket,Intervenant,Constat,Priorite,IdUser,Noms,Materiel,DescriptionProbleme,DecisionRemarqueIT")] Renseignement renseignement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(renseignement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(renseignement);
        }

        // GET: Renseignements/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renseignement = await _context.Renseignements.FindAsync(id);
            if (renseignement == null)
            {
                return NotFound();
            }
            return View(renseignement);
        }

        // POST: Renseignements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Date,NumeroInventaire,NumeroSerie,NumTicket,Intervenant,Constat,Priorite,IdUser,Noms,Materiel,DescriptionProbleme,DecisionRemarqueIT")] Renseignement renseignement)
        {
            if (id != renseignement.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renseignement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RenseignementExists(renseignement.ID))
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
            return View(renseignement);
        }

        // GET: Renseignements/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renseignement = await _context.Renseignements
                .FirstOrDefaultAsync(m => m.ID == id);
            if (renseignement == null)
            {
                return NotFound();
            }

            return View(renseignement);
        }

        // POST: Renseignements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var renseignement = await _context.Renseignements.FindAsync(id);
            _context.Renseignements.Remove(renseignement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RenseignementExists(string id)
        {
            return _context.Renseignements.Any(e => e.ID == id);
        }
    }
}
