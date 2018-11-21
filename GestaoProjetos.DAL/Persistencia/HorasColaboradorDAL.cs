using GestaoProjetos.DAL.Context;
using GestaoProjetos.DAL.Entidades;
using GestaoProjetos.DAL.Interfaces;
using GestaoProjetos.DTO;
using System.Collections.Generic;
using System.Linq;

namespace GestaoProjetos.DAL.Persistencia
{
    public class HorasColaboradorDAL : IHorasColaboradorDAL
    {
        private readonly EFContext _context;

        public HorasColaboradorDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(HorasColaborador item)
        {
            var horasColaborador = new HorasColaboradorDAO
            {
                Horas = item.Horas,
                Data = item.Data,
                Descricao = item.Descricao
            };
            if (item.Tarefa != null)
                horasColaborador.TarefaId_Tarefa = item.Tarefa.Id_Tarefa;
            if (item.Colaborador != null)
                horasColaborador.ColaboradorId_Colaborador = item.Colaborador.Id_Colaborador;

            _context.HorasColaboradores.Add(horasColaborador);
            _context.SaveChanges();
        }

        public void Delete(long Id)
        {
            HorasColaboradorDAO horasColaborador = _context.HorasColaboradores.FirstOrDefault(x => x.Id_HorasColaborador == Id);

            _context.HorasColaboradores.Remove(horasColaborador);
            _context.SaveChanges();
        }

        public HorasColaborador GetHorasColaborador(long Id)
        {
            HorasColaboradorDAO horasColaborador = _context.HorasColaboradores.Find(Id);
            var tarefa = horasColaborador.TarefaId_Tarefa != null ? _context.Tarefas.Find(horasColaborador.TarefaId_Tarefa) : null;
            var colaborador = horasColaborador.ColaboradorId_Colaborador != null ? _context.Colaboradores.Find(horasColaborador.ColaboradorId_Colaborador) : null;
            return horasColaborador != null ?
                new HorasColaborador
                {
                    Id_HorasColaborador = horasColaborador.Id_HorasColaborador,
                    Horas = horasColaborador.Horas,
                    Data = horasColaborador.Data,
                    Descricao = horasColaborador.Descricao,
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

        public IList<HorasColaborador> ListarHorasColaboradores()
        {
            List<HorasColaborador> horasColaboradores =
            (from o in _context.HorasColaboradores
             orderby o.Id_HorasColaborador
             select new HorasColaborador()
             {
                 Id_HorasColaborador = o.Id_HorasColaborador,
                 Horas = o.Horas,
                 Data = o.Data,
                 Descricao = o.Descricao,
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

            return horasColaboradores;
        }

        public void Update(HorasColaborador item)
        {
            HorasColaboradorDAO horasColaborador = _context.HorasColaboradores.FirstOrDefault(x => x.Id_HorasColaborador == item.Id_HorasColaborador);
            horasColaborador.Horas = item.Horas;
            horasColaborador.Data = item.Data;
            horasColaborador.Descricao = item.Descricao;

            if (item.Tarefa != null)
                horasColaborador.TarefaId_Tarefa = item.Tarefa.Id_Tarefa;
            if (item.Colaborador != null)
                horasColaborador.ColaboradorId_Colaborador = item.Colaborador.Id_Colaborador;

            _context.SaveChanges();
        }
    }
}
