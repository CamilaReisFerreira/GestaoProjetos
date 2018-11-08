using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProjetos.DAL.Interfaces;
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
    }
}