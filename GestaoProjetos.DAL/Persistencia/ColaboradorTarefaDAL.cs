using GestaoProjetos.DAL.Context;
using GestaoProjetos.DAL.Interfaces;
using GestaoProjetos.DTO;
using System.Collections.Generic;
using System.Linq;

namespace GestaoProjetos.DAL.Persistencia
{
    public class ColaboradorTarefaDAL : IColaboradorTarefaDAL
    {
        private readonly EFContext _context;

        public ColaboradorTarefaDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(ColaboradorTarefa item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long Id)
        {
            throw new System.NotImplementedException();
        }

        public ColaboradorTarefa GetColaboradorTarefa(long Id)
        {
            throw new System.NotImplementedException();
        }

        public IList<ColaboradorTarefa> ListarColaboradoresTarefa()
        {
            List<ColaboradorTarefa> colaboradoresTarefas =
            (from o in _context.ColaboradoresTarefa
             orderby o.ID_ColaboradorTarefa
             select new ColaboradorTarefa()
             {
                 ID_ColaboradorTarefa = o.ID_ColaboradorTarefa,
                 Horas_Estimadas = o.Horas_Estimadas,
                 Colaborador = o.Colaborador != null ? new Colaborador
                 {
                     Id_Colaborador = o.Colaborador.Id_Colaborador,
                     Nome = o.Colaborador.Nome,
                 } : null,
                 Tarefa = o.Tarefa != null ? new Tarefa
                 {
                     Id_Tarefa = o.Tarefa.Id_Tarefa,
                     Descricao = o.Tarefa.Descricao,
                     Observacao = o.Tarefa.Observacao,
                     Situacao = o.Tarefa.Situacao,
                     Data_Abertura = o.Tarefa.Data_Abertura,
                     Data_Entrega = o.Tarefa.Data_Entrega
                 } : null,
                }).ToList();

            return colaboradoresTarefas;
        }

        public void Update(ColaboradorTarefa item)
        {
            throw new System.NotImplementedException();
        }
    }
}
