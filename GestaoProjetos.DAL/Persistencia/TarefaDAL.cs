using GestaoProjetos.DAL.Context;
using GestaoProjetos.DAL.Interfaces;
using GestaoProjetos.DTO;
using System.Collections.Generic;
using System.Linq;

namespace GestaoProjetos.DAL.Persistencia
{
    public class TarefaDAL : ITarefaDAL
    {
        private readonly EFContext _context;

        public TarefaDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(Tarefa item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long Id)
        {
            throw new System.NotImplementedException();
        }

        public Tarefa GetTarefa(long Id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Tarefa> ListarTarefas()
        {
            List<Tarefa> tarefas =
            (from o in _context.Tarefas
             orderby o.Descricao
             select new Tarefa()
             {
                 Id_Tarefa = o.Id_Tarefa,
                 Descricao = o.Descricao,
                 Observacao = o.Observacao,
                 Situacao = o.Situacao,
                 Data_Abertura = o.Data_Abertura,
                 Data_Entrega = o.Data_Entrega,
                 Projeto = o.Projeto != null ? new Projeto
                 {
                     Id_Projeto = o.Projeto.Id_Projeto,
                     Razao_Social = o.Projeto.Razao_Social,
                     CNPJ = o.Projeto.CNPJ,
                     Horas_Projeto = o.Projeto.Horas_Projeto,
                     Data_Inicial_Contrato = o.Projeto.Data_Inicial_Contrato,
                     Observacoes = o.Projeto.Observacoes
                 } : null,
                }).ToList();

            return tarefas;
        }

        public void Update(Tarefa item)
        {
            throw new System.NotImplementedException();
        }
    }
}
