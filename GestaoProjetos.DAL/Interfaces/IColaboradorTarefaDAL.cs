using GestaoProjetos.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProjetos.DAL.Interfaces
{
    public interface IColaboradorTarefaDAL
    {
        IList<ColaboradorTarefa> ListarColaboradoresTarefa();

        void Add(ColaboradorTarefa item);

        void Update(ColaboradorTarefa item);

        void Delete(long Id);

        ColaboradorTarefa GetColaboradorTarefa(long Id);
    }
}
