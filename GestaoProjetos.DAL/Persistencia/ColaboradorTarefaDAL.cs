using GestaoProjetos.DAL.Context;
using GestaoProjetos.DAL.Entidades;
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
            var colaboradorTarefa = new ColaboradorTarefaDAO
            {
                Horas_Estimadas = item.Horas_Estimadas
            };
            if (item.Tarefa != null)
                colaboradorTarefa.TarefaId_Tarefa = item.Tarefa.Id_Tarefa;
            if (item.Colaborador != null)
                colaboradorTarefa.ColaboradorId_Colaborador = item.Colaborador.Id_Colaborador;

            _context.ColaboradoresTarefa.Add(colaboradorTarefa);
            _context.SaveChanges();
        }

        public void Delete(long Id)
        {
            ColaboradorTarefaDAO colaboradorTarefa = _context.ColaboradoresTarefa.FirstOrDefault(x => x.ID_ColaboradorTarefa == Id);

            _context.ColaboradoresTarefa.Remove(colaboradorTarefa);
            _context.SaveChanges();
        }

        public ColaboradorTarefa GetColaboradorTarefa(long Id)
        {
            ColaboradorTarefaDAO colaboradorTarefa = _context.ColaboradoresTarefa.Find(Id);
            var tarefa = colaboradorTarefa.TarefaId_Tarefa != null ? _context.Tarefas.Find(colaboradorTarefa.TarefaId_Tarefa) : null;
            var colaborador = colaboradorTarefa.ColaboradorId_Colaborador != null ? _context.Colaboradores.Find(colaboradorTarefa.ColaboradorId_Colaborador) : null;
            return colaboradorTarefa != null ?
                new ColaboradorTarefa
                {
                    ID_ColaboradorTarefa = colaboradorTarefa.ID_ColaboradorTarefa,
                    Horas_Estimadas = colaboradorTarefa.Horas_Estimadas,
                    Tarefa = tarefa != null ? new Tarefa
                    {
                        Id_Tarefa = tarefa.Id_Tarefa,
                        Descricao = tarefa.Descricao,
                        Observacao = tarefa.Observacao,
                        Situacao = tarefa.Situacao,
                        Data_Abertura = tarefa.Data_Abertura,
                        Data_Entrega = tarefa.Data_Entrega,
                    } : null,
                    Colaborador = colaborador != null ? new Colaborador
                    {
                        Id_Colaborador = colaborador.Id_Colaborador,
                        Nome = colaborador.Nome
                    } : null
                } : null;
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
            ColaboradorTarefaDAO colaboradorTarefa = _context.ColaboradoresTarefa.FirstOrDefault(x => x.ID_ColaboradorTarefa == item.ID_ColaboradorTarefa);
            colaboradorTarefa.Horas_Estimadas = item.Horas_Estimadas;
            if (item.Tarefa != null)
                colaboradorTarefa.TarefaId_Tarefa = item.Tarefa.Id_Tarefa;
            if (item.Colaborador != null)
                colaboradorTarefa.ColaboradorId_Colaborador = item.Colaborador.Id_Colaborador;

            _context.SaveChanges();
        }
    }
}
