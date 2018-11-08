using GestaoProjetos.DAL.Context;
using GestaoProjetos.DAL.Entidades;
using GestaoProjetos.DAL.Interfaces;
using GestaoProjetos.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProjetos.DAL.Persistencia
{
    public class CargoDAL : ICargoDAL
    {
        private readonly EFContext _context;

        public CargoDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(Cargo item)
        {
            var cargo = new CargoDAO
            {
                Descricao = item.Descricao
            };

            _context.Cargos.Add(cargo);
            _context.SaveChanges();
        }

        public void Delete(long Id)
        {
            CargoDAO cargo = _context.Cargos.FirstOrDefault(x => x.Id_Cargo == Id);

            _context.Cargos.Remove(cargo);
            _context.SaveChanges();
        }

        public Cargo GetCargo(long Id)
        {
            CargoDAO cargo = _context.Cargos.Find(Id);
            return cargo != null ?
                new Cargo { Id_Cargo = cargo.Id_Cargo, Descricao = cargo.Descricao } : null;
        }

        public IList<Cargo> ListarCargos()
        {
            List<Cargo> cargos =
            (from o in _context.Cargos
                orderby o.Descricao
                select new Cargo()
                {
                    Id_Cargo = o.Id_Cargo,
                    Descricao = o.Descricao
                }).ToList();
            return cargos;
        }

        public void Update(Cargo item)
        {
            CargoDAO cargo = _context.Cargos.FirstOrDefault(x => x.Id_Cargo == item.Id_Cargo);
            cargo.Descricao = item.Descricao;
            _context.SaveChanges();
        }
    }
}
