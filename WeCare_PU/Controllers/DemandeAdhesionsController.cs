using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeCare_PU.Entities;
using WeCare_PU.Models;

namespace WeCare_PU.Controllers
{
    public class DemandeAdhesionsController : Controller
    {
        private readonly WeCareBdContext _context;

        public DemandeAdhesionsController(WeCareBdContext context)
        {
            _context = context;
        }

        // GET: DemandeAdhesions
        public async Task<IActionResult> Index()
        {
            var weCareBdContext = _context.DemandeAdhesions.Include(d => d.Association);
            return View(await weCareBdContext.ToListAsync());
        }

        // GET: DemandeAdhesions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeAdhesion = await _context.DemandeAdhesions
                .Include(d => d.Association)
                .SingleOrDefaultAsync(m => m.DemandeAdhesionID == id);
            if (demandeAdhesion == null)
            {
                return NotFound();
            }

            return View(demandeAdhesion);
        }

        // GET: DemandeAdhesions/Create
        public IActionResult Create()
        {
            ViewData["AssociationID"] = new SelectList(_context.Association, "UtilisateurID", "Discriminator");
            return View();
        }

        // POST: DemandeAdhesions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DemandeAdhesionID,Demande,Date,AssociationID")] DemandeAdhesion demandeAdhesion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demandeAdhesion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociationID"] = new SelectList(_context.Association, "UtilisateurID", "Discriminator", demandeAdhesion.AssociationID);
            return View(demandeAdhesion);
        }

        // GET: DemandeAdhesions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeAdhesion = await _context.DemandeAdhesions.SingleOrDefaultAsync(m => m.DemandeAdhesionID == id);
            if (demandeAdhesion == null)
            {
                return NotFound();
            }
            ViewData["AssociationID"] = new SelectList(_context.Association, "UtilisateurID", "Discriminator", demandeAdhesion.AssociationID);
            return View(demandeAdhesion);
        }

        // POST: DemandeAdhesions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DemandeAdhesionID,Demande,Date,AssociationID")] DemandeAdhesion demandeAdhesion)
        {
            if (id != demandeAdhesion.DemandeAdhesionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demandeAdhesion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemandeAdhesionExists(demandeAdhesion.DemandeAdhesionID))
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
            ViewData["AssociationID"] = new SelectList(_context.Association, "UtilisateurID", "Discriminator", demandeAdhesion.AssociationID);
            return View(demandeAdhesion);
        }

        // GET: DemandeAdhesions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeAdhesion = await _context.DemandeAdhesions
                .Include(d => d.Association)
                .SingleOrDefaultAsync(m => m.DemandeAdhesionID == id);
            if (demandeAdhesion == null)
            {
                return NotFound();
            }

            return View(demandeAdhesion);
        }

        // POST: DemandeAdhesions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var demandeAdhesion = await _context.DemandeAdhesions.SingleOrDefaultAsync(m => m.DemandeAdhesionID == id);
            _context.DemandeAdhesions.Remove(demandeAdhesion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemandeAdhesionExists(int id)
        {
            return _context.DemandeAdhesions.Any(e => e.DemandeAdhesionID == id);
        }
    }
}
