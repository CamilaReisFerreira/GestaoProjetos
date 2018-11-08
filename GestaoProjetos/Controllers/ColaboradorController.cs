using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProjetos.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProjetos.Controllers
{
    public class ColaboradorController : Controller
    {
        public IColaboradorDAL ColabRepo { get; set; }

        public ColaboradorController(IColaboradorDAL _repo)
        {
            ColabRepo = _repo;
        }

        public IActionResult Index()
        {
            return View(ColabRepo.ListarColaboradores());
        }
    }
}