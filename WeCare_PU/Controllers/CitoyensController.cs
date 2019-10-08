using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeCare_PU.DAL;
using WeCare_PU.Entities;
using WeCare_PU.Metiers;
using WeCare_PU.Models;

namespace WeCare_PU.Controllers
{
    public class CitoyensController : Controller
    {
        public ImplTraitementUtilisateur _context = new ImplTraitementUtilisateur();

        // GET: Citoyens
        public ActionResult Index()
        {
            return View( _context.GetAllCitoyens());
        }


        public ActionResult Abc()
        {
            return View();
        }

        // GET: Citoyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citoyen = _context.GetCitoyen(Convert.ToInt32(id));
            if (citoyen == null)
            {
                return NotFound();
            }

            return View(citoyen);
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
        public ActionResult Create([Bind("Nom,Prenom,UtilisateurID,Login,Password,Mail,Adresse,Telephone")] Citoyen citoyen)
        {
            if (ModelState.IsValid)
            {
                _context.AddCitoyen(citoyen);
                return RedirectToAction(nameof(Index));
            }
            return View(citoyen);
        }

        // GET: Citoyens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citoyen = _context.GetCitoyen(Convert.ToInt32(id));
            if (citoyen == null)
            {
                return NotFound();
            }
            return View(citoyen);
        }

        // POST: Citoyens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nom,Prenom,UtilisateurID,Login,Password,Mail,Adresse,Telephone")] Citoyen citoyen)
        {
            if (id != citoyen.UtilisateurID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.UpdateCitoyen(citoyen);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitoyenExists(citoyen.UtilisateurID))
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
            return View(citoyen);
        }

        // GET: Citoyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citoyen = _context.GetCitoyen(Convert.ToInt32(id));
            if (citoyen == null)
            {
                return NotFound();
            }

            return View(citoyen);
        }

        // POST: Citoyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citoyen = _context.GetCitoyen(Convert.ToInt32(id));
            _context.RemoveCitoyen(citoyen);
            return RedirectToAction(nameof(Index));
        }

        private bool CitoyenExists(int id)
        {
           return  _context.ExistsCitoyen(id);
         
        }
    }
}
