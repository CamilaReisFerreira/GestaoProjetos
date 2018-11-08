using GestaoProjetos.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjetos.DAL.Interfaces
{
    public interface ICargoDAL
    {
        IList<Cargo> ListarCargos();

        void Add(Cargo item);

        void Update(Cargo item);

        void Delete(long Id);

        Cargo GetCargo(long Id);
    }
}
