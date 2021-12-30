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
    public class IntervenantsController : Controller
    {
        private readonly AppContextDb _context;

        public IntervenantsController(AppContextDb context)
        {
            _context = context;
        }

        // GET: Intervenants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Intervenants.ToListAsync());
        }

        // GET: Intervenants/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervenant = await _context.Intervenants
                .FirstOrDefaultAsync(m => m.ID == id);
            if (intervenant == null)
            {
                return NotFound();
            }

            return View(intervenant);
        }

        // GET: Intervenants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Intervenants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nom")] Intervenant intervenant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(intervenant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(intervenant);
        }

        // GET: Intervenants/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervenant = await _context.Intervenants.FindAsync(id);
            if (intervenant == null)
            {
                return NotFound();
            }
            return View(intervenant);
        }

        // POST: Intervenants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Nom")] Intervenant intervenant)
        {
            if (id != intervenant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intervenant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntervenantExists(intervenant.ID))
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
            return View(intervenant);
        }

        // GET: Intervenants/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervenant = await _context.Intervenants
                .FirstOrDefaultAsync(m => m.ID == id);
            if (intervenant == null)
            {
                return NotFound();
            }

            return View(intervenant);
        }

        // POST: Intervenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var intervenant = await _context.Intervenants.FindAsync(id);
            _context.Intervenants.Remove(intervenant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntervenantExists(string id)
        {
            return _context.Intervenants.Any(e => e.ID == id);
        }
    }
}
