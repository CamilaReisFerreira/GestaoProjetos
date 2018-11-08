using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProjetos.DAL.Interfaces;
using GestaoProjetos.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProjetos.Controllers
{
    public class ProjetoController : Controller
    {
        public IProjetoDAL ProjetoRepo { get; set; }

        public ProjetoController(IProjetoDAL _repo)
        {
            ProjetoRepo = _repo;
        }

        public IActionResult Index()
        {
            return View(ProjetoRepo.ListarProjetos());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Projeto projeto)
        {
            ProjetoRepo.Add(projeto);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                BadRequest();
            }
            Projeto projeto = ProjetoRepo.GetProjeto(id.Value);
            if (projeto == null)
            {
                NotFound();
            }
            return View(projeto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                ProjetoRepo.Update(projeto);
                return RedirectToAction("Index");
            }
            return View(projeto);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                BadRequest();
            }
            Projeto projeto = ProjetoRepo.GetProjeto(id.Value);
            if (projeto == null)
            {
                NotFound();
            }
            return View(projeto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Projeto projeto)
        {
            Projeto proj = ProjetoRepo.GetProjeto(projeto.Id_Projeto);
            if (proj != null)
            {
                ProjetoRepo.Delete(projeto.Id_Projeto);
                TempData["Message"] = "Projeto " + proj.Razao_Social + " foi removido";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Projeto projeto = ProjetoRepo.GetProjeto(id.Value);
            if (projeto == null)
            {
                return NotFound();
            }
            return View(projeto);
        }
    }
}