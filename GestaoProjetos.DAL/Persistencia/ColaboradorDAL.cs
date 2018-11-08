using GestaoProjetos.DAL.Context;
using GestaoProjetos.DAL.Interfaces;
using GestaoProjetos.DTO;
using System.Collections.Generic;
using System.Linq;

namespace GestaoProjetos.DAL.Persistencia
{
    public class ColaboradorDAL : IColaboradorDAL
    {
        private readonly EFContext _context;

        public ColaboradorDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(Colaborador item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long Id)
        {
            throw new System.NotImplementedException();
        }

        public Colaborador GetColaborador(long Id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Colaborador> ListarColaboradores()
        {
            List<Colaborador> colaboradores =
            (from o in _context.Colaboradores
             orderby o.Nome
             select new Colaborador()
             {
                 Id_Colaborador = o.Id_Colaborador,
                 Nome = o.Nome,
                 Cargo = o.Cargo != null ? new Cargo
                 {
                     Id_Cargo = o.Cargo.Id_Cargo,
                     Descricao = o.Cargo.Descricao
                 } : null,
                }).ToList();

            return colaboradores;
        }

        public void Update(Colaborador item)
        {
            throw new System.NotImplementedException();
        }
    }
}
