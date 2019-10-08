using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeCare_PU.Entities;
using WeCare_PU.Metiers;
using WeCare_PU.Models;

namespace WeCare_PU.Controllers
{//"AdministrateurID,Login,Password"
    public class AdministrateursController : Controller
    {
        public ImplTraitementUtilisateur _context = new ImplTraitementUtilisateur();


        // GET: Citoyens
        public ActionResult Index()
        {
            return View(_context.GetAllAdministrateurs());
        }

        // GET: Citoyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrateur = _context.GetAdministrateur(Convert.ToInt32(id));
            if (administrateur == null)
            {
                return NotFound();
            }

            return View(administrateur);
        }

        // GET: Citoyens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Citoyens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("AdministrateurID,Login,Password")] Administrateur administrateur)
        {
            if (ModelState.IsValid)
            {
                _context.AddAdministrateur(administrateur);
                return RedirectToAction(nameof(Index));
            }
            return View(administrateur);
        }

        // GET: Citoyens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrateur = _context.GetAdministrateur(Convert.ToInt32(id));
            if (administrateur == null)
            {
                return NotFound();
            }
            return View(administrateur);
        }

        // POST: Citoyens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdministrateurID,Login,Password")] Administrateur administrateur)
        {
            if (id != administrateur.AdministrateurID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.UpdateAdministrateur(administrateur);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministrateurExists(administrateur.AdministrateurID))
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
            return View(administrateur);
        }

        // GET: Citoyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrateur = _context.GetAdministrateur(Convert.ToInt32(id));
            if (administrateur == null)
            {
                return NotFound();
            }

            return View(administrateur);
        }

        // POST: Citoyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrateur = _context.GetAdministrateur(Convert.ToInt32(id));
            _context.RemoveAdministrateur(administrateur);
            return RedirectToAction(nameof(Index));
        }

        private bool AdministrateurExists(int id)
        {
            return _context.ExistsAdministrateur(id);

        }
    }
}
