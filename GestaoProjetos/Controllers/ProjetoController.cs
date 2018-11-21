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
            var isCnpj = IsCnpj(projeto.CNPJ);
            if (!isCnpj)
            {
                ModelState.AddModelError("CustomError", "CNPJ informado é inválido!");
                return View(projeto);
            }

            ProjetoRepo.Add(projeto);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Projeto projeto)
        {
            var isCnpj = IsCnpj(projeto.CNPJ);
            if (!isCnpj)
                ModelState.AddModelError("CustomError", "CNPJ informado é inválido!");

            if (ModelState.IsValid && isCnpj)
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
                return BadRequest();
            }
            Projeto projeto = ProjetoRepo.GetProjeto(id.Value);
            if (projeto == null)
            {
                return NotFound();
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

        private bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}