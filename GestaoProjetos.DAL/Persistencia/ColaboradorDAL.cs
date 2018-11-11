using GestaoProjetos.DAL.Context;
using GestaoProjetos.DAL.Entidades;
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
            var colaborador = new ColaboradorDAO
            {
                Nome = item.Nome
            };
            if (item.Cargo != null)
                colaborador.CargoId_Cargo = item.Cargo.Id_Cargo;

            _context.Colaboradores.Add(colaborador);
            _context.SaveChanges();
        }

        public void Delete(long Id)
        {
            ColaboradorDAO colaborador = _context.Colaboradores.FirstOrDefault(x => x.Id_Colaborador == Id);

            _context.Colaboradores.Remove(colaborador);
            _context.SaveChanges();
        }

        public Colaborador GetColaborador(long Id)
        {
            ColaboradorDAO colaborador = _context.Colaboradores.Find(Id);
            var cargo = colaborador.CargoId_Cargo != null ? _context.Cargos.Find(colaborador.CargoId_Cargo) : null;
            return colaborador != null ?
                new Colaborador {
                    Id_Colaborador = colaborador.Id_Colaborador,
                    Nome = colaborador.Nome,
                    Cargo = cargo != null ? new Cargo
                    {
                        Id_Cargo = cargo.Id_Cargo,
                        Descricao = cargo.Descricao
                    } : null,
                } : null;
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
            ColaboradorDAO colaborador = _context.Colaboradores.FirstOrDefault(x => x.Id_Colaborador == item.Id_Colaborador);
            colaborador.Nome = item.Nome;
            if (item.Cargo != null)
                colaborador.CargoId_Cargo = item.Cargo.Id_Cargo;

            _context.SaveChanges();
        }
    }
}
