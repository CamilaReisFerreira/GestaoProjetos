using GestaoProjetos.DAL.Context;
using GestaoProjetos.DAL.Entidades;
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
            var tarefa = new TarefaDAO
            {
                Descricao = item.Descricao,
                Observacao = item.Observacao,
                Situacao = item.Situacao,
                Data_Abertura = item.Data_Abertura,
                Data_Entrega = item.Data_Entrega,
                Projeto = item.Projeto != null ? new ProjetoDAO
                {
                    Id_Projeto = item.Projeto.Id_Projeto,
                    Razao_Social = item.Projeto.Razao_Social,
                    CNPJ = item.Projeto.CNPJ,
                    Horas_Projeto = item.Projeto.Horas_Projeto,
                    Data_Inicial_Contrato = item.Projeto.Data_Inicial_Contrato,
                    Observacoes = item.Projeto.Observacoes
                } : null,
            };

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }

        public void Delete(long Id)
        {
            TarefaDAO tarefa = _context.Tarefas.FirstOrDefault(x => x.Id_Tarefa == Id);

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
        }

        public Tarefa GetTarefa(long Id)
        {
            TarefaDAO tarefa = _context.Tarefas.Find(Id);
            return tarefa != null ?
                new Tarefa
                {
                    Id_Tarefa = tarefa.Id_Tarefa,
                    Descricao = tarefa.Descricao,
                    Observacao = tarefa.Observacao,
                    Situacao = tarefa.Situacao,
                    Data_Abertura = tarefa.Data_Abertura,
                    Data_Entrega = tarefa.Data_Entrega,
                    Projeto = tarefa.Projeto != null ? new Projeto
                    {
                        Id_Projeto = tarefa.Projeto.Id_Projeto,
                        Razao_Social = tarefa.Projeto.Razao_Social,
                        CNPJ = tarefa.Projeto.CNPJ,
                        Horas_Projeto = tarefa.Projeto.Horas_Projeto,
                        Data_Inicial_Contrato = tarefa.Projeto.Data_Inicial_Contrato,
                        Observacoes = tarefa.Projeto.Observacoes
                    } : null,
                } : null;
        }

        public IList<Tarefa> ListarTarefas()
        {
            List<Tarefa> tarefa =
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

            return tarefa;
        }

        public void Update(Tarefa item)
        {
            TarefaDAO tarefa = _context.Tarefas.FirstOrDefault(x => x.Id_Tarefa == item.Id_Tarefa);
            tarefa.Descricao = item.Descricao;
            tarefa.Observacao = item.Observacao;
            tarefa.Situacao = item.Situacao;
            tarefa.Data_Abertura = item.Data_Abertura;
            tarefa.Data_Entrega = item.Data_Entrega;
            tarefa.Projeto = item.Projeto != null ? new ProjetoDAO
            {
                Id_Projeto = item.Projeto.Id_Projeto,
                Razao_Social = item.Projeto.Razao_Social,
                CNPJ = item.Projeto.CNPJ,
                Horas_Projeto = item.Projeto.Horas_Projeto,
                Data_Inicial_Contrato = item.Projeto.Data_Inicial_Contrato,
                Observacoes = item.Projeto.Observacoes
            } : null;

            _context.SaveChanges();
        }
    }
}
