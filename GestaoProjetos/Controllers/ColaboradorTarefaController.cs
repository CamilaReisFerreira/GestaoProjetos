using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProjetos.DAL.Interfaces;
using GestaoProjetos.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProjetos.Controllers
{
    public class ColaboradorTarefaController : Controller
    {
        public IColaboradorTarefaDAL ColabTarRepo { get; set; }
        public IColaboradorDAL ColabRepo { get; set; }
        public ITarefaDAL TarefaRepo { get; set; }

        public ColaboradorTarefaController(IColaboradorTarefaDAL _repo, IColaboradorDAL _repoColab, ITarefaDAL _repoTar)
        {
            ColabTarRepo = _repo;
            ColabRepo = _repoColab;
            TarefaRepo = _repoTar;
        }

        public IActionResult Index()
        {
            return View(ColabTarRepo.ListarColaboradoresTarefa());
        }

        public IActionResult Create()
        {
            ViewBag.Colaboradores = ColabRepo.ListarColaboradores();
            ViewBag.Tarefas = TarefaRepo.ListarTarefas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ColaboradorTarefa colaborador)
        {
            ColabTarRepo.Add(colaborador);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ColaboradorTarefa colaborador = ColabTarRepo.GetColaboradorTarefa(id.Value);
            if (colaborador == null)
            {
                return NotFound();
            }
            ViewBag.Colaboradores = ColabRepo.ListarColaboradores();
            ViewBag.Tarefas = TarefaRepo.ListarTarefas();
            return View(colaborador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ColaboradorTarefa colaborador)
        {
            if (ModelState.IsValid)
            {
                ColabTarRepo.Update(colaborador);
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
            ColaboradorTarefa colaborador = ColabTarRepo.GetColaboradorTarefa(id.Value);
            if (colaborador == null)
            {
                return NotFound();
            }
            return View(colaborador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ColaboradorTarefa colaborador)
        {
            ColaboradorTarefa colab = ColabTarRepo.GetColaboradorTarefa(colaborador.ID_ColaboradorTarefa);
            if (colab != null)
            {
                ColabTarRepo.Delete(colaborador.ID_ColaboradorTarefa);
                TempData["Message"] = "Colaborador " + colab.Colaborador.Nome + " foi removido da tarefa";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ColaboradorTarefa colaborador = ColabTarRepo.GetColaboradorTarefa(id.Value);
            if (colaborador == null)
            {
                return NotFound();
            }
            return View(colaborador);
        }
    }
}