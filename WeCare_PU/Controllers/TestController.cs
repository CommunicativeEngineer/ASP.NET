using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeCare_PU.Entities;
using WeCare_PU.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeCare_PU.Controllers
{
    public class TestController : Controller
    {
        public WeCareBdContext db { get; set; }//le principe de l'injection de dependence without new
        public TestController(WeCareBdContext db)
        {
            this.db = db;
        }


        public ActionResult Affichage()
        {
            return View();
        }


        [Route("Succes")]
        public IActionResult Create(Citoyen c)
        {
            Utilisateur u;
            u = c;
            if (ModelState.IsValid)
            {
                db.Add(u);
                return View("Succes");

            }
            return RedirectToAction("Affichage");
            
        }
    }
}
