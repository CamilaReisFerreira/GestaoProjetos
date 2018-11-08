using GestaoProjetos.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProjetos.DAL.Interfaces
{
    public interface IHorasColaboradorDAL
    {
        IList<HorasColaborador> ListarHorasColaboradores();

        void Add(HorasColaborador item);

        void Update(HorasColaborador item);

        void Delete(long Id);

        HorasColaborador GetHorasColaborador(long Id);
    }
}
