using GestaoProjetos.DAL.Context;
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
            throw new System.NotImplementedException();
        }

        public void Delete(long Id)
        {
            throw new System.NotImplementedException();
        }

        public Projeto GetProjeto(long Id)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}
