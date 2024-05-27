using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using T2_Arriola_Alonso.Datos;
using T2_Arriola_Alonso.Models;

namespace T2_Arriola_Alonso.Controllers
{
    public class DistribuidorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DistribuidorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Distribuidor> lista = _db.Distribuidor;
            return View(lista);
        }

        public IActionResult Crear() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Distribuidor distribuidor)
        {
            if (ModelState.IsValid)
            {
                _db.Distribuidor.Add(distribuidor);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(distribuidor);
           
        }

        public IActionResult Editar(int? Id)
        {
            if (Id==null || Id==0)
            {
                return NotFound();
            }
            var obj = _db.Distribuidor.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Distribuidor distribuidor)
        {
            if (ModelState.IsValid)
            {
                _db.Distribuidor.Update(distribuidor);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(distribuidor);
        }

        public IActionResult Eliminar(int? Id)
        {
            if (Id==null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Distribuidor.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);   
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Distribuidor distribuidor)
        {
            if (distribuidor== null)
            {
                return NotFound();
            }
            _db.Distribuidor.Remove(distribuidor);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
