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
    public class HorasColaboradorController : Controller
    {
        public IHorasColaboradorDAL HorasColabRepo { get; set; }
        public IColaboradorDAL ColabRepo { get; set; }
        public ITarefaDAL TarefaRepo { get; set; }

        public HorasColaboradorController(IHorasColaboradorDAL _repo, IColaboradorDAL _repoColab, ITarefaDAL _repoTar)
        {
            HorasColabRepo = _repo;
            ColabRepo = _repoColab;
            TarefaRepo = _repoTar;
        }

        public IActionResult Index()
        {
            return View(HorasColabRepo.ListarHorasColaboradores());
        }

        public IActionResult Create()
        {
            ViewBag.Colaboradores = ColabRepo.ListarColaboradores();
            ViewBag.Tarefas = TarefaRepo.ListarTarefas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HorasColaborador horas)
        {
            HorasColabRepo.Add(horas);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            HorasColaborador horasColab = HorasColabRepo.GetHorasColaborador(id.Value);
            if (horasColab == null)
            {
                return NotFound();
            }
            ViewBag.Colaboradores = ColabRepo.ListarColaboradores();
            ViewBag.Tarefas = TarefaRepo.ListarTarefas();
            return View(horasColab);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(HorasColaborador horas)
        {
            if (ModelState.IsValid)
            {
                HorasColabRepo.Update(horas);
                return RedirectToAction("Index");
            }
            return View(horas);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            HorasColaborador horas = HorasColabRepo.GetHorasColaborador(id.Value);
            if (horas == null)
            {
                return NotFound();
            }
            return View(horas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(HorasColaborador horas)
        {
            HorasColaborador horasColab = HorasColabRepo.GetHorasColaborador(horas.Id_HorasColaborador);
            if (horasColab != null)
            {
                HorasColabRepo.Delete(horas.Id_HorasColaborador);
                TempData["Message"] = "Lançamento de hora removido da tarefa";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            HorasColaborador horas = HorasColabRepo.GetHorasColaborador(id.Value);
            if (horas == null)
            {
                return NotFound();
            }
            return View(horas);
        }
    }
}