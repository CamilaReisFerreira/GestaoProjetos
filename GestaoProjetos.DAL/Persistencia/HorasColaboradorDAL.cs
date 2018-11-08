using GestaoProjetos.DAL.Context;
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
            throw new System.NotImplementedException();
        }

        public void Delete(long Id)
        {
            throw new System.NotImplementedException();
        }

        public HorasColaborador GetHorasColaborador(long Id)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}
