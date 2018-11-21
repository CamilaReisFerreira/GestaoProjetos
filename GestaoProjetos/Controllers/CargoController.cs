using System.Net;
using GestaoProjetos.DAL.Interfaces;
using GestaoProjetos.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProjetos.Controllers
{
    public class CargoController : Controller
    {
        public ICargoDAL CargoRepo { get; set; }

        public CargoController(ICargoDAL _repo)
        {
            CargoRepo = _repo;
        }


        public IActionResult Index()
        {
            return View(CargoRepo.ListarCargos());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cargo cargo)
        {
            CargoRepo.Add(cargo);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Cargo cargo = CargoRepo.GetCargo(id.Value);
            if (cargo == null)
            {
                return NotFound();
            }
            return View(cargo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                CargoRepo.Update(cargo);
                return RedirectToAction("Index");
            }
            return View(cargo);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Cargo cargo = CargoRepo.GetCargo(id.Value);
            if (cargo == null)
            {
                return NotFound();
            }
            return View(cargo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Cargo cargo)
        {
            Cargo car = CargoRepo.GetCargo(cargo.Id_Cargo);
            if (car != null)
            {
                CargoRepo.Delete(cargo.Id_Cargo);
                TempData["Message"] = "Cargo " + car.Descricao + " foi removido";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Cargo cargo = CargoRepo.GetCargo(id.Value);
            if (cargo == null)
            {
                return NotFound();
            }
            return View(cargo);
        }
    }
}