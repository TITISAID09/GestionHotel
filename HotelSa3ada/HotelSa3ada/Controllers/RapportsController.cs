using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelSa3ada.Models;

namespace HotelSa3ada.Controllers
{
    public class RapportsController : Controller
    {
        private readonly Hotelsa3adaContext _context;

        public RapportsController(Hotelsa3adaContext context)
        {
            _context = context;
        }

        // GET: Rapports
        public async Task<IActionResult> Index()
        {
            var hotelsa3adaContext = _context.Rapports.Include(r => r.IdUtilisateurNavigation);
            return View(await hotelsa3adaContext.ToListAsync());
        }

        // GET: Rapports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapport = await _context.Rapports
                .Include(r => r.IdUtilisateurNavigation)
                .FirstOrDefaultAsync(m => m.IdRapport == id);
            if (rapport == null)
            {
                return NotFound();
            }

            return View(rapport);
        }

        // GET: Rapports/Create
        public IActionResult Create()
        {
            ViewData["IdUtilisateur"] = new SelectList(_context.Utilisateurs, "IdUtilisateur", "IdUtilisateur");
            return View();
        }

        // POST: Rapports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRapport,DateGeneration,Contenu,IdUtilisateur")] Rapport rapport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rapport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUtilisateur"] = new SelectList(_context.Utilisateurs, "IdUtilisateur", "IdUtilisateur", rapport.IdUtilisateur);
            return View(rapport);
        }

        // GET: Rapports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapport = await _context.Rapports.FindAsync(id);
            if (rapport == null)
            {
                return NotFound();
            }
            ViewData["IdUtilisateur"] = new SelectList(_context.Utilisateurs, "IdUtilisateur", "IdUtilisateur", rapport.IdUtilisateur);
            return View(rapport);
        }

        // POST: Rapports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRapport,DateGeneration,Contenu,IdUtilisateur")] Rapport rapport)
        {
            if (id != rapport.IdRapport)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rapport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RapportExists(rapport.IdRapport))
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
            ViewData["IdUtilisateur"] = new SelectList(_context.Utilisateurs, "IdUtilisateur", "IdUtilisateur", rapport.IdUtilisateur);
            return View(rapport);
        }

        // GET: Rapports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapport = await _context.Rapports
                .Include(r => r.IdUtilisateurNavigation)
                .FirstOrDefaultAsync(m => m.IdRapport == id);
            if (rapport == null)
            {
                return NotFound();
            }

            return View(rapport);
        }

        // POST: Rapports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rapport = await _context.Rapports.FindAsync(id);
            if (rapport != null)
            {
                _context.Rapports.Remove(rapport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RapportExists(int id)
        {
            return _context.Rapports.Any(e => e.IdRapport == id);
        }
    }
}
