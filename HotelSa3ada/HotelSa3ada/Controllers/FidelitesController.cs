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
    public class FidelitesController : Controller
    {
        private readonly Hotelsa3adaContext _context;

        public FidelitesController(Hotelsa3adaContext context)
        {
            _context = context;
        }

        // GET: Fidelites
        public async Task<IActionResult> Index()
        {
            var hotelsa3adaContext = _context.Fidelites.Include(f => f.IdClientNavigation);
            return View(await hotelsa3adaContext.ToListAsync());
        }

        // GET: Fidelites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fidelite = await _context.Fidelites
                .Include(f => f.IdClientNavigation)
                .FirstOrDefaultAsync(m => m.IdFidelite == id);
            if (fidelite == null)
            {
                return NotFound();
            }

            return View(fidelite);
        }

        // GET: Fidelites/Create
        public IActionResult Create()
        {
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "IdClient");
            return View();
        }

        // POST: Fidelites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFidelite,Points,Niveau,IdClient")] Fidelite fidelite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fidelite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "IdClient", fidelite.IdClient);
            return View(fidelite);
        }

        // GET: Fidelites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fidelite = await _context.Fidelites.FindAsync(id);
            if (fidelite == null)
            {
                return NotFound();
            }
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "IdClient", fidelite.IdClient);
            return View(fidelite);
        }

        // POST: Fidelites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFidelite,Points,Niveau,IdClient")] Fidelite fidelite)
        {
            if (id != fidelite.IdFidelite)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fidelite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FideliteExists(fidelite.IdFidelite))
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
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "IdClient", fidelite.IdClient);
            return View(fidelite);
        }

        // GET: Fidelites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fidelite = await _context.Fidelites
                .Include(f => f.IdClientNavigation)
                .FirstOrDefaultAsync(m => m.IdFidelite == id);
            if (fidelite == null)
            {
                return NotFound();
            }

            return View(fidelite);
        }

        // POST: Fidelites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fidelite = await _context.Fidelites.FindAsync(id);
            if (fidelite != null)
            {
                _context.Fidelites.Remove(fidelite);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FideliteExists(int id)
        {
            return _context.Fidelites.Any(e => e.IdFidelite == id);
        }
    }
}
