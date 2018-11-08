using GestaoProjetos.DAL.Persistencia;
using GestaoProjetos.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProjetos.BLL
{
    public class CargoBO
    {
        private CargoDAL _serviceCargo;

        //public CargoBO()
        //{
        //    _serviceCargo = new CargoDAL();
        //}

        public IList<Cargo> ListarCargos()
        {
            return _serviceCargo.ListarCargos();
        }
    }
}
