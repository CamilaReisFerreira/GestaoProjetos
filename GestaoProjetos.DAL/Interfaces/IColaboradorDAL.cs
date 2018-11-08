using GestaoProjetos.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProjetos.DAL.Interfaces
{
    public interface IColaboradorDAL
    {
        IList<Colaborador> ListarColaboradores();

        void Add(Colaborador item);

        void Update(Colaborador item);

        void Delete(long Id);

        Colaborador GetColaborador(long Id);
    }
}
