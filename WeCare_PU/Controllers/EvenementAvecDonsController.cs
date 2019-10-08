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
    public class EvenementAvecDonsController : Controller
    {
        private readonly WeCareBdContext _context;

        public EvenementAvecDonsController(WeCareBdContext context)
        {
            _context = context;
        }

        // GET: EvenementAvecDons
        public async Task<IActionResult> Index()
        {
            var weCareBdContext = _context.EvenementAvecDon.Include(e => e.Association);
            return View(await weCareBdContext.ToListAsync());
        }

        // GET: EvenementAvecDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenementAvecDon = await _context.EvenementAvecDon
                .Include(e => e.Association)
                .SingleOrDefaultAsync(m => m.EvenementID == id);
            if (evenementAvecDon == null)
            {
                return NotFound();
            }

            return View(evenementAvecDon);
        }

        // GET: EvenementAvecDons/Create
        public IActionResult Create()
        {
            ViewData["AssociationID"] = new SelectList(_context.Association, "UtilisateurID", "Discriminator");
            return View();
        }

        // POST: EvenementAvecDons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Montant,EvenementID,Titre,Description,AssociationID")] EvenementAvecDon evenementAvecDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evenementAvecDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociationID"] = new SelectList(_context.Association, "UtilisateurID", "Discriminator", evenementAvecDon.AssociationID);
            return View(evenementAvecDon);
        }

        // GET: EvenementAvecDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenementAvecDon = await _context.EvenementAvecDon.SingleOrDefaultAsync(m => m.EvenementID == id);
            if (evenementAvecDon == null)
            {
                return NotFound();
            }
            ViewData["AssociationID"] = new SelectList(_context.Association, "UtilisateurID", "Discriminator", evenementAvecDon.AssociationID);
            return View(evenementAvecDon);
        }

        // POST: EvenementAvecDons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Montant,EvenementID,Titre,Description,AssociationID")] EvenementAvecDon evenementAvecDon)
        {
            if (id != evenementAvecDon.EvenementID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evenementAvecDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvenementAvecDonExists(evenementAvecDon.EvenementID))
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
            ViewData["AssociationID"] = new SelectList(_context.Association, "UtilisateurID", "Discriminator", evenementAvecDon.AssociationID);
            return View(evenementAvecDon);
        }

        // GET: EvenementAvecDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenementAvecDon = await _context.EvenementAvecDon
                .Include(e => e.Association)
                .SingleOrDefaultAsync(m => m.EvenementID == id);
            if (evenementAvecDon == null)
            {
                return NotFound();
            }

            return View(evenementAvecDon);
        }

        // POST: EvenementAvecDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evenementAvecDon = await _context.EvenementAvecDon.SingleOrDefaultAsync(m => m.EvenementID == id);
            _context.EvenementAvecDon.Remove(evenementAvecDon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvenementAvecDonExists(int id)
        {
            return _context.EvenementAvecDon.Any(e => e.EvenementID == id);
        }
    }
}
