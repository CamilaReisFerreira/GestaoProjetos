using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProjetos.DAL.Interfaces;
using GestaoProjetos.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProjetos.Controllers
{
    public class TarefaController : Controller
    {
        public ITarefaDAL TarefaRepo { get; set; }

        public IProjetoDAL ProjetoRepo { get; set; }

        public TarefaController(ITarefaDAL _repo, IProjetoDAL _repoProjeto)
        {
            TarefaRepo = _repo;
            ProjetoRepo = _repoProjeto;
        }

        public IActionResult Index()
        {
            return View(TarefaRepo.ListarTarefas());
        }

        public IActionResult Create()
        {
            ViewBag.Projetos = ProjetoRepo.ListarProjetos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tarefa tarefa)
        {
            TarefaRepo.Add(tarefa);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                BadRequest();
            }
            Tarefa tarefa = TarefaRepo.GetTarefa(id.Value);
            if (tarefa == null)
            {
                NotFound();
            }
            ViewBag.Projetos = ProjetoRepo.ListarProjetos();
            return View(tarefa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                TarefaRepo.Update(tarefa);
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                BadRequest();
            }
            Tarefa tarefa = TarefaRepo.GetTarefa(id.Value);
            if (tarefa == null)
            {
                NotFound();
            }
            return View(tarefa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Tarefa tarefa)
        {
            Tarefa tar = TarefaRepo.GetTarefa(tarefa.Id_Tarefa);
            if (tar != null)
            {
                TarefaRepo.Delete(tarefa.Id_Tarefa);
                TempData["Message"] = "Tarefa " + tar.Descricao + " foi removida";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Tarefa tarefa = TarefaRepo.GetTarefa(id.Value);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }
    }
}