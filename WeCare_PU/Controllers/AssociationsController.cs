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
{
    public class AssociationsController : Controller
    {

        public ImplTraitementUtilisateur _context = new ImplTraitementUtilisateur();

        // GET: Citoyens
        public ActionResult Index()
        {
            return View(_context.GetAllAssociations());
        }

        // GET: Citoyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var association = _context.GetAssociation(Convert.ToInt32(id));
            if (association == null)
            {
                return NotFound();
            }

            return View(association);
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
        public ActionResult Create([Bind("Nom,Fondateur,Description,UtilisateurID,Login,Password,Mail,Adresse,Telephone")] Association association)
        {
            if (ModelState.IsValid)
            {
                _context.AddAssociation(association);
                return RedirectToAction(nameof(Index));
            }
            return View(association);
        }

        // GET: Citoyens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var association = _context.GetAssociation(Convert.ToInt32(id));
            if (association == null)
            {
                return NotFound();
            }
            return View(association);
        }

        // POST: Citoyens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nom,Fondateur,Description,UtilisateurID,Login,Password,Mail,Adresse,Telephone")] Association association)
        {
            if (id != association.UtilisateurID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.UpdateAssociation(association);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociationExists(association.UtilisateurID))
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
            return View(association);
        }

        // GET: Citoyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var association = _context.GetAssociation(Convert.ToInt32(id));
            if (association == null)
            {
                return NotFound();
            }

            return View(association);
        }

        // POST: Citoyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var association = _context.GetAssociation(Convert.ToInt32(id));
            _context.RemoveAssociation(association);
            return RedirectToAction(nameof(Index));
        }

        private bool AssociationExists(int id)
        {
            return _context.ExistsAssociation(id);

        }


    }
}
