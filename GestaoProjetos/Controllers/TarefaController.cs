using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProjetos.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProjetos.Controllers
{
    public class TarefaController : Controller
    {
        public ITarefaDAL TarefaRepo { get; set; }

        public TarefaController(ITarefaDAL _repo)
        {
            TarefaRepo = _repo;
        }

        public IActionResult Index()
        {
            return View(TarefaRepo.ListarTarefas());
        }
    }
}