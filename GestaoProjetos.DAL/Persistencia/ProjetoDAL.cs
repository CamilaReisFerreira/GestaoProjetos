using GestaoProjetos.DAL.Context;
using GestaoProjetos.DAL.Entidades;
using GestaoProjetos.DAL.Interfaces;
using GestaoProjetos.DTO;
using System.Collections.Generic;
using System.Linq;

namespace GestaoProjetos.DAL.Persistencia
{
    public class ProjetoDAL : IProjetoDAL
    {
        private readonly EFContext _context;

        public ProjetoDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(Projeto item)
        {
            var projeto = new ProjetoDAO
            {
                Razao_Social = item.Razao_Social,
                CNPJ = item.CNPJ,
                Horas_Projeto = item.Horas_Projeto,
                Data_Inicial_Contrato = item.Data_Inicial_Contrato,
                Observacoes = item.Observacoes
            };

            _context.Projetos.Add(projeto);
            _context.SaveChanges();
        }

        public void Delete(long Id)
        {
            ProjetoDAO projeto = _context.Projetos.FirstOrDefault(x => x.Id_Projeto == Id);

            _context.Projetos.Remove(projeto);
            _context.SaveChanges();
        }

        public Projeto GetProjeto(long Id)
        {
            ProjetoDAO colaborador = _context.Projetos.Find(Id);
            return colaborador != null ?
                new Projeto
                {
                    Id_Projeto = colaborador.Id_Projeto,
                    Razao_Social = colaborador.Razao_Social,
                    CNPJ = colaborador.CNPJ,
                    Horas_Projeto = colaborador.Horas_Projeto,
                    Data_Inicial_Contrato = colaborador.Data_Inicial_Contrato,
                    Observacoes = colaborador.Observacoes
                } : null;
        }

        public IList<Projeto> ListarProjetos()
        {
            List<Projeto> projetos =
            (from o in _context.Projetos
                orderby o.Razao_Social
                select new Projeto()
                {
                    Id_Projeto = o.Id_Projeto,
                    Razao_Social = o.Razao_Social,
                    CNPJ = o.CNPJ,
                    Horas_Projeto = o.Horas_Projeto,
                    Data_Inicial_Contrato = o.Data_Inicial_Contrato,
                    Observacoes = o.Observacoes
                }).ToList();

            return projetos;
        }

        public void Update(Projeto item)
        {
            ProjetoDAO projeto = _context.Projetos.FirstOrDefault(x => x.Id_Projeto == item.Id_Projeto);
            projeto.Razao_Social = item.Razao_Social;
            projeto.CNPJ = item.CNPJ;
            projeto.Horas_Projeto = item.Horas_Projeto;
            projeto.Data_Inicial_Contrato = item.Data_Inicial_Contrato;
            projeto.Observacoes = item.Observacoes;

            _context.SaveChanges();
        }
    }
}
