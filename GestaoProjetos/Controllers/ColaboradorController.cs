using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProjetos.DAL.Interfaces;
using GestaoProjetos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestaoProjetos.Controllers
{
    public class ColaboradorController : Controller
    {
        public IColaboradorDAL ColabRepo { get; set; }
        public ICargoDAL CargoRepo { get; set; }

        public ColaboradorController(IColaboradorDAL _repo, ICargoDAL _repoCargo)
        {
            ColabRepo = _repo;
            CargoRepo = _repoCargo;
        }

        public IActionResult Index()
        {
            return View(ColabRepo.ListarColaboradores());
        }

        public IActionResult Create()
        {
            ViewBag.Cargos = CargoRepo.ListarCargos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Colaborador colaborador)
        {
            ColabRepo.Add(colaborador);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Colaborador colaborador = ColabRepo.GetColaborador(id.Value);
            if (colaborador == null)
            {
                return NotFound();
            }
            ViewBag.Cargos = CargoRepo.ListarCargos();
            return View(colaborador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                ColabRepo.Update(colaborador);
                return RedirectToAction("Index");
            }
            return View(colaborador);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Colaborador colaborador = ColabRepo.GetColaborador(id.Value);
            if (colaborador == null)
            {
                return NotFound();
            }
            return View(colaborador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Colaborador colaborador)
        {
            Colaborador colab = ColabRepo.GetColaborador(colaborador.Id_Colaborador);
            if (colab != null)
            {
                ColabRepo.Delete(colaborador.Id_Colaborador);
                TempData["Message"] = "Colaborador " + colab.Nome + " foi removido";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Colaborador colaborador = ColabRepo.GetColaborador(id.Value);
            if (colaborador == null)
            {
                return NotFound();
            }
            return View(colaborador);
        }
    }
}