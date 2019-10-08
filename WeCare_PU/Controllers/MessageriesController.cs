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
    public class MessageriesController : Controller
    {
        private readonly WeCareBdContext _context;

        public MessageriesController(WeCareBdContext context)
        {
            _context = context;
        }

        // GET: Messageries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Messageries.ToListAsync());
        }

        // GET: Messageries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messagerie = await _context.Messageries
                .SingleOrDefaultAsync(m => m.MessagerieID == id);
            if (messagerie == null)
            {
                return NotFound();
            }

            return View(messagerie);
        }

        // GET: Messageries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Messageries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MessagerieID,Message")] Messagerie messagerie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(messagerie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(messagerie);
        }

        // GET: Messageries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messagerie = await _context.Messageries.SingleOrDefaultAsync(m => m.MessagerieID == id);
            if (messagerie == null)
            {
                return NotFound();
            }
            return View(messagerie);
        }

        // POST: Messageries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MessagerieID,Message")] Messagerie messagerie)
        {
            if (id != messagerie.MessagerieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(messagerie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessagerieExists(messagerie.MessagerieID))
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
            return View(messagerie);
        }

        // GET: Messageries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messagerie = await _context.Messageries
                .SingleOrDefaultAsync(m => m.MessagerieID == id);
            if (messagerie == null)
            {
                return NotFound();
            }

            return View(messagerie);
        }

        // POST: Messageries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var messagerie = await _context.Messageries.SingleOrDefaultAsync(m => m.MessagerieID == id);
            _context.Messageries.Remove(messagerie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessagerieExists(int id)
        {
            return _context.Messageries.Any(e => e.MessagerieID == id);
        }
    }
}
