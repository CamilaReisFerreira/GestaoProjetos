using GestaoProjetos.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProjetos.DAL.Interfaces
{
    public interface ITarefaDAL
    {
        IList<Tarefa> ListarTarefas();

        void Add(Tarefa item);

        void Update(Tarefa item);

        void Delete(long Id);

        Tarefa GetTarefa(long Id);
    }
}
