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
    public class EvenementSansDonsController : Controller
    {
        private readonly WeCareBdContext _context;

        public EvenementSansDonsController(WeCareBdContext context)
        {
            _context = context;
        }

        // GET: EvenementSansDons
        public async Task<IActionResult> Index()
        {
            var weCareBdContext = _context.EvenementSansDon.Include(e => e.Association);
            return View(await weCareBdContext.ToListAsync());
        }

        // GET: EvenementSansDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenementSansDon = await _context.EvenementSansDon
                .Include(e => e.Association)
                .SingleOrDefaultAsync(m => m.EvenementID == id);
            if (evenementSansDon == null)
            {
                return NotFound();
            }

            return View(evenementSansDon);
        }

        // GET: EvenementSansDons/Create
        public IActionResult Create()
        {
            ViewData["AssociationID"] = new SelectList(_context.Association, "UtilisateurID", "Discriminator");
            return View();
        }

        // POST: EvenementSansDons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lieu,EvenementID,Titre,Description,AssociationID")] EvenementSansDon evenementSansDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evenementSansDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociationID"] = new SelectList(_context.Association, "UtilisateurID", "Discriminator", evenementSansDon.AssociationID);
            return View(evenementSansDon);
        }

        // GET: EvenementSansDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenementSansDon = await _context.EvenementSansDon.SingleOrDefaultAsync(m => m.EvenementID == id);
            if (evenementSansDon == null)
            {
                return NotFound();
            }
            ViewData["AssociationID"] = new SelectList(_context.Association, "UtilisateurID", "Discriminator", evenementSansDon.AssociationID);
            return View(evenementSansDon);
        }

        // POST: EvenementSansDons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Lieu,EvenementID,Titre,Description,AssociationID")] EvenementSansDon evenementSansDon)
        {
            if (id != evenementSansDon.EvenementID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evenementSansDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvenementSansDonExists(evenementSansDon.EvenementID))
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
            ViewData["AssociationID"] = new SelectList(_context.Association, "UtilisateurID", "Discriminator", evenementSansDon.AssociationID);
            return View(evenementSansDon);
        }

        // GET: EvenementSansDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenementSansDon = await _context.EvenementSansDon
                .Include(e => e.Association)
                .SingleOrDefaultAsync(m => m.EvenementID == id);
            if (evenementSansDon == null)
            {
                return NotFound();
            }

            return View(evenementSansDon);
        }

        // POST: EvenementSansDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evenementSansDon = await _context.EvenementSansDon.SingleOrDefaultAsync(m => m.EvenementID == id);
            _context.EvenementSansDon.Remove(evenementSansDon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvenementSansDonExists(int id)
        {
            return _context.EvenementSansDon.Any(e => e.EvenementID == id);
        }
    }
}
